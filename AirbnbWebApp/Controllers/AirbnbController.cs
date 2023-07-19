using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace AirbnbWebApp.Controllers
{
    public class AirbnbController : Controller
    {
        private readonly IAirbnbServices _airbnbServices;
        private readonly ITipoServices _tipoServices;

        public AirbnbController(IAirbnbServices airbnbServices, ITipoServices tipoServices)
        {
            _airbnbServices = airbnbServices;
            _tipoServices = tipoServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _airbnbServices.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            airbnbSaveViewModel vm = new();
            vm.Tipos = await _tipoServices.GetAllViewModel();               
            return View("SaveAirbnb",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(airbnbSaveViewModel asvm) 
        {
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
            return View(await _airbnbServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _airbnbServices.Delete(id);
            return RedirectToRoute(new { controller = "Airbnb", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            airbnbSaveViewModel vm = await _airbnbServices.GetByIdSaveViewModel(id);
            vm.Tipos = await _tipoServices.GetAllViewModel();
            return View("SaveAirbnb", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(airbnbSaveViewModel asvm)
        {
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
