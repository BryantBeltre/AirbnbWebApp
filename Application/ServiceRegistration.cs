using Airbnb.Core.Application.Interface.Repositories;
using Airbnb.Core.Application.Interface.Services;
using Airbnb.Core.Application.Services.Airbnb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddpersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<IAirbnbServices, AirbnbServices>();
            services.AddTransient<ITipoServices, TipoServices>();
            #endregion

        }
    }
}
