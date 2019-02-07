using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskter.Infrastructure.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dummies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dummies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    AvatarURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(maxLength: 15, nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Billable = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProjects",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UsersProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectTaskId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DurationInMin = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTaskEntries_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTaskEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tacta" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarURL", "FirstName", "LastName", "Role", "UserName" },
                values: new object[] { 1, "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg", "Nermin", "Milisic", "Domar", "nermin.milisic" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarURL", "FirstName", "LastName", "Role", "UserName" },
                values: new object[] { 2, "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg", "Selim", "Huskic", "Kotlovnicar", "selim.huskic" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "Code", "Name" },
                values: new object[] { 1, 1, "OU742", "Tracker" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "Code", "Name" },
                values: new object[] { 2, 1, "MOL001", "Moleraj" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Billable", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1, true, "Development", 1 },
                    { 2, true, "Review", 1 },
                    { 3, false, "Marketing", 1 },
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
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTaskEntries",
                columns: new[] { "Id", "Date", "DurationInMin", "Note", "ProjectTaskId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 2, 7, 10, 56, 12, 308, DateTimeKind.Local).AddTicks(5387), 30, " Lorem ipsum dolor sit amet", 1, 1 },
                    { 2, new DateTime(2019, 2, 7, 10, 56, 12, 314, DateTimeKind.Local).AddTicks(8160), 90, " Lorem ipsum dolor sit amet", 2, 1 },
                    { 3, new DateTime(2019, 2, 7, 10, 56, 12, 314, DateTimeKind.Local).AddTicks(8306), 60, " Lorem ipsum dolor sit amet", 3, 1 },
                    { 4, new DateTime(2019, 2, 7, 10, 56, 12, 314, DateTimeKind.Local).AddTicks(8325), 90, " Lorem ipsum dolor sit amet", 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskEntries_ProjectTaskId",
                table: "ProjectTaskEntries",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskEntries_UserId",
                table: "ProjectTaskEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProjects_ProjectId",
                table: "UsersProjects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dummies");

            migrationBuilder.DropTable(
                name: "ProjectTaskEntries");

            migrationBuilder.DropTable(
                name: "UsersProjects");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
