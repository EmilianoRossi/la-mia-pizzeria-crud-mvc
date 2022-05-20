using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaWebApp.Migrations
{
    public partial class CategoriaDeleteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categoria_categoriaid",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorie");

            migrationBuilder.RenameColumn(
                name: "categoriaid",
                table: "Pizzas",
                newName: "Categoriaid");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_categoriaid",
                table: "Pizzas",
                newName: "IX_Pizzas_Categoriaid");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Pizzas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categorie_Categoriaid",
                table: "Pizzas",
                column: "Categoriaid",
                principalTable: "Categorie",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categorie_Categoriaid",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "Categoriaid",
                table: "Pizzas",
                newName: "categoriaid");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_Categoriaid",
                table: "Pizzas",
                newName: "IX_Pizzas_categoriaid");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categoria_categoriaid",
                table: "Pizzas",
                column: "categoriaid",
                principalTable: "Categoria",
                principalColumn: "id");
        }
    }
}
