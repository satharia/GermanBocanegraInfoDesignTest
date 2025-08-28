using Amazon;
using Amazon.SecretsManager;
using GermanBocanegra.Test.Infodesign.Domain.Constants;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.Secrets;
using GermanBocanegra.Test.Infodesign.Infrastructure.Utilities;
using Newtonsoft.Json;

namespace GermanBocanegra.Test.Infodesign.API.Configuration
{
    public static class SecretsConfiguration
    {
        public static WebApplicationBuilder ConfigureSecrets(this WebApplicationBuilder builder)
        {
            var environmentVariables = EnvironmentVariableWrapperUtils.GetEnvironmentVariablesWrapper();
            var secrets = (SecretConfigurationsDTO?)null;

            if (environmentVariables.ExecutionEnvironment.Equals(EnvironmentConstants.DEVELOPMENT))
            {
                var developmentMainDBConnectionString = builder.Configuration["DevelopmentSettings:DevelopmentMainDBConnectionString"]
                    ?? throw new SystemException("Missing DevelopmentSettings:DevelopmentMainDBConnectionString configuration");
                var automapperLicenseKey = builder.Configuration["DevelopmentSettings:DevelopmentMainDBConnectionString"]
                    ?? throw new SystemException("Missing DevelopmentSettings:DevelopmentMainDBConnectionString configuration");

                secrets = new SecretConfigurationsDTO()
                {
                    MainDatabaseConnectionString = developmentMainDBConnectionString,
                    AutoMapperLicenseKey = automapperLicenseKey
                };
            }
            else
            {
                // Note: AmazonSecretsManagerClient takes the first credentials from the AWS Credntials Chain it finds,
                // this project takes them from the 'ECS Task Role' when deployed with the terraform script included in the repo
                var secretManagerClient = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(environmentVariables.AWSRegion));
                var secretResquest = new Amazon.SecretsManager.Model.GetSecretValueRequest()
                {
                    SecretId = environmentVariables.AWSSecretManagerSecretID
                };
                var secretResponse = secretManagerClient.GetSecretValueAsync(secretResquest).Result;
                secrets = JsonConvert.DeserializeObject<SecretConfigurationsDTO>(secretResponse.SecretString);
                if (secrets == null)
                {
                    throw new SystemException("Missing Blog Secret Configuration from AWS Secrets Manager");
                }
            }

            builder.Services.AddSingleton(secrets);

            return builder;
        }
    }
}
