namespace GermanBocanegra.Test.Infodesign.Domain.Models.Request.DataLoader
{
    public class LoadHistoricDataRequest
    {
        public string LocalFilePath { get; set; } = string.Empty;
        public bool ReplaceCurrentData { get; set; } = false;
    }
}
