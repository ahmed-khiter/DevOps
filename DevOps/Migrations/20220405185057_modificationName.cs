using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOps.Migrations
{
    public partial class modificationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StripeKey",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastNamed",
                table: "ContactUs",
                newName: "LastName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b866506a-8120-4608-afeb-3d648b2a2053", "0b62e972-da06-40e2-9ff3-a71e05d690dc", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5dca0a08-698c-4ea7-a9e8-b0ddd6ed164b", "91cbdcb7-44fc-4d0a-8049-ad1c87098c72", "Consumer", "Consumer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "40ce2966-bb41-47e7-9595-06edda5d29fc", 0, 0, null, "6eca78ce-aa05-47bd-bcd3-3eedac41e560", "admin@admin.com", true, "admin", "Ahmed Khaled", "admin", false, null, null, null, "iFcwmKqEAyjqvMlqmPQ/JCtnRTy7wGDQUaxuaH8+pFA=", "+201100811024", false, "98c3f6a6-433a-4716-8c88-85f390214b02", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b866506a-8120-4608-afeb-3d648b2a2053", "40ce2966-bb41-47e7-9595-06edda5d29fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dca0a08-698c-4ea7-a9e8-b0ddd6ed164b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b866506a-8120-4608-afeb-3d648b2a2053", "40ce2966-bb41-47e7-9595-06edda5d29fc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b866506a-8120-4608-afeb-3d648b2a2053");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40ce2966-bb41-47e7-9595-06edda5d29fc");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ContactUs",
                newName: "LastNamed");

            migrationBuilder.AddColumn<string>(
                name: "StripeKey",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
