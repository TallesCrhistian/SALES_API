using SALES_API.Business.Interfaces;
using SALES_API.Data.Interfaces;
using SALES_API.Data.Repository;
using SALES_API.Data.WorkUnit.Interfaces;
using SALES_API.Data.WorkUnit;
using SALES_API.Data;
using SALES_API.Services.Interfaces;
using SALES_API.Services;
using Microsoft.EntityFrameworkCore;
using SALES_API.Business;

namespace SALES_API.API
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration iConfiguration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClientServices, ClientServices>();

            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IClientBusiness, ClientBusiness>();
            
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }

        public static IServiceCollection WorkUnit(this IServiceCollection services)
        {
            services.AddScoped<IWorkUnit, WorkUnit>();
            return services;
        }
    }
}
