using AutoMapper;

using Library.Management.System.BusinessService.Interfaces;
using Library.Management.System.BusinessService.Interfaces.Utilities;
using Library.Management.System.Core.Dtos;
using Library.Management.System.Core.Dtos.Book;
using Library.Management.System.Core.Dtos.User;
using Library.Management.System.Core.Exceptions;
using Library.Management.System.Core.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Swashbuckle.AspNetCore.Annotations;

using System.Linq.Expressions;

using static Library_Management_System.Controllers.LibraryManagementSystemControllerBase;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class BookController : LibraryManagementControllerBase<BookDTO, Book, IBookBusinessService>
    {

        public BookController(ILogger<Book> logger
           , IBookBusinessService businessService
           , IGlobalDateTimeSettings globalDateTimeBusinessServices
           , IMapper mapper
           , IConfiguration configuration
           , IGlobalService globalService
           , IServiceScopeFactory scopeFactory)
           : base(logger, businessService, globalDateTimeBusinessServices, mapper, configuration, globalService, scopeFactory)
        {

        }

        [HttpPost]
       
        [SwaggerOperation(
        Summary = "Users can create book",
        Tags = new[] { "Books" }

        )]
        public async Task<IActionResult> AddAsync([FromBody] CreateBookDTO item)
        {
            try
            {

                if (User.Identity.IsAuthenticated)
                {

                    if (item != null)
                    {
                        var requestBody = $"create  Request Body:  {JsonConvert.SerializeObject(item)}";
                        HealthLogger.LogInformation(requestBody);
                    }

                    if (item == null || !ModelState.IsValid)
                    {
                        return BadRequest("Invalid Create Book State");
                    }

                    var result = MapDTOToEntityWithNoID<CreateBookDTO, Book>(item);
                    SetAuditInformation(result);
                    await BusinessServiceManager.AddAsync(result);

                    return Ok(result);

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (BookException ex)
            {
                var errorMessage = $"error at AddAsync of {nameof(BookController)}  ";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (PermissionBaseException ex)
            {
                var errorMessage = $"error at AddAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = $"error at AddAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return StatusCode(500);
            }
        }

        [HttpGet()]
        [Route("Search")]
        [SwaggerOperation(
        Summary = "Users can search books by author or titles. Note: this endpoint also serve to retrieve all books if author and title textbox are left blank",
        Tags = new[] { "Books" }

        )]
        public virtual async Task<IActionResult> SearchAsync(
            [FromQuery] string? title,
            [FromQuery] string? author,
            [FromQuery] int? pageNo)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {

                    var entities = new List<Book>();

                    var dBSearch = new SearchBookDTO
                    {
                        Author = author,
                        Title = title,
                    };

                    var model = MapperManager.Map<SearchBookDTO, Book>(dBSearch);
                    int count = await BusinessServiceManager.CountAsync(ListCountPredicate(model));

                    entities = await BusinessServiceManager.SearchAsync(model, pageNo);

                    if (entities == null || !entities.Any())
                    {
                        return NotFound("No data found");
                    }

                    var result = MapperManager.Map<List<BookDTO>>(entities);

                    SearchResponseDTO<BookDTO> response = new SearchResponseDTO<BookDTO>
                    {
                        MaxLength = count,
                        Results = result
                    };

                    return Ok(response);

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (BookException ex)
            {
                var errorMessage = $"error at SearchAsync of {nameof(BookController)}  ";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (PermissionBaseException ex)
            {
                var errorMessage = $"error at SearchAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = $"error at SearchAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return StatusCode(500);
            }
        }


        [HttpGet()]
        [Route("{id}")]
        [SwaggerOperation(
        Summary = "users can get to view a particular book by their id",

        Tags = new[] { "Books" }
        )]
        public new async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return await base.GetAsync(id);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (BookException ex)
            {
                var errorMessage = $"error at GetAsync of {nameof(BookController)}  ";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (PermissionBaseException ex)
            {
                var errorMessage = $"error at GetAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = $"error at GetAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return StatusCode(500);
            }
        }

        [HttpDelete()]
        [Route("{id}")]
        [SwaggerOperation(
        Summary = "users can delete a particular book by their id",

        Tags = new[] { "Books" }
        )]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return await base.DeleteAsync(id);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (BookException ex)
            {
                var errorMessage = $"error at DeleteAsync of {nameof(BookController)}  ";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (PermissionBaseException ex)
            {
                var errorMessage = $"error at DeleteAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = $"error at DeleteAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
       
        [SwaggerOperation(
        Summary = "Users/Admin can update book by id",
        Tags = new[] { "Books" }

        )]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBookDTO item, int id)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest($"Invalid update {nameof(Book)} State");
                }

                var updateBook = MapperManager.Map<UpdateBookDTO, BookDTO>(item);
                return await base.UpdateAsync(updateBook, id);
            }
            catch (BookException ex)
            {
                var errorMessage = $"error at UpdateAsync of {nameof(BookController)}  ";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (PermissionBaseException ex)
            {
                var errorMessage = $"error at UpdateAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = $"error at UpdateAsync of {nameof(BookController)}";
                HealthLogger.LogError(ex, errorMessage);
                return StatusCode(500);
            }
        }

        protected override Book SetUpdateAuditInformation(BookDTO TDTO, Book entity)
        {

            var createdBy = entity.CreatedBy;
            var createdOn = entity.CreatedDate;

            Book copy = SetAllDbValuesIntoACopy(entity);

            MapperManager.Map(TDTO, entity);

            SetNonUpdatableDbEntityPropertiesFromCopy(entity, copy);

            ReplaceNullOnDtoWithDbValues(entity, copy);

            entity.CreatedBy = createdBy;
            entity.CreatedDate = createdOn;

            return entity;
        }


        private void ReplaceNullOnDtoWithDbValues(Book entity, Book dbCopy)
        {
           
            entity.ISBN = entity.ISBN ?? dbCopy.ISBN;
            entity.Title = entity.Title ?? dbCopy.Title;
            entity.Author = entity.Author ?? dbCopy.Author;
            entity.PublishedDate = entity.PublishedDate == default ?
               dbCopy.PublishedDate : entity.PublishedDate;
        }

        private void SetNonUpdatableDbEntityPropertiesFromCopy(Book entity, Book dbCopy)
        {
            entity.Id = dbCopy.Id;
           
        }

        private Book SetAllDbValuesIntoACopy(Book entity)
        {
            var copy = new Book();

            copy.Id = entity.Id;
            copy.ISBN = entity.ISBN;
            copy.Title = entity.Title;
            copy.Author = entity.Author;
            copy.PublishedDate = entity.PublishedDate;

            return copy;
        }

        //Creating the search count method
        protected List<Expression<Func<Book, bool>>> ListCountPredicate(Book item)
        {

            List<Expression<Func<Book, bool>>> delegates = new List<Expression<Func<Book, bool>>>();


            if (!string.IsNullOrWhiteSpace(item.Author))
            {
                Expression<Func<Book, bool>> author = r => r.Author.ToLower().Contains(item.Author.ToLower());
                delegates.Add(author);
            }

            if (!string.IsNullOrWhiteSpace(item.Title))
            {
                Expression<Func<Book, bool>> title = r => r.Title.ToLower().Contains(item.Title.ToLower());
                delegates.Add(title);
            }

            return delegates;
        }


    }
}
