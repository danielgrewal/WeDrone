using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeDrone.Web.Models;

namespace WeDrone.Web.Controllers
{
    public class OrdersController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}