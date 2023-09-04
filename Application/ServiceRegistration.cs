using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.Services.Airbnb;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IAirbnbServices, AirbnbServices>();
            services.AddTransient<ITipoServices, TipoServices>();
            services.AddTransient<IUserServices, UserServices>();
            #endregion

        }
    }
}
