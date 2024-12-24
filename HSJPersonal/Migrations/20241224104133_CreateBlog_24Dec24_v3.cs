using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSJPersonal.Migrations
{
    /// <inheritdoc />
    public partial class CreateBlog_24Dec24_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bloger",
                table: "Bloger");

            migrationBuilder.RenameTable(
                name: "Bloger",
                newName: "Blog2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog2",
                table: "Blog2",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog2",
                table: "Blog2");

            migrationBuilder.RenameTable(
                name: "Blog2",
                newName: "Bloger");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bloger",
                table: "Bloger",
                column: "BlogId");
        }
    }
}
