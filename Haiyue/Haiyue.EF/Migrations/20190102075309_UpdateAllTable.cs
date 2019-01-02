using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.HYEF.Migrations
{
    public partial class UpdateAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "TaskStatusLogss");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "TaskLists");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "TaskChangeLogss");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "OtherOrders");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "NoteBooks");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "LoginInfos");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "LeaveAMessages");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "LeaveAMessageReplys");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "ExpenditureTypes");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "LastUpTime",
                table: "Currencys");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Users",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "TaskStatusLogss",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsHave",
                table: "TaskLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "TaskLists",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "TaskChangeLogss",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Refunds",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Purchases",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Positions",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "OtherOrders",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "NoteBooks",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "LoginInfos",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "LeaveAMessages",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "LeaveAMessageReplys",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Games",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "ExpenditureTypes",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Expenditures",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Department",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpDateTime",
                table: "Currencys",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "TaskStatusLogss");

            migrationBuilder.DropColumn(
                name: "IsHave",
                table: "TaskLists");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "TaskLists");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "TaskChangeLogss");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "OtherOrders");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "NoteBooks");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "LoginInfos");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "LeaveAMessages");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "LeaveAMessageReplys");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "ExpenditureTypes");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "LastUpDateTime",
                table: "Currencys");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Users",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "TaskStatusLogss",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "TaskLists",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "TaskChangeLogss",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Refunds",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Purchases",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Positions",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "OtherOrders",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "NoteBooks",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "LoginInfos",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "LeaveAMessages",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "LeaveAMessageReplys",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Games",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "ExpenditureTypes",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Expenditures",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Department",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpTime",
                table: "Currencys",
                maxLength: 30,
                nullable: true);
        }
    }
}
