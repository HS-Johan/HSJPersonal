using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSJPersonal.Migrations
{
    /// <inheritdoc />
    public partial class Admin_25Dec24_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminFacebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminTwitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminLinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminInstagram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
