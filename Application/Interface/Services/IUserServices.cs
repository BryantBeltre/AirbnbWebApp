using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Application.ViewModel.Tipos;
using Airbnb.Core.Application.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Interface.Services
{
    public interface IUserServices : IGenericServices<UserSaveViewModel, UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel lgvm);

    }
}
