using Airbnb.Core.Application.ViewModel.Airbnb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Interface.Services
{
    public interface IAirbnbServices : IGenericServices<airbnbSaveViewModel, airbnbViewModel>
    {
        Task<List<airbnbViewModel>> GetAllViewModelWithFilter(FilterAirbnbViewModel filters);
    }
}
