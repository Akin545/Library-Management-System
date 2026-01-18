using Library.Management.System.BusinessService.Interfaces;
using Library.Management.System.BusinessService.Interfaces.Utilities;
using Library.Management.System.Core.Models;
using Library.Management.System.Repository.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Linq.Expressions;

namespace Library.Management.System.BusinessService
{

     public class BookBusinessService : BusinessServiceBase<Book, IBookRepository>
       , IBookBusinessService
    {
        
        public BookBusinessService(IBookRepository repository
            , IGlobalDateTimeSettings globalDateTimeBusinessServices
            , ILogger<Book> logger
            , IGlobalService globalService
            , IServiceScopeFactory scopeFactory)
            : base(repository,
                globalDateTimeBusinessServices,
                logger,
                globalService,
                scopeFactory)
        {
           

        }


        public async Task<List<Book>> SearchAsync(Book item, int? pageNo)
        {
            CheckIfNull(item);

            var result = await RepositoryManager.SearchAsync(item, pageNo);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<int> CountAsync(List<Expression<Func<Book, bool>>> delegates)
        {
            var count = await RepositoryManager.CountAsync(delegates);
            return count;
        }
    }
}
