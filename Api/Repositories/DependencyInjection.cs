using Api.Repositories.Customers;
using Api.Repositories.EmployeeRequests;
using Api.Repositories.Employees;
using Api.Repositories.KycDocuments;
using Api.Repositories.Kycs;
using Api.Repositories.LoanProducts;

namespace Api.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ILoanProductRepository, LoanProductRepository>();

            services.AddScoped<IKycRepository, KycRepository>();

            services.AddScoped<IEmployeeRequestRepository, EmployeeRequestRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
