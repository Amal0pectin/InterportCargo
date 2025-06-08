using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interport_Amal.Migrations
{
    /// <inheritdoc />
    public partial class RateScheduleUpdaated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "QuotationItem");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Quotation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quotation");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "QuotationItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
