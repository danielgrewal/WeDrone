using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeDrone.Web.Core.Common;
using WeDrone.Web.Core.Interfaces;
using WeDrone.Web.Core.Persistence;
using WeDrone.Web.Models;

namespace WeDrone.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly WeDroneContext _context;
        private readonly DroneOptions _options;

        public OrdersController(WeDroneContext context, IOptions<DroneOptions> options)
        {
            _context = context;
            _options = options.Value;
        }

        public IActionResult Index()
        {
            var model = new DashboardModel(_context);
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("/Orders/{id:int}")]
        public IActionResult Order(int id)
        {
            var order = _context.Orders
                .Include(o => o.User)         
                .Include(o => o.Origin)
                .Include(o => o.Destination)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return RedirectToAction("Index", "Orders");

            var orderHistory = _context.OrderHistory
                .Where(oh => oh.Orderid == id && oh.ValidFrom < DateTime.Now)
                .Include(oh => oh.From)
                .Include(oh => oh.To)
                .Include(oh => oh.Status)
                .ToList();

            var model = new ViewOrderModel(order, orderHistory);
                
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IAddressLookup addressFinder, CreateOrderModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Weight > _options.MaxWeight)
                ModelState.AddModelError(String.Empty, $"The package cannot weigh more than {_options.MaxWeight} kg");

            if (model.Length * model.Width * model.Height > _options.MaxVolume)
                ModelState.AddModelError(String.Empty, $"The package cannot be more than {_options.MaxVolume} cubic meters in volume.");

            // Get pick-up/drop-off locations
            var pickupLocationResult = await model.GetLocation(_context, addressFinder, model.PickupAddress);
            var dropoffLocationResult = await model.GetLocation(_context, addressFinder, model.DropoffAddress);

            if (!pickupLocationResult.IsSuccess)
                ModelState.AddModelError(model.PickupAddress, pickupLocationResult.FailureReason);

            if (!dropoffLocationResult.IsSuccess)
                ModelState.AddModelError(model.DropoffAddress, dropoffLocationResult.FailureReason);

            if (!ModelState.IsValid)
                return View(model);

            var pickupLocation = pickupLocationResult.Payload;
            var dropoffLocation = dropoffLocationResult.Payload;

            var flightPlanner = new FlightPlanner(_context, _options, pickupLocation, dropoffLocation);
            var flightPlanResult = flightPlanner.GetFlightPlan();

            if (!flightPlanResult.IsSuccess)
            {
                ModelState.AddModelError("", flightPlanResult.FailureReason);
                return View(model);
            }

            var username = HttpContext.User.Identity.Name;
            var order = model.CreateOrder(_context, _options, flightPlanResult.Payload, flightPlanner.FlightRouteId, username);

            return RedirectToAction("Order", "Orders", new { id = order.OrderId });
        }

        [HttpGet]
        public async Task<IActionResult> FindAddress([FromServices] IAddressLookup addressFinder, string query)
        {
            var addresses = await addressFinder.Find(query);
            return Ok(addresses);
        }
    }
}
