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
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _DbContext;

        public GenericRepository(ApplicationContext DbContext )
        {
            _DbContext = DbContext;

        }


        public async Task addAsync(Entity entity)
        {
            await _DbContext.Set<Entity>().AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entity entity)
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(Entity entity)
        {
            _DbContext.Set<Entity>().Remove(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _DbContext.Set<Entity>().ToListAsync();
        }

        public async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _DbContext.Set<Entity>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync(); ;
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await  _DbContext.Set<Entity>().FindAsync(id);
        }
            
         
    }
}
