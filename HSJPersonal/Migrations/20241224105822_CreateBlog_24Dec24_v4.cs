using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSJPersonal.Migrations
{
    /// <inheritdoc />
    public partial class CreateBlog_24Dec24_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog2",
                table: "Blog2");

            migrationBuilder.RenameTable(
                name: "Blog2",
                newName: "Blog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blog2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog2",
                table: "Blog2",
                column: "BlogId");
        }
    }
}
