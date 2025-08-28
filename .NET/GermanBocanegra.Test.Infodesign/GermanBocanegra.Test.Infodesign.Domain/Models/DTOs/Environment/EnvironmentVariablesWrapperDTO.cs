namespace GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.Environment
{
    public class EnvironmentVariablesWrapperDTO
    {
        public string ExecutionEnvironment { get; set; } = string.Empty;
        public string AWSRegion { get; set; } = string.Empty;
        public string AWSSecretManagerSecretID { get; set; } = string.Empty;
        public string CORSDomainsSeparatedByComma { get; set; } = string.Empty;
    }
}
