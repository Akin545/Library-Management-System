using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Management.System.Repository.Migrations
{
    /// <inheritdoc />
    public partial class LibraryManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "ISBN", "PublishedDate", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Tom Cruz", new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"), new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "55655656", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rivers Of Love", null, null },
                    { 2, "Tom Cruz", new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"), new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "554336", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast And Furious", null, null },
                    { 3, "Boo Smith", new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"), new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "554336", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magic Wind", null, null },
                    { 4, "Boo Smith", new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"), new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "123344", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blow Hot", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FullName", "PasswordHash", "PhoneNumber", "Roles", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, new Guid("a5a65e94-3d4a-4f9a-9b6c-67a4b3e5fa91"), new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@hotmail.com", "Sola Akinfosile", "ttt", "+2348034336608", 2, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
