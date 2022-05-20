using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaWebApp.Migrations
{
    public partial class Categoria8Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categorie_Categoriaid",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "Categoriaid",
                table: "Pizzas",
                newName: "categoriaid");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_Categoriaid",
                table: "Pizzas",
                newName: "IX_Pizzas_categoriaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categorie_categoriaid",
                table: "Pizzas",
                column: "categoriaid",
                principalTable: "Categorie",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categorie_categoriaid",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "categoriaid",
                table: "Pizzas",
                newName: "Categoriaid");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_categoriaid",
                table: "Pizzas",
                newName: "IX_Pizzas_Categoriaid");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categorie_Categoriaid",
                table: "Pizzas",
                column: "Categoriaid",
                principalTable: "Categorie",
                principalColumn: "id");
        }
    }
}
