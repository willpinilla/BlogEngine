using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEngine.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NextDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_EditorId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "EditorId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_EditorId",
                table: "Posts",
                column: "EditorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_EditorId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "EditorId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_EditorId",
                table: "Posts",
                column: "EditorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
