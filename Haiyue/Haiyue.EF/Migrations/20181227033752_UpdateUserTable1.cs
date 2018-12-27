using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haiyue.EF.Migrations
{
    public partial class UpdateUserTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true),
                    ServerName = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    TotalNumber = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    RealIncome = table.Column<double>(nullable: false),
                    RealIncomeRMB = table.Column<double>(nullable: false),
                    SupplierPhone = table.Column<string>(nullable: true),
                    PaymentAccount = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Handler = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PassWored = table.Column<string>(nullable: true),
                    Jurisdiction = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    JobNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RegisteredResidence = table.Column<string>(nullable: true),
                    Education = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    IncumbencyStatus = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencys");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
