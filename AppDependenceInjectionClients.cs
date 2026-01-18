using Library.Management.System.BusinessService;
using Library.Management.System.BusinessService.Interfaces;
using Library.Management.System.BusinessService.Interfaces.Utilities;
using Library.Management.System.BusinessService.Utilities;
using Library.Management.System.Repository;
using Library.Management.System.Repository.Interfaces;

namespace Library_Management_System
{
    public class AppDependenceInjectionClients
    {
        public static void Resgister(WebApplicationBuilder builder)
        {
            //add all dependency services here

            builder.Services.AddScoped<IUserBusinessService, UserBusinessService>();

            builder.Services.AddScoped<IBookBusinessService, BookBusinessService>();

            builder.Services.AddScoped<IGlobalService, GlobalService>();
            builder.Services.AddScoped<IGlobalDateTimeSettings, GlobalDateTimeSettings>();


            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IBookRepository, BookRepository>();

        }
    }
}
