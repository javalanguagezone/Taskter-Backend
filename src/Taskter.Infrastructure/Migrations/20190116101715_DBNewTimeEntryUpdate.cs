using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskter.Infrastructure.Migrations
{
    public partial class DBNewTimeEntryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 1, 16, 11, 17, 14, 957, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 1, 16, 11, 17, 14, 960, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 1, 16, 11, 17, 14, 960, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2019, 1, 16, 11, 17, 14, 960, DateTimeKind.Local).AddTicks(8066));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 1, 15, 15, 30, 25, 952, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 1, 15, 15, 30, 25, 957, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 1, 15, 15, 30, 25, 957, DateTimeKind.Local).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "ProjectTaskEntres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2019, 1, 15, 15, 30, 25, 957, DateTimeKind.Local).AddTicks(6758));
        }
    }
}
