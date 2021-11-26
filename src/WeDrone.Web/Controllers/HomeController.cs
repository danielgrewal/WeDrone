using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeDrone.Web.Core.Interfaces;
using WeDrone.Web.Models;

namespace WeDrone.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult Track()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FindAddress([FromServices] IAddressLookup addressFinder, string query)
        {
            var addresses = await addressFinder.Find(query);

            return Ok(addresses);
        }

        
    }
}