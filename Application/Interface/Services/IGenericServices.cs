using Airbnb.Core.Application.ViewModel.Airbnb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Interface.Services
{
    public interface IGenericServices<SaveViewModel, ViewModel>
    {
        Task Update(SaveViewModel asvm);

        Task Add(SaveViewModel asvm);

        Task<SaveViewModel> GetByIdSaveViewModel(int id);

        Task<List<ViewModel>> GetAllViewModel();

        Task Delete(int id);
    }
}
