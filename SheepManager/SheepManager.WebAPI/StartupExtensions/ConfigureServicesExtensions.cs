using Microsoft.EntityFrameworkCore;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.Services.Sheeps;
using SheepManager.Core.Services.Vaccines;
using SheepManager.Core.Services_Contracts.Sheeps;
using SheepManager.Core.Services_Contracts.Vaccines;
using SheepManager.Infrastructure.DatabaseContext;
using SheepManager.Infrastructure.Repositories;

namespace SheepManager.WebAPI.StartupExtensions
{
    public static class ConfigureServicesExtensions
    {
        #region Methods

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            #region SheepServices

            services.AddScoped<ISheepsGetterService, SheepsGetterService>();
            services.AddScoped<ISheepsAdderService, SheepsAdderService>();
            services.AddScoped<ISheepsUpdaterService, SheepsUpdaterService>();

            #endregion

            #region VaccineServices

            services.AddScoped<IVaccinesGetterService, VaccinesGetterService>();
            services.AddScoped<IVaccinesAdderService, VaccinesAdderService>();
            services.AddScoped<IVaccinesUpdaterService, VaccineUpdaterService>();

            #endregion

            #region Repositories

            services.AddScoped<ISheepsRepository, SheepsRepository>();
            services.AddScoped<IVaccinesRepository, VaccinesRepository>();

            #endregion

            services.AddDbContext<SheepManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SheepManagerConnectionStrings"));
            });

            return services;
        }

        #endregion
    }
}
