using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDescriptionInLoans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "description",
                table: "loan_requests");

            migrationBuilder.AddColumn<decimal>(
                name: "final_amount",
                table: "loans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "final_amount",
                table: "loans");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "loans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "loan_requests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
