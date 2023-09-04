using Airbnb.Core.Application.Helpers;
using Airbnb.Core.Application.Interface.Repositories;
using Airbnb.Core.Application.ViewModel.User;
using Airbnb.Core.Domain.Entities;
using Airbnb.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _DbContext;

        public UserRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;

        }


        public override async Task addAsync(User entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            await base.addAsync(entity);
        }
        
        public async Task<User> LoginAsync(LoginViewModel lgvm)
        {
            string passwordEncrypy = PasswordEncryption.ComputeSha256Hash(lgvm.Password);
            User user = await _DbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.UserName == lgvm.UserName && user.Password == passwordEncrypy);
            
            return user;
        }

    }
}
