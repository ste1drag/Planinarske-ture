using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Contracts;

namespace Tours.Infrastructure.Services
{
    public class BaseService<T> : IAsyncRepository<T> where T : class
    {

        protected readonly ToursDbContext _dbContext;
        public virtual async Task<T> AddNew(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            var retValue = await _dbContext.Set<T>().ToListAsync();

            return retValue;
        }

        public virtual async Task<T?> GetById(string id)
        {
            var retValue = await _dbContext.Set<T>().FindAsync(id);

            return retValue;
        }

        public virtual async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
