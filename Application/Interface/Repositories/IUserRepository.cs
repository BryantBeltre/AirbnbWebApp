using Airbnb.Core.Application.ViewModel.User;
using Airbnb.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<User> LoginAsync(LoginViewModel lgvm);
    }
}
