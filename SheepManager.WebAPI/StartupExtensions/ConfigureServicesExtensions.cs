using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SheepManager.Core.Domain.IdentityEntities;
using SheepManager.Core.Domain.MatchCreator;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.Services.Herds;
using SheepManager.Core.Services.Matches;
using SheepManager.Core.Services.Sheeps;
using SheepManager.Core.Services.Vaccines;
using SheepManager.Core.Services_Contracts.Herds;
using SheepManager.Core.Services_Contracts.Matches;
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

            #region MatchServices

            services.AddScoped<IMatchesService, MatchesService>();

            #endregion

            #region HerdServices

            services.AddScoped<IHerdsGetterService, HerdsGetterService>();
            services.AddScoped<IHerdAdderService, HerdsAdderService>();
            services.AddScoped<IHerdUpdaterService, HerdUpdaterService>();

            #endregion

            #region Repositories

            services.AddScoped<ISheepsRepository, SheepsRepository>();
            services.AddScoped<IVaccinesRepository, VaccinesRepository>();
            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<IHerdsRepository, HerdsRepository>();

            #endregion

            #region OtherServices

            services.AddScoped<IMatchesCreator, MatchesCreator>();

            #endregion

            #region IdentityServices

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 3;
            })
                    .AddEntityFrameworkStores<SheepManagerDbContext>()
                    .AddDefaultTokenProviders()
                    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, SheepManagerDbContext,Guid>>()
                    .AddRoleStore<RoleStore<ApplicationRole, SheepManagerDbContext, Guid>>();

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LogoutPath = "/Account/Login";
            });

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
