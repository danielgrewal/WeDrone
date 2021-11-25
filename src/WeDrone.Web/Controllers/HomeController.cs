using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public IActionResult Locations(string query)
        {


            throw new NotImplementedException();
        }

        
    }
}