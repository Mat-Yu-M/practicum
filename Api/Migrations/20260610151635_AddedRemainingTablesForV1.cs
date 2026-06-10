using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedRemainingTablesForV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_history_customers_CustomerId",
                table: "customer_history");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailDetailEntity_customers_CustomerId",
                table: "EmailDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_kyc_customers_CustomerId",
                table: "kyc");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_loan_products_LoanProductId",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneDetailEntity_customers_CustomerId",
                table: "PhoneDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_repayment_schedules_loans_LoanId",
                table: "repayment_schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_repayment_schedules",
                table: "repayment_schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_loans",
                table: "loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_loan_products",
                table: "loan_products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kyc",
                table: "kyc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer_history",
                table: "customer_history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneDetailEntity",
                table: "PhoneDetailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailDetailEntity",
                table: "EmailDetailEntity");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "PhoneDetailEntity",
                newName: "phone_details");

            migrationBuilder.RenameTable(
                name: "EmailDetailEntity",
                newName: "email_details");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "repayment_schedules",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RemainingBalance",
                table: "repayment_schedules",
                newName: "remaining_balance");

            migrationBuilder.RenameColumn(
                name: "PrincipalAmount",
                table: "repayment_schedules",
                newName: "principal_amount");

            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "repayment_schedules",
                newName: "loan_id");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "repayment_schedules",
                newName: "is_paid");

            migrationBuilder.RenameColumn(
                name: "InterestAmount",
                table: "repayment_schedules",
                newName: "interest_amount");

            migrationBuilder.RenameColumn(
                name: "InstallmentNumber",
                table: "repayment_schedules",
                newName: "installment_number");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "repayment_schedules",
                newName: "due_date");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "repayment_schedules",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_repayment_schedules_LoanId",
                table: "repayment_schedules",
                newName: "ix_repayment_schedules_loan_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "loans",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "loans",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "loans",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "loans",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "loans",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "loans",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "LoanProductId",
                table: "loans",
                newName: "loan_product_id");

            migrationBuilder.RenameColumn(
                name: "LoanName",
                table: "loans",
                newName: "loan_name");

            migrationBuilder.RenameColumn(
                name: "InterestRate",
                table: "loans",
                newName: "interest_rate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "loans",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "loans",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "loans",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "ApprovedDate",
                table: "loans",
                newName: "approved_date");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "loans",
                newName: "approved_by");

            migrationBuilder.RenameIndex(
                name: "IX_loans_LoanProductId",
                table: "loans",
                newName: "ix_loans_loan_product_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "loan_products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "loan_products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "loan_products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MinimumTermMonths",
                table: "loan_products",
                newName: "minimum_term_months");

            migrationBuilder.RenameColumn(
                name: "MinimumAmount",
                table: "loan_products",
                newName: "minimum_amount");

            migrationBuilder.RenameColumn(
                name: "MaximumTermMonths",
                table: "loan_products",
                newName: "maximum_term_months");

            migrationBuilder.RenameColumn(
                name: "MaximumAmount",
                table: "loan_products",
                newName: "maximum_amount");

            migrationBuilder.RenameColumn(
                name: "LoanCategory",
                table: "loan_products",
                newName: "loan_category");

            migrationBuilder.RenameColumn(
                name: "IsPromotion",
                table: "loan_products",
                newName: "is_promotion");

            migrationBuilder.RenameColumn(
                name: "InterestRate",
                table: "loan_products",
                newName: "interest_rate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "loan_products",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "kyc",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "kyc",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "kyc",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "SubmittedBy",
                table: "kyc",
                newName: "submitted_by");

            migrationBuilder.RenameColumn(
                name: "SubmittedAt",
                table: "kyc",
                newName: "submitted_at");

            migrationBuilder.RenameColumn(
                name: "MinimumMonthlySalary",
                table: "kyc",
                newName: "minimum_monthly_salary");

            migrationBuilder.RenameColumn(
                name: "MaximumMonthlySalary",
                table: "kyc",
                newName: "maximum_monthly_salary");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "kyc",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "kyc",
                newName: "document_type");

            migrationBuilder.RenameColumn(
                name: "DocumentImagePath",
                table: "kyc",
                newName: "document_image_path");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "kyc",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "AddressLine3",
                table: "kyc",
                newName: "address_line3");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "kyc",
                newName: "address_line2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "kyc",
                newName: "address_line1");

            migrationBuilder.RenameIndex(
                name: "IX_kyc_CustomerId",
                table: "kyc",
                newName: "ix_kyc_customer_id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "employees",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employees",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "employees",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "employees",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EmployeeRoles",
                table: "employees",
                newName: "employee_roles");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "employees",
                newName: "employee_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "employees",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "employees",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "customers",
                newName: "suffix");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "customers",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "customers",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "customers",
                newName: "middle_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "customers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "customers",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "customers",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "customers",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "customers",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "customer_history",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "customer_history",
                newName: "action");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customer_history",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RepaymentScheduleId",
                table: "customer_history",
                newName: "repayment_schedule_id");

            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "customer_history",
                newName: "loan_id");

            migrationBuilder.RenameColumn(
                name: "LoanAmount",
                table: "customer_history",
                newName: "loan_amount");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "customer_history",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "customer_history",
                newName: "approved_by");

            migrationBuilder.RenameColumn(
                name: "ApprovedAt",
                table: "customer_history",
                newName: "approved_at");

            migrationBuilder.RenameIndex(
                name: "IX_customer_history_CustomerId",
                table: "customer_history",
                newName: "ix_customer_history_customer_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "phone_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "phone_details",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "ModifiedDateTime",
                table: "phone_details",
                newName: "modified_date_time");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "phone_details",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "ExtensionNumber",
                table: "phone_details",
                newName: "extension_number");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "phone_details",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "phone_details",
                newName: "created_date_time");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "phone_details",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "phone_details",
                newName: "country_code");

            migrationBuilder.RenameColumn(
                name: "AreaCode",
                table: "phone_details",
                newName: "area_code");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneDetailEntity_CustomerId_PhoneNumber",
                table: "phone_details",
                newName: "ix_phone_details_customer_id_phone_number");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "email_details",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "email_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "email_details",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_EmailDetailEntity_CustomerId_Email",
                table: "email_details",
                newName: "ix_email_details_customer_id_email");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "employees",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "employee_id",
                table: "employees",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "pk_repayment_schedules",
                table: "repayment_schedules",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_loans",
                table: "loans",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_loan_products",
                table: "loan_products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_kyc",
                table: "kyc",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employees",
                table: "employees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customers",
                table: "customers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customer_history",
                table: "customer_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_phone_details",
                table: "phone_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_email_details",
                table: "email_details",
                column: "id");

            migrationBuilder.CreateTable(
                name: "customer_request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    middle_name = table.Column<string>(type: "text", nullable: true),
                    suffix = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    request_type = table.Column<int>(type: "integer", nullable: false),
                    request_status_type = table.Column<int>(type: "integer", nullable: false),
                    rejection_reason = table.Column<string>(type: "text", nullable: true),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_request", x => x.id);
                    table.ForeignKey(
                        name: "fk_customer_request_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "customer_status_histories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    customer_name = table.Column<string>(type: "text", nullable: false),
                    before_status = table.Column<int>(type: "integer", nullable: false),
                    after_status = table.Column<int>(type: "integer", nullable: false),
                    changed_by = table.Column<string>(type: "text", nullable: false),
                    changed_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_status_histories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees_request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    employee_roles = table.Column<int[]>(type: "integer[]", nullable: false),
                    request_type = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees_request", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loan_product_requests",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    loan_category = table.Column<int>(type: "integer", nullable: false),
                    interest_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    minimum_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    maximum_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    minimum_term_months = table.Column<int>(type: "integer", nullable: false),
                    maximum_term_months = table.Column<int>(type: "integer", nullable: false),
                    is_promotion = table.Column<bool>(type: "boolean", nullable: false),
                    request_type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_loan_product_requests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loan_requests",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    loan_product_id = table.Column<long>(type: "bigint", nullable: false),
                    loan_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    interest_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    request_type = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    approved_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    approved_by = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_loan_requests", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_repayment_schedules_customer_id",
                table: "repayment_schedules",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_email",
                table: "employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employees_employee_id",
                table: "employees",
                column: "employee_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_customer_request_customer_id",
                table: "customer_request",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_history_customers_customer_id",
                table: "customer_history",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_email_details_customers_customer_id",
                table: "email_details",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_kyc_customers_customer_id",
                table: "kyc",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_loans_loan_products_loan_product_id",
                table: "loans",
                column: "loan_product_id",
                principalTable: "loan_products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_phone_details_customers_customer_id",
                table: "phone_details",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_repayment_schedules_customers_customer_id",
                table: "repayment_schedules",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_repayment_schedules_loans_loan_id",
                table: "repayment_schedules",
                column: "loan_id",
                principalTable: "loans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_history_customers_customer_id",
                table: "customer_history");

            migrationBuilder.DropForeignKey(
                name: "fk_email_details_customers_customer_id",
                table: "email_details");

            migrationBuilder.DropForeignKey(
                name: "fk_kyc_customers_customer_id",
                table: "kyc");

            migrationBuilder.DropForeignKey(
                name: "fk_loans_loan_products_loan_product_id",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "fk_phone_details_customers_customer_id",
                table: "phone_details");

            migrationBuilder.DropForeignKey(
                name: "fk_repayment_schedules_customers_customer_id",
                table: "repayment_schedules");

            migrationBuilder.DropForeignKey(
                name: "fk_repayment_schedules_loans_loan_id",
                table: "repayment_schedules");

            migrationBuilder.DropTable(
                name: "customer_request");

            migrationBuilder.DropTable(
                name: "customer_status_histories");

            migrationBuilder.DropTable(
                name: "employees_request");

            migrationBuilder.DropTable(
                name: "loan_product_requests");

            migrationBuilder.DropTable(
                name: "loan_requests");

            migrationBuilder.DropPrimaryKey(
                name: "pk_repayment_schedules",
                table: "repayment_schedules");

            migrationBuilder.DropIndex(
                name: "ix_repayment_schedules_customer_id",
                table: "repayment_schedules");

            migrationBuilder.DropPrimaryKey(
                name: "pk_loans",
                table: "loans");

            migrationBuilder.DropPrimaryKey(
                name: "pk_loan_products",
                table: "loan_products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_kyc",
                table: "kyc");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employees",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "ix_employees_email",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "ix_employees_employee_id",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customer_history",
                table: "customer_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_phone_details",
                table: "phone_details");

            migrationBuilder.DropPrimaryKey(
                name: "pk_email_details",
                table: "email_details");

            migrationBuilder.RenameTable(
                name: "phone_details",
                newName: "PhoneDetailEntity");

            migrationBuilder.RenameTable(
                name: "email_details",
                newName: "EmailDetailEntity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "repayment_schedules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "remaining_balance",
                table: "repayment_schedules",
                newName: "RemainingBalance");

            migrationBuilder.RenameColumn(
                name: "principal_amount",
                table: "repayment_schedules",
                newName: "PrincipalAmount");

            migrationBuilder.RenameColumn(
                name: "loan_id",
                table: "repayment_schedules",
                newName: "LoanId");

            migrationBuilder.RenameColumn(
                name: "is_paid",
                table: "repayment_schedules",
                newName: "IsPaid");

            migrationBuilder.RenameColumn(
                name: "interest_amount",
                table: "repayment_schedules",
                newName: "InterestAmount");

            migrationBuilder.RenameColumn(
                name: "installment_number",
                table: "repayment_schedules",
                newName: "InstallmentNumber");

            migrationBuilder.RenameColumn(
                name: "due_date",
                table: "repayment_schedules",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "repayment_schedules",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "ix_repayment_schedules_loan_id",
                table: "repayment_schedules",
                newName: "IX_repayment_schedules_LoanId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "loans",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "loans",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "loans",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "loans",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "loans",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "loans",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "loan_product_id",
                table: "loans",
                newName: "LoanProductId");

            migrationBuilder.RenameColumn(
                name: "loan_name",
                table: "loans",
                newName: "LoanName");

            migrationBuilder.RenameColumn(
                name: "interest_rate",
                table: "loans",
                newName: "InterestRate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "loans",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "loans",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "loans",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "approved_date",
                table: "loans",
                newName: "ApprovedDate");

            migrationBuilder.RenameColumn(
                name: "approved_by",
                table: "loans",
                newName: "ApprovedBy");

            migrationBuilder.RenameIndex(
                name: "ix_loans_loan_product_id",
                table: "loans",
                newName: "IX_loans_LoanProductId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "loan_products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "loan_products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "loan_products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "minimum_term_months",
                table: "loan_products",
                newName: "MinimumTermMonths");

            migrationBuilder.RenameColumn(
                name: "minimum_amount",
                table: "loan_products",
                newName: "MinimumAmount");

            migrationBuilder.RenameColumn(
                name: "maximum_term_months",
                table: "loan_products",
                newName: "MaximumTermMonths");

            migrationBuilder.RenameColumn(
                name: "maximum_amount",
                table: "loan_products",
                newName: "MaximumAmount");

            migrationBuilder.RenameColumn(
                name: "loan_category",
                table: "loan_products",
                newName: "LoanCategory");

            migrationBuilder.RenameColumn(
                name: "is_promotion",
                table: "loan_products",
                newName: "IsPromotion");

            migrationBuilder.RenameColumn(
                name: "interest_rate",
                table: "loan_products",
                newName: "InterestRate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "loan_products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "kyc",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "kyc",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "kyc",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "submitted_by",
                table: "kyc",
                newName: "SubmittedBy");

            migrationBuilder.RenameColumn(
                name: "submitted_at",
                table: "kyc",
                newName: "SubmittedAt");

            migrationBuilder.RenameColumn(
                name: "minimum_monthly_salary",
                table: "kyc",
                newName: "MinimumMonthlySalary");

            migrationBuilder.RenameColumn(
                name: "maximum_monthly_salary",
                table: "kyc",
                newName: "MaximumMonthlySalary");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "kyc",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "document_type",
                table: "kyc",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "document_image_path",
                table: "kyc",
                newName: "DocumentImagePath");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "kyc",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "address_line3",
                table: "kyc",
                newName: "AddressLine3");

            migrationBuilder.RenameColumn(
                name: "address_line2",
                table: "kyc",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "address_line1",
                table: "kyc",
                newName: "AddressLine1");

            migrationBuilder.RenameIndex(
                name: "ix_kyc_customer_id",
                table: "kyc",
                newName: "IX_kyc_CustomerId");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "employees",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "employee_roles",
                table: "employees",
                newName: "EmployeeRoles");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "employees",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "employees",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "suffix",
                table: "customers",
                newName: "Suffix");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "customers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "customers",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "customers",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "customers",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "customers",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "customers",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "customer_history",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "action",
                table: "customer_history",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customer_history",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "repayment_schedule_id",
                table: "customer_history",
                newName: "RepaymentScheduleId");

            migrationBuilder.RenameColumn(
                name: "loan_id",
                table: "customer_history",
                newName: "LoanId");

            migrationBuilder.RenameColumn(
                name: "loan_amount",
                table: "customer_history",
                newName: "LoanAmount");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "customer_history",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "approved_by",
                table: "customer_history",
                newName: "ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "approved_at",
                table: "customer_history",
                newName: "ApprovedAt");

            migrationBuilder.RenameIndex(
                name: "ix_customer_history_customer_id",
                table: "customer_history",
                newName: "IX_customer_history_CustomerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PhoneDetailEntity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "PhoneDetailEntity",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "modified_date_time",
                table: "PhoneDetailEntity",
                newName: "ModifiedDateTime");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "PhoneDetailEntity",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "extension_number",
                table: "PhoneDetailEntity",
                newName: "ExtensionNumber");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "PhoneDetailEntity",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "created_date_time",
                table: "PhoneDetailEntity",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "PhoneDetailEntity",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "country_code",
                table: "PhoneDetailEntity",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "area_code",
                table: "PhoneDetailEntity",
                newName: "AreaCode");

            migrationBuilder.RenameIndex(
                name: "ix_phone_details_customer_id_phone_number",
                table: "PhoneDetailEntity",
                newName: "IX_PhoneDetailEntity_CustomerId_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "EmailDetailEntity",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EmailDetailEntity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "EmailDetailEntity",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "ix_email_details_customer_id_email",
                table: "EmailDetailEntity",
                newName: "IX_EmailDetailEntity_CustomerId_Email");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_repayment_schedules",
                table: "repayment_schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loans",
                table: "loans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loan_products",
                table: "loan_products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kyc",
                table: "kyc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer_history",
                table: "customer_history",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneDetailEntity",
                table: "PhoneDetailEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailDetailEntity",
                table: "EmailDetailEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_history_customers_CustomerId",
                table: "customer_history",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailDetailEntity_customers_CustomerId",
                table: "EmailDetailEntity",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyc_customers_CustomerId",
                table: "kyc",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_loans_loan_products_LoanProductId",
                table: "loans",
                column: "LoanProductId",
                principalTable: "loan_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneDetailEntity_customers_CustomerId",
                table: "PhoneDetailEntity",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_repayment_schedules_loans_LoanId",
                table: "repayment_schedules",
                column: "LoanId",
                principalTable: "loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
