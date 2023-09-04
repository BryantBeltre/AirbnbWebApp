using Airbnb.Core.Application.Interface.Repositories;
using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.ViewModel.Airbnb;
using Airbnb.Core.Application.ViewModel.Tipos;
using Airbnb.Core.Application.ViewModel.User;
using Airbnb.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Services.Airbnb
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
         
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Login(LoginViewModel lgvm)
        {
            User user = await _userRepository.LoginAsync(lgvm);

            if (user == null)
            {
                return null;
            }

            UserViewModel usrvm = new();
            usrvm.Id = user.Id;
            usrvm.Name = user.Name;
            usrvm.UserName = user.UserName;
            usrvm.Password = user.Password;
            usrvm.Email = user.Email;
            usrvm.Phone = user.Phone;

            return usrvm;
        }

        public async Task Update(UserSaveViewModel usvm)
        {
            User user = new(); 
            user.Id = usvm.Id;
            user.Name = usvm.Name;
            user.UserName = usvm.UserName;
            user.Password = usvm.Password;
            user.Email = usvm.Email;
            user.Phone = usvm.Phone;

            await _userRepository.UpdateAsync(user);
        }

        public async Task Add(UserSaveViewModel usvm)
        {
            User user = new();
            user.Name = usvm.Name;
            user.UserName = usvm.UserName;
            user.Password = usvm.Password;
            user.Email = usvm.Email;
            user.Phone = usvm.Phone;
            await _userRepository.addAsync(user);
        }

        public async Task<UserSaveViewModel> GetByIdSaveViewModel(int id)
        {
            var userList = await _userRepository.GetByIdAsync(id);

            UserSaveViewModel usvm = new();

            usvm.Id = userList.Id;
            usvm.Name = userList.Name;
            usvm.UserName = userList.UserName;
            usvm.Password = userList.Password;
            usvm.Email = userList.Email;
            usvm.Phone = userList.Phone;

            return usvm;
        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var userList = await _userRepository.GetAllWithIncludeAsync(new List<string> {"Airbnb"});

            return userList.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                UserName= user.UserName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                

            }).ToList();
        }

        public async Task Delete(int id)
        {
            var uarbnb = await _userRepository.GetByIdAsync(id);

            await _userRepository.DeleteAsync(uarbnb);
        }
    }
}
