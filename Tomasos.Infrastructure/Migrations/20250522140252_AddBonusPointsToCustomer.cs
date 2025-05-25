using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomasos_Pizzeria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBonusPointsToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BonusPoints",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusPoints",
                table: "Customers");
        }
    }
}
