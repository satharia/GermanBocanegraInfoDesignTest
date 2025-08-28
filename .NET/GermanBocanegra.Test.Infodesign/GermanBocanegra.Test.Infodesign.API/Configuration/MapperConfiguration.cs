using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.Secrets;
using GermanBocanegra.Test.Infodesign.Infrastructure.Mappers;

namespace GermanBocanegra.Test.Infodesign.API.Configuration
{
    public static class MapperConfiguration
    {
        public static WebApplicationBuilder ConfigureObjectMapper(this WebApplicationBuilder builder)
        {
            builder.ConfigureAutoMapper();

            return builder;
        }

        private static WebApplicationBuilder ConfigureAutoMapper(this WebApplicationBuilder builder)
        {
            var secretSettings = builder.Services.BuildServiceProvider().GetService<SecretConfigurationsDTO>();
            if (secretSettings == null)
            {
                throw new SystemException("Failed to load secret configurations DTO from dependency injection container");
            }

            builder.Services.AddAutoMapper(cfg => {
                cfg.LicenseKey = secretSettings.AutoMapperLicenseKey;
                cfg.AddProfile(typeof(AutoMapperEntityToDTOProfile));
                cfg.AddProfile(typeof(AutoMapperDTOToPresenterProfile));
            });

            return builder;
        }
    }
}
