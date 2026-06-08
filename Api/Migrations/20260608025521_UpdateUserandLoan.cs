using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserandLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "loans",
                newName: "LoanProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "loans",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsPromotion",
                table: "loan_products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "customer_history",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoanId = table.Column<long>(type: "bigint", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RepaymentScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_history", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "repayment_schedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoanId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    InstallmentNumber = table.Column<int>(type: "integer", nullable: false),
                    PrincipalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    InterestAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    RemainingBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repayment_schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_repayment_schedules_loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_loans_LoanProductId",
                table: "loans",
                column: "LoanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_repayment_schedules_LoanId",
                table: "repayment_schedules",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_loans_loan_products_LoanProductId",
                table: "loans",
                column: "LoanProductId",
                principalTable: "loan_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loans_loan_products_LoanProductId",
                table: "loans");

            migrationBuilder.DropTable(
                name: "customer_history");

            migrationBuilder.DropTable(
                name: "repayment_schedules");

            migrationBuilder.DropIndex(
                name: "IX_loans_LoanProductId",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "IsPromotion",
                table: "loan_products");

            migrationBuilder.RenameColumn(
                name: "LoanProductId",
                table: "loans",
                newName: "LoanId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedBy",
                table: "loans",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
