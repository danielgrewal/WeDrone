using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel orderModel)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            //var result = orderModel
            //var result = orderModel;

            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> FindAddress([FromServices] IAddressLookup addressFinder, string query)
        {
            var addresses = await addressFinder.Find(query);

            return Ok(addresses);
        }
    }
}
