using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Identity.Migrations
{
    public partial class IdentityInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LasName",
                table: "Address",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Address",
                newName: "LasName");
        }
    }
}
