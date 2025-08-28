using Serilog;

namespace GermanBocanegra.Test.Infodesign.API.Configuration
{
    public static class LoggingConfiguration
    {
        public static WebApplicationBuilder ConfigureLogger(this WebApplicationBuilder builder)
        {
            builder.ConfigureSerilog();

            return builder;
        }

        private static WebApplicationBuilder ConfigureSerilog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            return builder;
        }
    }
}
