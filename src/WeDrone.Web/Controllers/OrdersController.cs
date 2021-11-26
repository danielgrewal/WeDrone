using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeDrone.Web.Core.Interfaces;
using WeDrone.Web.Models;

namespace WeDrone.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel orderVm)
        {
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
