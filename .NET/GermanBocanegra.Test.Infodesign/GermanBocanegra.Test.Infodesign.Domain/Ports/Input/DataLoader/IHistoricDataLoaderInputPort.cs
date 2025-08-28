using GermanBocanegra.Test.Infodesign.Domain.Models.Request.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Models.Response.DataLoader;

namespace GermanBocanegra.Test.Infodesign.Domain.Ports.Input.DataLoader
{
    public interface IHistoricDataLoaderInputPort
    {
        Task<LoadHistoricDataResponse> LoadHistoricDataFromFileAsync(LoadHistoricDataRequest request);
    }
}
