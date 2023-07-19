using Airbnb.Core.Application.Interface.Repositories;
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
    public class AirbnbRepository : GenericRepository<Airbnbs>, IAirbnbRepository
    {
        private readonly ApplicationContext _DbContext;

        public AirbnbRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;

        }         

    }
}
