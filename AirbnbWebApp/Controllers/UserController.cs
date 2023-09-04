using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Application.ViewModel.Tipos;
using Airbnb.Core.Application.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using Airbnb.Core.Application.Helpers;
using WebApp.AirbnbApp.Middlewares;

namespace AirbnbWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ValidateUserSession _validateUserSession;

        public UserController(IUserServices userServices, ValidateUserSession validateUserSession)
        {
            _userServices = userServices;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginvm)
        {
            if (_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }

            if (!ModelState.IsValid)
            {
                return View(loginvm);
            }

            UserViewModel usvml = await _userServices.Login(loginvm);
            if (usvml != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", usvml);
                return RedirectToRoute(new { controller = "Home", action = "Index" });                    
            }
            else
            {
                ModelState.AddModelError("userValidation","Datos de acceso incorrecto");
            }
            return View(loginvm);
        }

        public IActionResult Register()
        {
            if (_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(new UserSaveViewModel());
        }
        
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", Action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSaveViewModel usvm)
        {
            if (_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            if (!ModelState.IsValid)
            {
                return View(usvm);
            }
            await _userServices.Add(usvm);
            return RedirectToRoute(new { controller = "User", Action = "Index" });
        }
    }
}
