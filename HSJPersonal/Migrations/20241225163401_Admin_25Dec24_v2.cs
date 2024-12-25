using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSJPersonal.Migrations
{
    /// <inheritdoc />
    public partial class Admin_25Dec24_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminAboutUs",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminAboutUs",
                table: "Admin");
        }
    }
}
