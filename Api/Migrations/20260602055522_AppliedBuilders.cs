using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AppliedBuilders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kyc_Users_CustomerId",
                table: "Kyc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kyc",
                table: "Kyc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Kyc",
                newName: "kyc");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameIndex(
                name: "IX_Kyc_CustomerId",
                table: "kyc",
                newName: "IX_kyc_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kyc",
                table: "kyc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_kyc_users_CustomerId",
                table: "kyc",
                column: "CustomerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kyc_users_CustomerId",
                table: "kyc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kyc",
                table: "kyc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "kyc",
                newName: "Kyc");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_kyc_CustomerId",
                table: "Kyc",
                newName: "IX_Kyc_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kyc",
                table: "Kyc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kyc_Users_CustomerId",
                table: "Kyc",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
