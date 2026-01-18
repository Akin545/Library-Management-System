using Library.Management.System.Core.Interface;

namespace Library.Management.System.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : IEntity
    {
        Task<int> AddAsync(T item);

        Task<T> GetAsync(int id);

        Task<T> GetAsync(int id, params string[] includes);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T item);

    }
}
