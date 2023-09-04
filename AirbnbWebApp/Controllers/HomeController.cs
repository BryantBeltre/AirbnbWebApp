using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Infrastructure.Persistence.Context;
using AirbnbWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.AirbnbApp.Middlewares;

namespace AirbnbWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAirbnbServices _airbnbServices;
        private readonly ITipoServices _tipoServices;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(IAirbnbServices airbnbServices, ITipoServices tipoServices, ValidateUserSession validateUserSession)
        {
            _airbnbServices = airbnbServices;
            _tipoServices = tipoServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index(FilterAirbnbViewModel fvm)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            ViewBag.Tipos = await _tipoServices.GetAllViewModel();
            return View(await _airbnbServices.GetAllViewModelWithFilter(fvm));
        }      


    }
}
