
using GermanBocanegra.Test.Infodesign.API.Configuration;
using GermanBocanegra.Test.Infodesign.API.Filters;
using Scalar.AspNetCore;

namespace GermanBocanegra.Test.Infodesign.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load encodings for reading files
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Configure Secret Configurations
            builder.ConfigureSecrets();

            // Configure Object Mapper
            builder.ConfigureLogger();

            // Configure Object Mapper
            builder.ConfigureObjectMapper();

            // Configure Cors
            builder.ConfigureCors();

            // Configure ORM
            builder.ConfigureORM();

            // Add services to the container.
            builder.ConfigureDependencies();

            // Load controllers and filters
            builder.Services.AddControllers(c => c.Filters.Add<FallbackExceptionFilter>());

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi("v1");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
