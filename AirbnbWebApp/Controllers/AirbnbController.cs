using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using WebApp.AirbnbApp.Middlewares;

namespace AirbnbWebApp.Controllers
{
    public class AirbnbController : Controller
    {
        private readonly IAirbnbServices _airbnbServices;
        private readonly ITipoServices _tipoServices;
        private readonly ValidateUserSession _validateUserSession;

        public AirbnbController(IAirbnbServices airbnbServices, ITipoServices tipoServices, ValidateUserSession validateUserSession)
        {
            _airbnbServices = airbnbServices;
            _tipoServices = tipoServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            return View(await _airbnbServices.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            airbnbSaveViewModel vm = new();
            vm.Tipos = await _tipoServices.GetAllViewModel();               
            return View("SaveAirbnb",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(airbnbSaveViewModel asvm) 
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }

            if (!ModelState.IsValid)
            {
                asvm.Tipos = await _tipoServices.GetAllViewModel();
                return View("SaveAirbnb", asvm);
            }

            await _airbnbServices.Add(asvm);
            return RedirectToRoute(new { controller = "Airbnb", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            return View(await _airbnbServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            await _airbnbServices.Delete(id);
            return RedirectToRoute(new { controller = "Airbnb", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            airbnbSaveViewModel vm = await _airbnbServices.GetByIdSaveViewModel(id);
            vm.Tipos = await _tipoServices.GetAllViewModel();
            return View("SaveAirbnb", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(airbnbSaveViewModel asvm)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }

            if (!ModelState.IsValid)
            {
                asvm.Tipos = await _tipoServices.GetAllViewModel();
                return View("SaveAirbnb", asvm);
            }

            await _airbnbServices.Update(asvm);
            return RedirectToRoute(new { controller = "Airbnb", action = "Index" });
        }
    }
}
