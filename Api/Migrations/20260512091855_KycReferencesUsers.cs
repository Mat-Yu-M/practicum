using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class KycReferencesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Kyc",
                newName: "CustomerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "Kyc",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Kyc_CustomerId",
                table: "Kyc",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kyc_Users_CustomerId",
                table: "Kyc",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kyc_Users_CustomerId",
                table: "Kyc");

            migrationBuilder.DropIndex(
                name: "IX_Kyc_CustomerId",
                table: "Kyc");

            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "Kyc");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Kyc",
                newName: "CustomerId");
        }
    }
}
