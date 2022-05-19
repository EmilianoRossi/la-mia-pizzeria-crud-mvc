using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaWebApp.Migrations
{
    public partial class QuartaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Utenti",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Utenti",
                newName: "Id");
        }
    }
}
