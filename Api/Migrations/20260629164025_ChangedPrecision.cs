using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "total_amount_due",
                table: "repayment_schedules",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "principal_amount + interest_amount",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComputedColumnSql: "[PrincipalAmount] + [InterestAmount]",
                oldStored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "total_amount_due",
                table: "repayment_schedules",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "[PrincipalAmount] + [InterestAmount]",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComputedColumnSql: "principal_amount + interest_amount",
                oldStored: true);
        }
    }
}
