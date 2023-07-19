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

namespace AirbnbWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAirbnbServices _airbnbServices;
        private readonly ITipoServices _tipoServices;

        public HomeController(IAirbnbServices airbnbServices, ITipoServices tipoServices)
        {
            _airbnbServices = airbnbServices;
            _tipoServices = tipoServices;
        }

        public async Task<IActionResult> Index(FilterAirbnbViewModel fvm)
        {
            ViewBag.Tipos = await _tipoServices.GetAllViewModel();
            return View(await _airbnbServices.GetAllViewModelWithFilter(fvm));
        }      


    }
}
