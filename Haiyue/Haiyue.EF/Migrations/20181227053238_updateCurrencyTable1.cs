using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.EF.Migrations
{
    public partial class updateCurrencyTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Purchases_GameId",
                table: "Purchases",
                column: "GameId");

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
                name: "FK_Purchases_Games_GameId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_GameId",
                table: "Purchases");
        }
    }
}
