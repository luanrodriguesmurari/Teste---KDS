using Kds.Application;
using Kds.Application.Mappers;
using Kds.Business;
using Kds.Domain.Applications;
using Kds.Domain.Business;
using Kds.Repository;
using Kds.Domain.Entities.Orders;
using Kds.Repository.Orders;
using Microsoft.EntityFrameworkCore;

namespace Kds.Api.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddScoped<IOrdersApplication, OrdersApplication>();
            return services;
        }

        public static IServiceCollection AddAdapters(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IOrdersBusiness, OrdersBusiness>();
            return services;
        }

        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("KdsDatabase")));
                      //UseSqlServer - caso utilize o da Microsoft;
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OrderMapper));
            return services;
        }
    }
}