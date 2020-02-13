using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class minorupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                column: "Created",
                value: new DateTime(2020, 2, 13, 16, 52, 0, 419, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TypeId",
                table: "Bookings",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingTypes_TypeId",
                table: "Bookings",
                column: "TypeId",
                principalTable: "BookingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingTypes_TypeId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TypeId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                column: "Created",
                value: new DateTime(2020, 2, 13, 13, 42, 45, 759, DateTimeKind.Local).AddTicks(4297));
        }
    }
}
