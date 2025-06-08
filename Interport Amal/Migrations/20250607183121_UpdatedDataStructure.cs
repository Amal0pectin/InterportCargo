using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interport_Amal.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_QuotationRequest_QuotationRequestId1",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_QuotationRequestId1",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "QuotationRequestId1",
                table: "Quotation");

            migrationBuilder.RenameColumn(
                name: "NumberOfContainers",
                table: "QuotationRequest",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "GoodsType",
                table: "QuotationRequest",
                newName: "PackageType");

            migrationBuilder.AddColumn<int>(
                name: "ContainerCount",
                table: "QuotationRequest",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "QuotationRequest",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubmitted",
                table: "QuotationRequest",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "QuotationRequest",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "QuotationItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContainerCount",
                table: "QuotationRequest");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "QuotationRequest");

            migrationBuilder.DropColumn(
                name: "DateSubmitted",
                table: "QuotationRequest");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "QuotationRequest");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "QuotationItem");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "QuotationRequest",
                newName: "NumberOfContainers");

            migrationBuilder.RenameColumn(
                name: "PackageType",
                table: "QuotationRequest",
                newName: "GoodsType");

            migrationBuilder.AddColumn<int>(
                name: "QuotationRequestId1",
                table: "Quotation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_QuotationRequestId1",
                table: "Quotation",
                column: "QuotationRequestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_QuotationRequest_QuotationRequestId1",
                table: "Quotation",
                column: "QuotationRequestId1",
                principalTable: "QuotationRequest",
                principalColumn: "Id");
        }
    }
}
