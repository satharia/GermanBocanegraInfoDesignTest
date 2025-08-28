using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.Secrets;
using GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.API.Configuration
{
    public static class ORMConfiguration
    {
        public static WebApplicationBuilder ConfigureORM(this WebApplicationBuilder builder)
        {
            builder.ConfigurePostgresEntityFramework();

            return builder;
        }

        private static WebApplicationBuilder ConfigurePostgresEntityFramework(this WebApplicationBuilder builder)
        {
            var secretSettings = builder.Services.BuildServiceProvider().GetService<SecretConfigurationsDTO>();
            if (secretSettings == null)
            {
                throw new SystemException("Failed to load secret configurations DTO from dependency injection container");
            }

            builder.Services.AddDbContext<MainEntityFrameworkContext>(options => {
                options.UseSqlServer(secretSettings.MainDatabaseConnectionString, b => b.MigrationsAssembly("GermanBocanegra.Test.Infodesign.Infrastructure"));
            });

            return builder;
        }
    }
}
