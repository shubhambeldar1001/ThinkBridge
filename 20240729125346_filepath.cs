using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagementSystem.Migrations
{
    public partial class filepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_TaskOffices_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_Users_UserId",
                table: "TaskNotes");

            migrationBuilder.DropTable(
                name: "TaskAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskNotes",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_TaskNotes_UserId",
                table: "TaskNotes");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "TaskOffices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskOffices");

            migrationBuilder.RenameTable(
                name: "TaskNotes",
                newName: "TaskNote");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "TaskOffices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteContent",
                table: "TaskOffices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedAt",
                table: "TaskOffices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskNote",
                table: "TaskNote",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskNote",
                table: "TaskNote");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "TaskOffices");

            migrationBuilder.DropColumn(
                name: "NoteContent",
                table: "TaskOffices");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "TaskOffices");

            migrationBuilder.RenameTable(
                name: "TaskNote",
                newName: "TaskNotes");

            migrationBuilder.AddColumn<int>(
                name: "AssignedTo",
                table: "TaskOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "TaskOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskNotes",
                table: "TaskNotes",
                column: "NoteId");

            migrationBuilder.CreateTable(
                name: "TaskAttachments",
                columns: table => new
                {
                    TaskAttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    UploadedUserUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAttachments", x => x.TaskAttachmentId);
                    table.ForeignKey(
                        name: "FK_TaskAttachments_TaskOffices_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskOffices",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAttachments_Users_UploadedUserUserId",
                        column: x => x.UploadedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_UserId",
                table: "TaskNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_TaskId",
                table: "TaskAttachments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_UploadedUserUserId",
                table: "TaskAttachments",
                column: "UploadedUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_TaskOffices_TaskId",
                table: "TaskNotes",
                column: "TaskId",
                principalTable: "TaskOffices",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_Users_UserId",
                table: "TaskNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
