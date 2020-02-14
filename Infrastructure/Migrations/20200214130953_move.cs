using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class move : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeam_Student_StudentId",
                table: "StudentTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                column: "Created",
                value: new DateTime(2020, 2, 14, 14, 9, 53, 200, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CalendarId",
                table: "Teams",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StudentId",
                table: "Bookings",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Students_StudentId",
                table: "Bookings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeam_Students_StudentId",
                table: "StudentTeam",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Calendars_CalendarId",
                table: "Teams",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Students_StudentId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeam_Students_StudentId",
                table: "StudentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Calendars_CalendarId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CalendarId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StudentId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                column: "Created",
                value: new DateTime(2020, 2, 13, 17, 26, 49, 30, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeam_Student_StudentId",
                table: "StudentTeam",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
