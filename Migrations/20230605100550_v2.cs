using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOAPI.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpaceSapaceId",
                table: "EventTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventTable_SpaceSapaceId",
                table: "EventTable",
                column: "SpaceSapaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTable_SpaceTable_SpaceSapaceId",
                table: "EventTable",
                column: "SpaceSapaceId",
                principalTable: "SpaceTable",
                principalColumn: "SapaceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTable_SpaceTable_SpaceSapaceId",
                table: "EventTable");

            migrationBuilder.DropIndex(
                name: "IX_EventTable_SpaceSapaceId",
                table: "EventTable");

            migrationBuilder.DropColumn(
                name: "SpaceSapaceId",
                table: "EventTable");
        }
    }
}
