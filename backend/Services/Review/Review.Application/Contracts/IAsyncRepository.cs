using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewing.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetAll();
        Task<T> AddNew(T entity);
        Task<T?> GetById(int id);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
