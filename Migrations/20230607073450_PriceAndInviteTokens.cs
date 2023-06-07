using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOAPI.Migrations
{
    /// <inheritdoc />
    public partial class PriceAndInviteTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Spaces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "InviteTokenId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "InviteTokenId",
                table: "Communities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Communities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "InviteTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InviteTokens", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_InviteTokens_InviteTokenId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_InviteTokens_InviteTokenId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "InviteTokens");

            migrationBuilder.DropIndex(
                name: "IX_Events_InviteTokenId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Communities_InviteTokenId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Spaces");

            migrationBuilder.DropColumn(
                name: "InviteTokenId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "InviteTokenId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Communities");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }
    }
}
