using Api.Repositories.KycDocuments;
using Api.Repositories.Kycs;
using Api.Repositories.LoanProducts;

namespace Api.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoanProductRepository, LoanProductRepository>();
            services.AddScoped<IKycRepository, KycRepository>();

            return services;
        }
    }
}
