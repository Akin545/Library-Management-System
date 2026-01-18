using Library.Management.System.Core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.BusinessService.Interfaces
{
    public interface IBusinessServiceBase<T> where T : IEntity
    {
        Task<int> AddAsync(T item);

        Task<T> GetAsync(int id);
        Task DeleteAsync(T entity);

        Task<T> GetAsync(int id, params string[] includes);

        Task UpdateAsync(T item);


    }
}
