using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class NewEmployeeRequestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_date",
                table: "employees_request");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "employees",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "approved_date",
                table: "employees",
                newName: "approved_date_time");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date_time",
                table: "employees_request",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "employees_request",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "suffix",
                table: "employees_request",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_date_time",
                table: "employees_request");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "employees_request");

            migrationBuilder.DropColumn(
                name: "suffix",
                table: "employees_request");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "employees",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "approved_date_time",
                table: "employees",
                newName: "approved_date");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "employees_request",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
