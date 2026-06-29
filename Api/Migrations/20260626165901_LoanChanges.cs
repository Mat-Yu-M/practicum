using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class LoanChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approved_date",
                table: "loan_requests");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "loans",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "approved_date",
                table: "loans",
                newName: "approved_date_time");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "loan_requests",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "approved_by",
                table: "loan_requests",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "loan_products",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "loan_product_requests",
                newName: "created_date_time");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "loans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "approved_by",
                table: "loan_products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "approved_date_time",
                table: "loan_products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "loan_products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "loan_product_requests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "approved_by",
                table: "loan_products");

            migrationBuilder.DropColumn(
                name: "approved_date_time",
                table: "loan_products");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "loan_products");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "loan_product_requests");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "loans",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "approved_date_time",
                table: "loans",
                newName: "approved_date");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "loan_requests",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "loan_requests",
                newName: "approved_by");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "loan_products",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "loan_product_requests",
                newName: "created_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "approved_date",
                table: "loan_requests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
