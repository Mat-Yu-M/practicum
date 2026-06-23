using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class KycChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address_line2",
                table: "kyc");

            migrationBuilder.DropColumn(
                name: "address_line3",
                table: "kyc");

            migrationBuilder.RenameColumn(
                name: "address_line1",
                table: "kyc",
                newName: "address_line");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address_line",
                table: "kyc",
                newName: "address_line1");

            migrationBuilder.AddColumn<string>(
                name: "address_line2",
                table: "kyc",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address_line3",
                table: "kyc",
                type: "text",
                nullable: true);
        }
    }
}
