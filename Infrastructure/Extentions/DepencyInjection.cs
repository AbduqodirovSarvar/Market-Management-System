using Application.Abstractions.Interfaces;
using Application.Extentions;
using Infrastructure.Models;
using Infrastructure.Persistance.DefaultInformations;
using Infrastructure.Persistance.EntityFramework;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ITokenService, TokenService>();

            // var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = configuration.GetConnectionString("ConnectionStrings__SQLiteConnection");

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            var dataSource = dataSourceBuilder.Build();

         /*   services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });*/

            services.AddDbContext<IAppDbContext, AppDbContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(dataSource,
                    options =>
                    {
                        options.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                        options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
                    .EnableSensitiveDataLogging();
            });

            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            using var serviceProvider = services.BuildServiceProvider();
            var hashService = serviceProvider.GetRequiredService<IHashService>();
            DefautUserData.Initialize(hashService);

            services.AddAuthorization();

            return services;
        }
    }
}
