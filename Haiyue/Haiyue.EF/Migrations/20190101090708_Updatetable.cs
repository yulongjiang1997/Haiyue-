using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.HYEF.Migrations
{
    public partial class Updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "ActualRefund",
                table: "OtherOrders");

            migrationBuilder.DropColumn(
                name: "GmaeOrGiftCard",
                table: "OtherOrders");

            migrationBuilder.DropColumn(
                name: "RefundAmount",
                table: "OtherOrders");

            migrationBuilder.DropColumn(
                name: "RefundStatus",
                table: "OtherOrders");

            migrationBuilder.RenameColumn(
                name: "TotalExpenditure",
                table: "Refunds",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "Refunds",
                newName: "OtherTime");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "OtherOrders",
                newName: "TotalExpenditure");

            migrationBuilder.RenameColumn(
                name: "OtherTime",
                table: "OtherOrders",
                newName: "OrderTime");

            migrationBuilder.AddColumn<double>(
                name: "ActualRefund",
                table: "Refunds",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "GmaeOrGiftCard",
                table: "Refunds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RefundAmount",
                table: "Refunds",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RefundStatus",
                table: "Refunds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "OtherOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualRefund",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "GmaeOrGiftCard",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "RefundAmount",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "RefundStatus",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "OtherOrders");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "Refunds",
                newName: "TotalExpenditure");

            migrationBuilder.RenameColumn(
                name: "OtherTime",
                table: "Refunds",
                newName: "OrderTime");

            migrationBuilder.RenameColumn(
                name: "TotalExpenditure",
                table: "OtherOrders",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "OtherOrders",
                newName: "OtherTime");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Refunds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ActualRefund",
                table: "OtherOrders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "GmaeOrGiftCard",
                table: "OtherOrders",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RefundAmount",
                table: "OtherOrders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RefundStatus",
                table: "OtherOrders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
