using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Interport_Amal.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedQuotationRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "ContainerType",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "QuotationNumber",
                table: "Quotation");

            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "RateSchedule",
                newName: "Rate40Ft");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "RateSchedule",
                newName: "Rate20Ft");

            migrationBuilder.RenameColumn(
                name: "ContainerType",
                table: "RateSchedule",
                newName: "ChargeType");

            migrationBuilder.AddColumn<string>(
                name: "ContainerType",
                table: "QuotationItem",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuotationRequestId",
                table: "Quotation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuotationRequestId1",
                table: "Quotation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuotationRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfContainers = table.Column<int>(type: "INTEGER", nullable: false),
                    GoodsType = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    NatureOfJob = table.Column<string>(type: "TEXT", nullable: false),
                    RequiresQuarantine = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequiresFumigation = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationRequest_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChargeType", "Rate40Ft" },
                values: new object[] { "Warf Booking Fee", 70.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "Lift on/Lift Off", 80.0m, 120.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "Fumigation", 220.0m, 280.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "LCL Delivery Depot", 400.0m, 500.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "Tailgate Inspection", 120.0m, 160.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "Storage Fee", 240.0m, 300.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "Facility Fee", 70.0m, 100.0m });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ChargeType", "Rate20Ft", "Rate40Ft" },
                values: new object[] { "Warf Inspection", 60.0m, 90.0m });

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_QuotationRequestId",
                table: "Quotation",
                column: "QuotationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_QuotationRequestId1",
                table: "Quotation",
                column: "QuotationRequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequest_CustomerId",
                table: "QuotationRequest",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_QuotationRequest_QuotationRequestId",
                table: "Quotation",
                column: "QuotationRequestId",
                principalTable: "QuotationRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_QuotationRequest_QuotationRequestId1",
                table: "Quotation",
                column: "QuotationRequestId1",
                principalTable: "QuotationRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_QuotationRequest_QuotationRequestId",
                table: "Quotation");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_QuotationRequest_QuotationRequestId1",
                table: "Quotation");

            migrationBuilder.DropTable(
                name: "QuotationRequest");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_QuotationRequestId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_QuotationRequestId1",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "ContainerType",
                table: "QuotationItem");

            migrationBuilder.DropColumn(
                name: "QuotationRequestId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "QuotationRequestId1",
                table: "Quotation");

            migrationBuilder.RenameColumn(
                name: "Rate40Ft",
                table: "RateSchedule",
                newName: "ServiceType");

            migrationBuilder.RenameColumn(
                name: "Rate20Ft",
                table: "RateSchedule",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "ChargeType",
                table: "RateSchedule",
                newName: "ContainerType");

            migrationBuilder.AddColumn<string>(
                name: "ContainerType",
                table: "Quotation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuotationNumber",
                table: "Quotation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContainerType", "ServiceType" },
                values: new object[] { "20 Feet Container", "Walf Booking fee" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "40 Feet Container", 70.0m, "Walf Booking fee" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "20 Feet Container", 80.0m, "Lift on/Lif Off" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "40 Feet Container", 120.0m, "Lift on/Lif Off" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "20 Feet Container", 220.0m, "Fumigation" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "40 Feet Container", 280.0m, "Fumigation" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "20 Feet Container", 400.0m, "LCL Delivery Depot" });

            migrationBuilder.UpdateData(
                table: "RateSchedule",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ContainerType", "Rate", "ServiceType" },
                values: new object[] { "40 Feet Container", 500.0m, "LCL Delivery Depot" });

            migrationBuilder.InsertData(
                table: "RateSchedule",
                columns: new[] { "Id", "ContainerType", "Rate", "ServiceType" },
                values: new object[,]
                {
                    { 9, "20 Feet Container", 120.0m, "Tailgate Inspection" },
                    { 10, "40 Feet Container", 160.0m, "Tailgate Inspection" },
                    { 11, "20 Feet Container", 240.0m, "Storage Fee" },
                    { 12, "40 Feet Container", 300.0m, "Storage Fee" },
                    { 13, "20 Feet Container", 70.0m, "Facility Fee" },
                    { 14, "40 Feet Container", 100.0m, "Facility Fee" },
                    { 15, "20 Feet Container", 60.0m, "Warf Inspection" },
                    { 16, "40 Feet Container", 90.0m, "Warf Inspection" }
                });
        }
    }
}
