using Library.Management.System.Core.Models;
using Library.Management.System.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace Library.Management.System.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IConfiguration configuration, ILogger<Book> logger, IServiceScopeFactory scopeFactory)
            : base(configuration, logger, scopeFactory)
        {
        }

        public async Task<List<Book>> SearchAsync(Book item, int? pageNo)
        {
            try
            {
                CurrentPageNumber = pageNo ?? 0;

                using (var scope = ScopeFactory.CreateScope())
                {
                    using (var databaseContext = scope.ServiceProvider
                                                   .GetRequiredService<AppDbContext>())
                    {
                        CheckConnection(databaseContext);

                        var query = databaseContext.Set<Book>()
                                               .AsQueryable();

                        if (!string.IsNullOrWhiteSpace(item.Author))
                        {
                            query = query.Where(r => r.Author.Contains(item.Author));
                        }

                        if (!string.IsNullOrWhiteSpace(item.Title))
                        {
                            query = query.Where(r => r.Title.ToLower().Contains(item.Title.ToLower()));
                        }

                        List<Book> result = await query.AsNoTracking()
                                                    .OrderByDescending(r => r.CreatedDate)
                                                    .Skip(SkippedDbRecordSize)
                                                    .Take(MaxPageSize)
                                                    .ToListAsync();

                        HealthLogger.LogInformation($" Successfully retrieved Search from {nameof(Book)} with page number {pageNo} ");
                        CurrentPageNumber = 0;
                        return result;
                    }
                }
            }
            catch (SqlNullValueException s)
            {
                HealthLogger.LogError(s, $" SqlNullValueException at Search from {nameof(Book)} with page number", pageNo);
                throw;
            }
            catch (Exception ex)
            {
                HealthLogger.LogError(ex, $" error at Search from {nameof(Book)} with page number", pageNo);
                throw;
            }
        }

        public async Task<int> CountAsync(List<Expression<Func<Book, bool>>> delegates)
        {
            try
            {

                using (var scope = ScopeFactory.CreateScope())
                {
                    using (var databaseContext = scope.ServiceProvider
                                                   .GetRequiredService<AppDbContext>())
                    {
                        CheckConnection(databaseContext);

                        var query = databaseContext.Set<Book>()
                                               .AsQueryable();

                        foreach (var item in delegates)
                        {
                            query = query.Where(item);
                        }

                        int counts = await query.CountAsync();

                        var typeName = nameof(Book);
                        HealthLogger.LogInformation($" Successfully retrieved {typeName} count");

                        return counts;
                    }
                }
            }
            catch (Exception ex)
            {
                HealthLogger.LogError(ex, " error at Counts ", delegates);
                throw;
            }
        }

    }
}
