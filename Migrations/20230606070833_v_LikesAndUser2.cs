using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOAPI.Migrations
{
    /// <inheritdoc />
    public partial class v_LikesAndUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Like",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_EventId",
                table: "Like",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Events_EventId",
                table: "Like",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Events_EventId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_EventId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Like");
        }
    }
}
