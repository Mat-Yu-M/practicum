using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class KycCustomerReconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maximum_monthly_salary",
                table: "kyc");

            migrationBuilder.DropColumn(
                name: "minimum_monthly_salary",
                table: "kyc");

            migrationBuilder.AddColumn<DateTime>(
                name: "reviewed_at",
                table: "kyc",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reviewed_by",
                table: "kyc",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "kyc",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reviewed_at",
                table: "kyc");

            migrationBuilder.DropColumn(
                name: "reviewed_by",
                table: "kyc");

            migrationBuilder.DropColumn(
                name: "status",
                table: "kyc");

            migrationBuilder.AddColumn<double>(
                name: "maximum_monthly_salary",
                table: "kyc",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "minimum_monthly_salary",
                table: "kyc",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
