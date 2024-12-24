using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSJPersonal.Migrations
{
    /// <inheritdoc />
    public partial class CreateBlog_24Dec24_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Bloger");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bloger",
                table: "Bloger",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bloger",
                table: "Bloger");

            migrationBuilder.RenameTable(
                name: "Bloger",
                newName: "Blog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogId");
        }
    }
}
