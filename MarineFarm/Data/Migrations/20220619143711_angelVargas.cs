using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    public partial class angelVargas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e20113c-7fef-4c00-90b7-c286fba79757", 0, "97ce2397-bea6-4c06-a5ab-5f6122abe297", "comercial.granjamar@gmail.com", true, false, null, "COMERCIAL.GRANJAMAR@GMAIL.COM", "COMERCIAL.GRANJAMAR@GMAIL.COM", "AQAAAAEAACcQAAAAEEe4xhHUnJjaVDKlS/pyU1UxOlz0HSGuNBGWcvXCWqwODNz9YymNZIgt0PBDltp4Ug==", "+56 9 9842 9393", true, "99e4c801-b3f9-432b-8640-8d8c7f9c3b01", false, "comercial.granjamar@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "1e20113c-7fef-4c00-90b7-c286fba79757" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e20113c-7fef-4c00-90b7-c286fba79757");

        }
    }
}
