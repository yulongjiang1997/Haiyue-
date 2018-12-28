using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.HYEF.Migrations
{
    public partial class updateTablexpenditure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Handler",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "HandlerId",
                table: "Purchases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HandlerId",
                table: "Expenditures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_HandlerId",
                table: "Purchases",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_HandlerId",
                table: "Expenditures",
                column: "HandlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Users_HandlerId",
                table: "Expenditures",
                column: "HandlerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_HandlerId",
                table: "Purchases",
                column: "HandlerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Users_HandlerId",
                table: "Expenditures");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_HandlerId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_HandlerId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_HandlerId",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "HandlerId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "HandlerId",
                table: "Expenditures");

            migrationBuilder.AddColumn<string>(
                name: "Handler",
                table: "Purchases",
                nullable: true);
        }
    }
}
