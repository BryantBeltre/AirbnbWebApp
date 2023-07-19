using Airbnb.Core.Application.Interface.Repositories;
using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Application.ViewModel.Tipos;
using Airbnb.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Services.Airbnb
{
    public class TipoServices : ITipoServices
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoServices(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public async Task Update(TipoSaveViewModel tsvm)
        {
            Tipo tipo = new();
            tipo.Id = tsvm.Id;
            tipo.Name = tsvm.Name;
            tipo.Description = tsvm.Description;

            await _tipoRepository.UpdateAsync(tipo);
        }

        public async Task Add(TipoSaveViewModel tsvm)
        {
            Tipo tipo = new();
            tipo.Name = tsvm.Name;
            tipo.Description = tsvm.Description;
            await _tipoRepository.addAsync(tipo);
        }

        public async Task<TipoSaveViewModel> GetByIdSaveViewModel(int id)
        {
            var tipoList = await _tipoRepository.GetByIdAsync(id);

            TipoSaveViewModel tsvm = new();

            tsvm.Id = tipoList.Id;
            tsvm.Name = tipoList.Name;
            tsvm.Description = tipoList.Description;

            return tsvm;
        }

        public async Task<List<TipoViewModel>> GetAllViewModel()
        {
            var tipoList = await _tipoRepository.GetAllWithIncludeAsync(new List<string> {"Airbnb"});

            return tipoList.Select(tipo => new TipoViewModel
            {
                Id = tipo.Id,
                Name = tipo.Name,
                Description = tipo.Description,
                HowManyAirbnb = tipo.Airbnb.Count()

            }).ToList();
        }

        public async Task Delete(int id)
        {
            var air = await _tipoRepository.GetByIdAsync(id);

            await _tipoRepository.DeleteAsync(air);
        }
    }
}
