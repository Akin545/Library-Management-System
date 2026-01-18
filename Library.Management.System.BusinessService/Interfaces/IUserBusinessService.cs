using Library.Management.System.Core.Models;

namespace Library.Management.System.BusinessService.Interfaces
{
    public interface IUserBusinessService : IBusinessServiceBase<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<int> AddAsync(User entity);
        Task<string> LoginAsync(User item);
    }
}