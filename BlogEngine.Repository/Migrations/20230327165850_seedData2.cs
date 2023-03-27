using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEngine.Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreationDate", "Description", "EditorComments", "EditorId", "RevisionDate", "Status", "Title", "WriterId" },
                values: new object[] { 1, new DateTime(2023, 3, 27, 11, 58, 50, 80, DateTimeKind.Local).AddTicks(5462), "This is the first post", null, null, null, "PENDING APPROVAL", "First Post", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "ProfileId", "UserName", "UserPassword" },
                values: new object[] { "public@blogengine.com", "public", 1, "public", "public" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "UserName", "UserPassword" },
                values: new object[] { "writer@blogengine.com", "writer", "writer", "writer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "ProfileId", "UserName", "UserPassword" },
                values: new object[] { 3, "editor@blogengine.com", "editor", 3, "editor", "editor" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreationDate", "Description", "EditorComments", "EditorId", "RevisionDate", "Status", "Title", "WriterId" },
                values: new object[] { 2, new DateTime(2023, 3, 27, 11, 58, 50, 80, DateTimeKind.Local).AddTicks(5472), "This is a published post", "Good job", 3, new DateTime(2023, 3, 27, 11, 58, 50, 80, DateTimeKind.Local).AddTicks(5473), "APPROVED", "Post Completed", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreationDate", "Description", "PostId" },
                values: new object[] { 1, new DateTime(2023, 3, 27, 11, 58, 50, 80, DateTimeKind.Local).AddTicks(5487), "Nice blog!", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "ProfileId", "UserName", "UserPassword" },
                values: new object[] { "writer@blogengine.com", "writer", 2, "writer", "writer" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "UserName", "UserPassword" },
                values: new object[] { "editor@blogengine.com", "editor", "editor", "" });
        }
    }
}
