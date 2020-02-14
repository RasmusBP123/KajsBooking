using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9701f2b5-cd53-442b-b911-622c4c1b22c4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c22c6fe2-9d2a-4f14-bfb9-3ea1faec803c");

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a14280f8-d2b9-4598-8c89-c699cd1ab278"),
                columns: new[] { "PasswordHash", "UserName" },
                values: new object[] { "AQAAAAEAACcQAAAAEPRns0oTD754Ri6Lw3jp3xiLltiToqMO17mDevWf8eEiICV9O0t9X1QwWITQig71Hw==", "Rasmus Bak Petersen" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5528e66f-ec78-4e9c-9cfd-f3130a654baa", "61d3eb78-9bd4-4f1d-8cbc-70f1a6fd952f", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2184a200-270a-4661-90bf-00d2cc7ee2a4", "d921c629-b6fd-4fe4-9668-d069698dbbcf", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2184a200-270a-4661-90bf-00d2cc7ee2a4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5528e66f-ec78-4e9c-9cfd-f3130a654baa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a14280f8-d2b9-4598-8c89-c699cd1ab278"),
                columns: new[] { "PasswordHash", "UserName" },
                values: new object[] { "AQAAAAEAACcQAAAAEAE/RcW6NhsD1ISJxt2e4VU0EaY2OYAqwvl0j19pm8FDzYI/zU6ImLb5EEKruVGJ8A==", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c22c6fe2-9d2a-4f14-bfb9-3ea1faec803c", "5eecc01a-c6ce-4616-af99-26d3b0ae6e2a", "Student", "STUDENT" },
                    { "9701f2b5-cd53-442b-b911-622c4c1b22c4", "e7cbc5b1-b0ba-4f4f-a83f-d9be166f0387", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[] { new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"), new DateTime(2020, 2, 14, 21, 27, 50, 280, DateTimeKind.Local).AddTicks(1637), "Me", null, null, "Do Dished" });
        }
    }
}
