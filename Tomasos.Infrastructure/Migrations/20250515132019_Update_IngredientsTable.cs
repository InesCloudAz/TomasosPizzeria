using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomasos_Pizzeria.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_IngredientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Ingredients",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Ingredients");
        }
    }
}
