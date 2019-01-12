using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskter.Infrastructure.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tacta" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarURL", "FirstName", "LastName", "Role", "UserName" },
                values: new object[] { 1, "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg", "Nermin", "Selim", "Administrator", "Nermin.Selim" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarURL", "FirstName", "LastName", "Role", "UserName" },
                values: new object[] { 2, "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg", "Selim", "Nermin", "User", "Selim.Nermin" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "Code", "Name" },
                values: new object[] { 1, 1, "TA10001", "Tracker" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "Code", "Name" },
                values: new object[] { 2, 1, "TA10002", "Tracker2" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Billable", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1, true, "Design", 1 },
                    { 2, true, "Implementation", 1 },
                    { 3, false, "Review", 1 },
                    { 4, true, "Marketing", 1 },
                    { 5, true, "UI", 2 },
                    { 6, true, "Backend", 2 },
                    { 7, true, "Deployment", 2 },
                    { 8, false, "Audit", 2 }
                });

            migrationBuilder.InsertData(
                table: "UsersProjects",
                columns: new[] { "UserId", "ProjectId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UsersProjects",
                keyColumns: new[] { "UserId", "ProjectId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UsersProjects",
                keyColumns: new[] { "UserId", "ProjectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
