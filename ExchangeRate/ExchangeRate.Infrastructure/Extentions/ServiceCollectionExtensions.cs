using AutoMapper;
using ExchangeRate.Application.Interfaces.Contexts;
using ExchangeRate.Application.Interfaces.Repositories;
using ExchangeRate.Infrastructure.DbContext;
using ExchangeRate.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExchangeRate.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<IBankByCurrencyRepository, EchangeRateRepository>();
            //services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }
    }
}
