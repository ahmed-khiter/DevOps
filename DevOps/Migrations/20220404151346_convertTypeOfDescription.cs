using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOps.Migrations
{
    public partial class convertTypeOfDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Detatils",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ba7089d-fa2f-4315-9aa2-0317d46ed379", "d063e2cf-384e-4b43-8cd2-67939a1fc421", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0169102e-4bd0-462c-910d-eda934ee4056", "da6cd4e1-caf9-40dc-920c-8f76ab94bf13", "Consumer", "Consumer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StripeKey", "TwoFactorEnabled", "UserName" },
                values: new object[] { "67660c7c-e70a-4176-a9fd-2d492435cd60", 0, 0, null, "993213f4-c41e-4a02-baa5-3b646d62779e", "admin@admin.com", true, "admin", "Ahmed Khaled", "admin", false, null, null, null, "iFcwmKqEAyjqvMlqmPQ/JCtnRTy7wGDQUaxuaH8+pFA=", "+201100811024", false, "aca76c3e-7b59-4abd-8507-cd7d37e96943", null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ba7089d-fa2f-4315-9aa2-0317d46ed379", "67660c7c-e70a-4176-a9fd-2d492435cd60" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0169102e-4bd0-462c-910d-eda934ee4056");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ba7089d-fa2f-4315-9aa2-0317d46ed379", "67660c7c-e70a-4176-a9fd-2d492435cd60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ba7089d-fa2f-4315-9aa2-0317d46ed379");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67660c7c-e70a-4176-a9fd-2d492435cd60");

            migrationBuilder.AlterColumn<int>(
                name: "Detatils",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
