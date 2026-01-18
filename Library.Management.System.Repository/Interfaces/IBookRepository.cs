using Library.Management.System.Core.Models;

using System.Linq.Expressions;

namespace Library.Management.System.Repository.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<int> CountAsync(List<Expression<Func<Book, bool>>> delegates);

        Task<List<Book>> SearchAsync(Book item, int? pageNo);
    }
}
