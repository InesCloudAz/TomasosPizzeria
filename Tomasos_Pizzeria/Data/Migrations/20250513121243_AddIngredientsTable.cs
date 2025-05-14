using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomasos_Pizzeria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsList = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_IngredientsId",
                table: "Dishes",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Ingredients_IngredientsId",
                table: "Dishes",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "IngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Ingredients_IngredientsId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_IngredientsId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Dishes");
        }
    }
}
