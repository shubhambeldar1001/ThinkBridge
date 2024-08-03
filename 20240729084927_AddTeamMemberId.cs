using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagementSystem.Migrations
{
    public partial class AddTeamMemberId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_Tasks_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_Tasks_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Teams_TeamId",
                table: "TeamMember");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Users_UserId",
                table: "TeamMember");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TeamMember");

            migrationBuilder.RenameTable(
                name: "TeamMember",
                newName: "TeamMembers");

            migrationBuilder.AddColumn<int>(
                name: "TeamMemberId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "TeamMembers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "TeamMemberId");

            migrationBuilder.CreateTable(
                name: "TaskOffices",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CreatedUserUserId = table.Column<int>(nullable: true),
                    AssignedUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskOffices", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskOffices_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskOffices_Users_CreatedUserUserId",
                        column: x => x.CreatedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamMemberId",
                table: "Users",
                column: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskOffices_AssignedUserId",
                table: "TaskOffices",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskOffices_CreatedUserUserId",
                table: "TaskOffices",
                column: "CreatedUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_TaskOffices_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "TaskOffices",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_TaskOffices_TaskId",
                table: "TaskNotes",
                column: "TaskId",
                principalTable: "TaskOffices",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TeamMembers_TeamMemberId",
                table: "Users",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "TeamMemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_TaskOffices_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_TaskOffices_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TeamMembers_TeamMemberId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TaskOffices");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamMemberId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "TeamMembers");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "TeamMember");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TeamMember",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "TeamMemberId");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    AssignedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedUserUserId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_CreatedUserUserId",
                        column: x => x.CreatedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMember",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedUserId",
                table: "Tasks",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedUserUserId",
                table: "Tasks",
                column: "CreatedUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_Tasks_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_Tasks_TaskId",
                table: "TaskNotes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Teams_TeamId",
                table: "TeamMember",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Users_UserId",
                table: "TeamMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
