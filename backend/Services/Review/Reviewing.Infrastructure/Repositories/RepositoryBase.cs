using Reviewing.Application.Contracts;
using Reviewing.Domain.Common;

namespace Reviewing.Infrastructure.Repositories
{
    class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        // protected readonly ReviewContext _dbContext; 

        Task<T> IAsyncRepository<T>.AddNew(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IAsyncRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IAsyncRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<T?> IAsyncRepository<T>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<T> IAsyncRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
