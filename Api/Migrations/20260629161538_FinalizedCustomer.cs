using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FinalizedCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_repayment_schedules_customers_customer_id",
                table: "repayment_schedules");

            migrationBuilder.DropColumn(
                name: "area_code",
                table: "phone_details");

            migrationBuilder.DropColumn(
                name: "country_code",
                table: "phone_details");

            migrationBuilder.DropColumn(
                name: "extension_number",
                table: "phone_details");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "phone_details");

            migrationBuilder.DropColumn(
                name: "modified_date_time",
                table: "phone_details");

            migrationBuilder.DropColumn(
                name: "action",
                table: "customer_loan_history");

            migrationBuilder.AlterColumn<decimal>(
                name: "remaining_balance",
                table: "repayment_schedules",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "principal_amount",
                table: "repayment_schedules",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "interest_amount",
                table: "repayment_schedules",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "phone_details",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "email_details",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date_time",
                table: "email_details",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "loan_amount",
                table: "customer_loan_history",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "approved_by",
                table: "customer_loan_history",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "customer_loan_history",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date_time",
                table: "customer_loan_history",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "due_date",
                table: "customer_loan_history",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "total_amount_due",
                table: "repayment_schedules",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "[PrincipalAmount] + [InterestAmount]",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "ix_customer_loan_history_loan_id",
                table: "customer_loan_history",
                column: "loan_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_loan_history_repayment_schedule_id",
                table: "customer_loan_history",
                column: "repayment_schedule_id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_loan_history_loan_repayment_schedules_repayment_sc",
                table: "customer_loan_history",
                column: "repayment_schedule_id",
                principalTable: "repayment_schedules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_customer_loan_history_loans_loan_id",
                table: "customer_loan_history",
                column: "loan_id",
                principalTable: "loans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_repayment_schedules_customers_customer_id",
                table: "repayment_schedules",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_loan_history_loan_repayment_schedules_repayment_sc",
                table: "customer_loan_history");

            migrationBuilder.DropForeignKey(
                name: "fk_customer_loan_history_loans_loan_id",
                table: "customer_loan_history");

            migrationBuilder.DropForeignKey(
                name: "fk_repayment_schedules_customers_customer_id",
                table: "repayment_schedules");

            migrationBuilder.DropIndex(
                name: "ix_customer_loan_history_loan_id",
                table: "customer_loan_history");

            migrationBuilder.DropIndex(
                name: "ix_customer_loan_history_repayment_schedule_id",
                table: "customer_loan_history");

            migrationBuilder.DropColumn(
                name: "total_amount_due",
                table: "repayment_schedules");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "email_details");

            migrationBuilder.DropColumn(
                name: "created_date_time",
                table: "email_details");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "customer_loan_history");

            migrationBuilder.DropColumn(
                name: "created_date_time",
                table: "customer_loan_history");

            migrationBuilder.DropColumn(
                name: "due_date",
                table: "customer_loan_history");

            migrationBuilder.AlterColumn<decimal>(
                name: "remaining_balance",
                table: "repayment_schedules",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "principal_amount",
                table: "repayment_schedules",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "interest_amount",
                table: "repayment_schedules",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "phone_details",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "area_code",
                table: "phone_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                table: "phone_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extension_number",
                table: "phone_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "phone_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date_time",
                table: "phone_details",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "loan_amount",
                table: "customer_loan_history",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "approved_by",
                table: "customer_loan_history",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "action",
                table: "customer_loan_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_repayment_schedules_customers_customer_id",
                table: "repayment_schedules",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
