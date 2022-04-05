using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOps.Migrations
{
    public partial class addIsReadToContactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f892adf5-6e38-4ec7-b8a7-c613be61316a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53c7ec8e-9783-4994-a590-901ac130e0b1", "a8541072-b973-4125-9d36-5d69d1d72ec8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53c7ec8e-9783-4994-a590-901ac130e0b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8541072-b973-4125-9d36-5d69d1d72ec8");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9369851b-b9f0-4ec0-bcce-0fa4f848a8b7", "c41e35eb-f32d-481e-80bc-5b5cd9c2e24a", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65601067-331a-4c3d-8177-6e6475ab5bf3", "7132d22f-a87d-4655-a315-0ec31dc7eb15", "Consumer", "Consumer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StripeKey", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f70cee58-0120-4600-8a19-2eb1c221884d", 0, 0, null, "50454b34-2647-4fc1-85fb-710763196e03", "admin@admin.com", true, "admin", "Ahmed Khaled", "admin", false, null, null, null, "iFcwmKqEAyjqvMlqmPQ/JCtnRTy7wGDQUaxuaH8+pFA=", "+201100811024", false, "9d6ba2fb-3383-458f-80ca-b6b818091a90", null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9369851b-b9f0-4ec0-bcce-0fa4f848a8b7", "f70cee58-0120-4600-8a19-2eb1c221884d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65601067-331a-4c3d-8177-6e6475ab5bf3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9369851b-b9f0-4ec0-bcce-0fa4f848a8b7", "f70cee58-0120-4600-8a19-2eb1c221884d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9369851b-b9f0-4ec0-bcce-0fa4f848a8b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f70cee58-0120-4600-8a19-2eb1c221884d");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ContactUs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53c7ec8e-9783-4994-a590-901ac130e0b1", "4c02824e-40a1-46f9-8738-75dd02ebb286", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f892adf5-6e38-4ec7-b8a7-c613be61316a", "4806e0ad-5aac-41ef-bf3c-4eaabfdb20aa", "Consumer", "Consumer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StripeKey", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a8541072-b973-4125-9d36-5d69d1d72ec8", 0, 0, null, "986ff695-fe18-4024-b3bc-0759c21aefa2", "admin@admin.com", true, "admin", "Ahmed Khaled", "admin", false, null, null, null, "iFcwmKqEAyjqvMlqmPQ/JCtnRTy7wGDQUaxuaH8+pFA=", "+201100811024", false, "6733d660-6ad4-46fe-b7f6-d346d86f8047", null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53c7ec8e-9783-4994-a590-901ac130e0b1", "a8541072-b973-4125-9d36-5d69d1d72ec8" });
        }
    }
}
