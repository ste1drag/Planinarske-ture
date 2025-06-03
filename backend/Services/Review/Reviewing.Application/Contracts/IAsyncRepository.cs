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
