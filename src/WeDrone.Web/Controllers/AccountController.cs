using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeDrone.Web.Core.Persistence;
using WeDrone.Web.Models;

namespace WeDrone.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly WeDroneContext _context;

        public AccountController(WeDroneContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel credentials)
        {
            if (!ModelState.IsValid)
                return View(credentials);

            var user = _context.Users.FirstOrDefault(u => u.Username == credentials.Username && u.Password == credentials.Password);

            if (user == null) { 
                ModelState.AddModelError("Username", "Invalid Username and/or Password.");
                ModelState.AddModelError("Password", "Invalid Username and/or Password.");
                return View(credentials);
            }

            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Name)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Orders");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
