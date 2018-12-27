using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.HYEF.Migrations
{
    public partial class UpdatePurchaseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Games_GameId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CurrencyId",
                table: "Purchases",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Currencys_CurrencyId",
                table: "Purchases",
                column: "CurrencyId",
                principalTable: "Currencys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Games_GameId",
                table: "Purchases",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Currencys_CurrencyId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Games_GameId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CurrencyId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Games_GameId",
                table: "Purchases",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
