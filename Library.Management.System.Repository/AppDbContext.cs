using Library.Management.System.Core.Enum;
using Library.Management.System.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace Library.Management.System.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data for Roles, Users, Clients, and UserRoles.
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Sola Akinfosile",
                    Email = "admin@hotmail.com",
                    Roles = RoleTypeEnum.Admin,
                    PhoneNumber = "+2348034336608",
                    PasswordHash = "ttt",
                    CreatedBy = new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"),
                    CreatedDate = new DateTime(2025, 10, 17),
                }

            );


            // Seed initial data for books

            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   Title = "Rivers Of Love",
                   Author = "Tom Cruz",
                   ISBN = "55655656",
                   PublishedDate = new DateTime(2024, 10, 17),
                   CreatedBy = new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"),
                   CreatedDate = new DateTime(2025, 10, 17),
               },
               new Book
               {
                   Id = 2,
                   Title = "Fast And Furious",
                   Author = "Tom Cruz",
                   ISBN = "554336",
                   PublishedDate = new DateTime(2024, 10, 17),
                   CreatedBy = new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"),
                   CreatedDate = new DateTime(2025, 10, 17),
               },
               new Book
               {
                   Id = 3,
                   Title = "Magic Wind",
                   Author = "Boo Smith",
                   ISBN = "554336",
                   PublishedDate = new DateTime(2024, 10, 17),
                   CreatedBy = new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"),
                   CreatedDate = new DateTime(2025, 10, 17),
               },
               new Book
               {
                   Id = 4,
                   Title = "Blow Hot",
                   Author = "Boo Smith",
                   ISBN = "123344",
                   PublishedDate = new DateTime(2024, 10, 17),
                   CreatedBy = new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"),
                   CreatedDate = new DateTime(2025, 10, 17),
               }
           );


        }
    }
}