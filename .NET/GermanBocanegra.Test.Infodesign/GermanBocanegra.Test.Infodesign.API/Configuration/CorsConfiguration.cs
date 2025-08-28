using GermanBocanegra.Test.Infodesign.Infrastructure.Utilities;

namespace GermanBocanegra.Test.Infodesign.API.Configuration
{
    public static class CorsConfiguration
    {
        public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
        {
            var environmentVariables = EnvironmentVariableWrapperUtils.GetEnvironmentVariablesWrapper();
            var splitDomains = environmentVariables.CORSDomainsSeparatedByComma.Split(",");

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .WithOrigins(splitDomains)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            return builder;
        }
    }
}
