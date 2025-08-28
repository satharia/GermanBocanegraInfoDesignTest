using GermanBocanegra.Test.Infodesign.Domain.Models.Request.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Ports.Input.DataLoader;
using Microsoft.AspNetCore.Mvc;

namespace GermanBocanegra.Test.Infodesign.API.InputAdapters.DataLoader
{
    [Route("api/dataloader")]
    [ApiController]
    public class HistoricDataLoaderInputAdapter : ControllerBase
    {
        private readonly IHistoricDataLoaderInputPort historicDataLoaderInputPort;

        public HistoricDataLoaderInputAdapter(IHistoricDataLoaderInputPort historicDataLoaderInputPort)
        {
            this.historicDataLoaderInputPort = historicDataLoaderInputPort;
        }

        [HttpPost("historic")]
        public async Task<IActionResult> LoadHistoricData([FromBody] LoadHistoricDataRequest request)
        {
            var result = await historicDataLoaderInputPort.LoadHistoricDataFromFileAsync(request);

            return Ok(result);
        }
    }
}
