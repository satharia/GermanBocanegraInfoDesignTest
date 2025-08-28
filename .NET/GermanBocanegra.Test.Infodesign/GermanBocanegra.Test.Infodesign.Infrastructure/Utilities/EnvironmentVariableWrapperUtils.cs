using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.Environment;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Utilities
{
    public static class EnvironmentVariableWrapperUtils
    {
        private static EnvironmentVariablesWrapperDTO? environmentVariables;

        public static EnvironmentVariablesWrapperDTO GetEnvironmentVariablesWrapper()
        {
            if (environmentVariables != null)
            {
                return environmentVariables;
            }

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var awsRegion = Environment.GetEnvironmentVariable("ENERGYTEST_AWS_REGION") ?? "us-east-1";
            var secretId = Environment.GetEnvironmentVariable("ENERGYTEST_SECRET_ID") ?? "energytest_secret";
            var corsDomains = Environment.GetEnvironmentVariable("ENERGYTEST_CORS_DOMAINS_SEPARATED_BY_COMMA") ?? "http://localhost:8080,http://127.0.0.1:8080";

            environmentVariables = new EnvironmentVariablesWrapperDTO()
            {
                ExecutionEnvironment = environment,
                AWSRegion = awsRegion,
                AWSSecretManagerSecretID = secretId,
                CORSDomainsSeparatedByComma = corsDomains
            };

            return environmentVariables;
        }
    }
}
