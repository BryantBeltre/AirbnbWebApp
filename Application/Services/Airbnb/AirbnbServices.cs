using Airbnb.Core.Application.Interface.Repositories;
using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Services.Airbnb
{
    public class AirbnbServices : IAirbnbServices
    {
        private readonly IAirbnbRepository _airbnbRepository;

        public AirbnbServices(IAirbnbRepository airbnbRepository)
        {
            _airbnbRepository = airbnbRepository;
        }

        public async Task Update(airbnbSaveViewModel asvm)
        {
            Airbnbs airbnb = new();
            airbnb.Id = asvm.Id;
            airbnb.Name = asvm.Name;
            airbnb.Description = asvm.Description;
            airbnb.Ubication = asvm.Ubication;
            airbnb.UrlImg = asvm.UrlImg;
            airbnb.Owner = asvm.Owner;
            airbnb.Priece = asvm.Priece;
            airbnb.TipoId = asvm.TipoId;

            await _airbnbRepository.UpdateAsync(airbnb);
        }

        public async Task Add(airbnbSaveViewModel asvm)
        {
            Airbnbs airbnb = new();

            airbnb.Name = asvm.Name;
            airbnb.Description = asvm.Description;
            airbnb.Ubication = asvm.Ubication;
            airbnb.UrlImg = asvm.UrlImg;
            airbnb.Owner = asvm.Owner;
            airbnb.Priece = asvm.Priece;
            airbnb.TipoId = asvm.TipoId;

            await _airbnbRepository.addAsync(airbnb);
        }

        public async Task<airbnbSaveViewModel> GetByIdSaveViewModel(int id)
        {
            var airbnbList = await _airbnbRepository.GetByIdAsync(id);

            airbnbSaveViewModel asvm = new();

            asvm.Id = airbnbList.Id;
            asvm.Name = airbnbList.Name;
            asvm.Description = airbnbList.Description;
            asvm.Ubication = airbnbList.Ubication;
            asvm.UrlImg = airbnbList.UrlImg;
            asvm.Owner = airbnbList.Owner;
            asvm.Priece = airbnbList.Priece;
            asvm.TipoId = airbnbList.TipoId;

            return asvm;
        }

        public async Task<List<airbnbViewModel>> GetAllViewModel()
        {
            var airbnbList = await _airbnbRepository.GetAllWithIncludeAsync(new List<string> { "Tipo" });

            return airbnbList.Select(airbnb => new airbnbViewModel
            {
                Id = airbnb.Id,
                Name = airbnb.Name,
                Ubication = airbnb.Ubication,
                Owner = airbnb.Owner,
                Description = airbnb.Description,
                UrlImg = airbnb.UrlImg,
                Priece = airbnb.Priece,
                TipoId = airbnb.Tipo.Id,
                TipoName = airbnb.Tipo.Name

            }).ToList();
        }

        public async Task<List<airbnbViewModel>> GetAllViewModelWithFilter(FilterAirbnbViewModel filters)
        {
            var airbnbList = await _airbnbRepository.GetAllWithIncludeAsync(new List<string> { "Tipo" });


            var airbnbfilters= airbnbList.Select(airbnb => new airbnbViewModel
            {
                Id = airbnb.Id,
                Name = airbnb.Name,
                Ubication = airbnb.Ubication,
                Owner = airbnb.Owner,
                Description = airbnb.Description,
                UrlImg = airbnb.UrlImg,
                Priece = airbnb.Priece,
                TipoId = airbnb.Tipo.Id,
                TipoName = airbnb.Tipo.Name

            }).ToList();

            if (filters.TiposNameId != null)
            {
                airbnbfilters = airbnbfilters.Where(airbnb => airbnb.TipoId == filters.TiposNameId.Value).ToList();
            }

            return airbnbfilters;
        }

        public async Task Delete(int id)
        {
            var air = await _airbnbRepository.GetByIdAsync(id);

            await _airbnbRepository.DeleteAsync(air);
        }
    }
}
