using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class work : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                column: "Created",
                value: new DateTime(2020, 2, 14, 14, 14, 27, 831, DateTimeKind.Local).AddTicks(8122));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                column: "Created",
                value: new DateTime(2020, 2, 14, 14, 9, 53, 200, DateTimeKind.Local).AddTicks(2331));
        }
    }
}
