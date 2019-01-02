using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.HYEF.Migrations
{
    public partial class Updatetable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtherTime",
                table: "Refunds",
                newName: "RefundTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefundTime",
                table: "Refunds",
                newName: "OtherTime");
        }
    }
}
