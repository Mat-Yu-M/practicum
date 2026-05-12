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
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "Kyc",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Kyc_UserId",
                table: "Kyc",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kyc_Users_UserId",
                table: "Kyc",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kyc_Users_UserId",
                table: "Kyc");

            migrationBuilder.DropIndex(
                name: "IX_Kyc_UserId",
                table: "Kyc");

            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "Kyc");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Kyc",
                newName: "CustomerId");
        }
    }
}
