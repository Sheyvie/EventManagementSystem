using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class EventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_usersId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "usersId",
                table: "Events",
                newName: "usersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_usersId",
                table: "Events",
                newName: "IX_Events_usersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_usersUserId",
                table: "Events",
                column: "usersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_usersUserId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usersUserId",
                table: "Events",
                newName: "usersId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_usersUserId",
                table: "Events",
                newName: "IX_Events_usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_usersId",
                table: "Events",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
