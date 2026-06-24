using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_history_customers_customer_id",
                table: "customer_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customer_history",
                table: "customer_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_audit_logs",
                table: "audit_logs");

            migrationBuilder.RenameTable(
                name: "customer_history",
                newName: "customer_loan_history");

            migrationBuilder.RenameTable(
                name: "audit_logs",
                newName: "audit_log");

            migrationBuilder.RenameIndex(
                name: "ix_customer_history_customer_id",
                table: "customer_loan_history",
                newName: "ix_customer_loan_history_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customer_loan_history",
                table: "customer_loan_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_audit_log",
                table: "audit_log",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_loan_history_customers_customer_id",
                table: "customer_loan_history",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_loan_history_customers_customer_id",
                table: "customer_loan_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customer_loan_history",
                table: "customer_loan_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_audit_log",
                table: "audit_log");

            migrationBuilder.RenameTable(
                name: "customer_loan_history",
                newName: "customer_history");

            migrationBuilder.RenameTable(
                name: "audit_log",
                newName: "audit_logs");

            migrationBuilder.RenameIndex(
                name: "ix_customer_loan_history_customer_id",
                table: "customer_history",
                newName: "ix_customer_history_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customer_history",
                table: "customer_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_audit_logs",
                table: "audit_logs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_history_customers_customer_id",
                table: "customer_history",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
