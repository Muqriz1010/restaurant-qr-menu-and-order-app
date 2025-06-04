using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaiterCat.Migrations
{
    /// <inheritdoc />
    public partial class AddMerchantIdToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MerchantId",
                table: "Orders",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Merchants_MerchantId",
                table: "Orders",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Merchants_MerchantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MerchantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Orders");
        }
    }
}
