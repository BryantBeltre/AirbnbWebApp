using Airbnb.Core.Application.Helpers;
using Airbnb.Core.Application.ViewModel.User;
using Microsoft.AspNetCore.Http;

namespace WebApp.AirbnbApp.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUSer()
        {
            UserViewModel userView = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            if (userView == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
