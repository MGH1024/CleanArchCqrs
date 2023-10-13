using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shop");

            migrationBuilder.EnsureSchema(
                name: "sec");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "user"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "user"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "user"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "shop",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "sec",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sec",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "ProductManagement" });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "CategoryManagement" });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2023, 10, 13, 15, 1, 29, 828, DateTimeKind.Local).AddTicks(9001), null, null, "admin@gmail.com", "admin", "admin", new byte[] { 15, 213, 11, 15, 33, 237, 202, 86, 65, 245, 81, 73, 77, 20, 133, 167, 18, 192, 241, 143, 18, 118, 127, 59, 15, 45, 200, 166, 118, 91, 129, 199, 41, 5, 244, 2, 79, 151, 189, 242, 115, 163, 92, 233, 235, 14, 101, 19, 225, 181, 210, 33, 124, 238, 166, 216, 235, 82, 169, 92, 194, 181, 220, 194 }, new byte[] { 33, 34, 153, 101, 201, 141, 86, 161, 204, 40, 238, 173, 112, 255, 29, 197, 140, 175, 7, 15, 0, 154, 174, 197, 112, 69, 16, 235, 151, 98, 135, 10, 31, 94, 154, 181, 115, 246, 132, 149, 50, 49, 203, 174, 201, 102, 143, 205, 22, 216, 193, 45, 136, 211, 49, 119, 80, 76, 131, 195, 182, 208, 163, 59, 181, 53, 8, 36, 254, 169, 54, 6, 188, 79, 153, 229, 107, 127, 123, 25, 67, 65, 186, 140, 87, 216, 185, 122, 28, 46, 244, 32, 33, 178, 138, 151, 197, 181, 55, 102, 3, 56, 218, 8, 52, 212, 115, 129, 31, 245, 100, 23, 83, 208, 45, 2, 82, 192, 73, 195, 130, 24, 40, 231, 150, 136, 102, 214 }, null, null });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "shop",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Title",
                schema: "sec",
                table: "Roles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "sec",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "sec",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "sec",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sec");
        }
    }
}
