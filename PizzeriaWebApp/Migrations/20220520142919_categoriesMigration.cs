using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaWebApp.Migrations
{
    public partial class categoriesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categorie_CategoriaId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Pizzas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categorie_CategoriaId",
                table: "Pizzas",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categorie_CategoriaId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categorie_CategoriaId",
                table: "Pizzas",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
