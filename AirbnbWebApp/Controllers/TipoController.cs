using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Application.ViewModel.Tipos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirbnbWebApp.Controllers
{
    public class TipoController : Controller
    {
        private readonly ITipoServices _tipoServices;

        public TipoController(ITipoServices tipoServices)
        {
            _tipoServices = tipoServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipoServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveTipo", new TipoSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoSaveViewModel tsvm) 
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tsvm);
            }

            await _tipoServices.Add(tsvm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _tipoServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _tipoServices.Delete(id);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTipo", await _tipoServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoSaveViewModel tsvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tsvm);
            }

            await _tipoServices.Update(tsvm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
    }
}
