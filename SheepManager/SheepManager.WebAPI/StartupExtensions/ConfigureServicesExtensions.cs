using Microsoft.EntityFrameworkCore;
using SheepManager.Infrastructure.DatabaseContext;

namespace SheepManager.WebAPI.StartupExtensions
{
    public static class ConfigureServicesExtensions
    {
        #region Methods

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SheepManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SheepManagerConnectionStrings"));
            });

            return services;
        }

        #endregion
    }
}
