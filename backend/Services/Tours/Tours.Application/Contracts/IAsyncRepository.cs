using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.Contracts
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> AddNew(T entity);
        Task<T?> GetById(Guid id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
