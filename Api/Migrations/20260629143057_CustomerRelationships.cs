using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class CustomerRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "changed_date",
                table: "customer_status_histories",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "changed_by",
                table: "customer_status_histories",
                newName: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_customer_status_histories_customer_id",
                table: "customer_status_histories",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_status_histories_customers_customer_id",
                table: "customer_status_histories",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_status_histories_customers_customer_id",
                table: "customer_status_histories");

            migrationBuilder.DropIndex(
                name: "ix_customer_status_histories_customer_id",
                table: "customer_status_histories");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "customer_status_histories",
                newName: "changed_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "customer_status_histories",
                newName: "changed_by");
        }
    }
}
