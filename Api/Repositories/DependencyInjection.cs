using Api.Repositories.AuditLogs;
using Api.Repositories.CustomerLoanHistories;
using Api.Repositories.Customers;
using Api.Repositories.EmailDetails;
using Api.Repositories.EmployeeRequests;
using Api.Repositories.Employees;
using Api.Repositories.KycDocuments;
using Api.Repositories.Kycs;
using Api.Repositories.LoanProductRequests;
using Api.Repositories.LoanProducts;
using Api.Repositories.LoanRequests;
using Api.Repositories.Loans;
using Api.Repositories.PhoneDetails;

namespace Api.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ILoanProductRepository, LoanProductRepository>();
            services.AddScoped<ILoanProductRequestRepository, LoanProductRequestRepository>();

            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanRequestRepository, LoanRequestRepository>();

            services.AddScoped<IKycRepository, KycRepository>();
            services.AddScoped<IEmailDetailRepository, EmailDetailRepository>();
            services.AddScoped<IPhoneDetailRepository, PhoneDetailRepository>();
            services.AddScoped<ICustomerLoanHistoryRepository, CustomerLoanHistoryRepository>();


            services.AddScoped<IEmployeeRequestRepository, EmployeeRequestRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
