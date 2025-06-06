using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Interport_Amal.Migrations
{
    /// <inheritdoc />
    public partial class SeedRateSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuotationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContainerType = table.Column<string>(type: "TEXT", nullable: false),
                    ScopeDescription = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCharge = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotation_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceType = table.Column<string>(type: "TEXT", nullable: false),
                    ContainerType = table.Column<string>(type: "TEXT", nullable: false),
                    Rate = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuotationItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuotationId = table.Column<int>(type: "INTEGER", nullable: false),
                    RateScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationItem_Quotation_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationItem_RateSchedule_RateScheduleId",
                        column: x => x.RateScheduleId,
                        principalTable: "RateSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RateSchedule",
                columns: new[] { "Id", "ContainerType", "Rate", "ServiceType" },
                values: new object[,]
                {
                    { 1, "20 Feet Container", 60.0m, "Walf Booking fee" },
                    { 2, "40 Feet Container", 70.0m, "Walf Booking fee" },
                    { 3, "20 Feet Container", 80.0m, "Lift on/Lif Off" },
                    { 4, "40 Feet Container", 120.0m, "Lift on/Lif Off" },
                    { 5, "20 Feet Container", 220.0m, "Fumigation" },
                    { 6, "40 Feet Container", 280.0m, "Fumigation" },
                    { 7, "20 Feet Container", 400.0m, "LCL Delivery Depot" },
                    { 8, "40 Feet Container", 500.0m, "LCL Delivery Depot" },
                    { 9, "20 Feet Container", 120.0m, "Tailgate Inspection" },
                    { 10, "40 Feet Container", 160.0m, "Tailgate Inspection" },
                    { 11, "20 Feet Container", 240.0m, "Storage Fee" },
                    { 12, "40 Feet Container", 300.0m, "Storage Fee" },
                    { 13, "20 Feet Container", 70.0m, "Facility Fee" },
                    { 14, "40 Feet Container", 100.0m, "Facility Fee" },
                    { 15, "20 Feet Container", 60.0m, "Warf Inspection" },
                    { 16, "40 Feet Container", 90.0m, "Warf Inspection" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_CustomerId",
                table: "Quotation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItem_QuotationId",
                table: "QuotationItem",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItem_RateScheduleId",
                table: "QuotationItem",
                column: "RateScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "QuotationItem");

            migrationBuilder.DropTable(
                name: "Quotation");

            migrationBuilder.DropTable(
                name: "RateSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
