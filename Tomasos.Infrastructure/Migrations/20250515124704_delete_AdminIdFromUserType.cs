using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomasos_Pizzeria.Data.Migrations
{
    /// <inheritdoc />
    public partial class delete_AdminIdFromUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Admins_AdminId",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_AdminId",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "UserTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "UserTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_AdminId",
                table: "UserTypes",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Admins_AdminId",
                table: "UserTypes",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
