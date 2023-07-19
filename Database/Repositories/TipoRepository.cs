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
    public class TipoRepository : GenericRepository<Tipo>, ITipoRepository
    {
        private readonly ApplicationContext _DbContext;

        public TipoRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;

        }            

    }
}
