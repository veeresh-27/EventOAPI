using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOAPI.Migrations
{
    /// <inheritdoc />
    public partial class removed_fk_tokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_InviteTokens_InviteTokenId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_InviteTokens_InviteTokenId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_InviteTokenId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Communities_InviteTokenId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "InviteTokenId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "InviteTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "InviteTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "InviteTokens");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "InviteTokens");

            migrationBuilder.AddColumn<int>(
                name: "InviteTokenId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_InviteTokenId",
                table: "Events",
                column: "InviteTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_InviteTokenId",
                table: "Communities",
                column: "InviteTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_InviteTokens_InviteTokenId",
                table: "Communities",
                column: "InviteTokenId",
                principalTable: "InviteTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_InviteTokens_InviteTokenId",
                table: "Events",
                column: "InviteTokenId",
                principalTable: "InviteTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
