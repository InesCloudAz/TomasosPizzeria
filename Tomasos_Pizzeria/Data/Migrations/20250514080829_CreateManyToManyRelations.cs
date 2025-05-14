using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomasos_Pizzeria.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateManyToManyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dishes_DishesDishId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrdersOrderId",
                table: "DishOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.RenameTable(
                name: "DishOrder",
                newName: "OrderDishes");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_OrdersOrderId",
                table: "OrderDishes",
                newName: "IX_OrderDishes_OrdersOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDishes",
                table: "OrderDishes",
                columns: new[] { "DishesDishId", "OrdersOrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Dishes_DishesDishId",
                table: "OrderDishes",
                column: "DishesDishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Orders_OrdersOrderId",
                table: "OrderDishes",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Dishes_DishesDishId",
                table: "OrderDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Orders_OrdersOrderId",
                table: "OrderDishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDishes",
                table: "OrderDishes");

            migrationBuilder.RenameTable(
                name: "OrderDishes",
                newName: "DishOrder");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDishes_OrdersOrderId",
                table: "DishOrder",
                newName: "IX_DishOrder_OrdersOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                columns: new[] { "DishesDishId", "OrdersOrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dishes_DishesDishId",
                table: "DishOrder",
                column: "DishesDishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrdersOrderId",
                table: "DishOrder",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
