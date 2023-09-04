using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Application.ViewModel.Tipos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.AirbnbApp.Middlewares;

namespace AirbnbWebApp.Controllers
{
    public class TipoController : Controller
    {
        private readonly ITipoServices _tipoServices;
        private readonly ValidateUserSession _validateUserSession;

        public TipoController(ITipoServices tipoServices, ValidateUserSession validateUserSession)
        {
            _tipoServices = tipoServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            return View(await _tipoServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            return View("SaveTipo", new TipoSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoSaveViewModel tsvm) 
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tsvm);
            }

            await _tipoServices.Add(tsvm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            return View(await _tipoServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            await _tipoServices.Delete(id);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            return View("SaveTipo", await _tipoServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoSaveViewModel tsvm)
        {
            if (!_validateUserSession.HasUSer())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tsvm);
            }

            await _tipoServices.Update(tsvm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
    }
}
