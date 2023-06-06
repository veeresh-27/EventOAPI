using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOAPI.Migrations
{
    /// <inheritdoc />
    public partial class v_LikesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Like",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");
        }
    }
}
