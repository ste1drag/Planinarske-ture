using Reviewing.Application.Contracts;
using Reviewing.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Reviewing.Infrastructure.Persistence;
using PagedList.Core;

namespace Reviewing.Infrastructure.Repositories
{
    public class RepositoryBase<T>(ReviewContext context) : IAsyncRepository<T> where T : EntityBase
    {
        protected ReviewContext _context = context;

        public async Task<T> AddNew(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        async public Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<T>> GetPaged(int pageNumber, int pageSize)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1, nameof(pageNumber));
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1, nameof(pageSize));

            var query = _context.Set<T>().AsNoTracking().OrderBy(e => e.Id);
            var pagedList = await Task.Run(() => new PagedList<T>(query, pageNumber, pageSize));
            return pagedList;
        }

        async public Task<T?> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
