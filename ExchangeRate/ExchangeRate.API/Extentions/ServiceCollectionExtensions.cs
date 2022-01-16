using ExchangeRate.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.API.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContextInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BankDatabase"), b => b.MigrationsAssembly("ExchangeRate.API")));
    }
}
