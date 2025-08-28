using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace GermanBocanegra.Test.Infodesign.API.InputAdapters
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckInputAdapter : ControllerBase
    {
        public HealthCheckInputAdapter()
        {

        }

        [HttpGet("http")]
        public IActionResult HttpHealthCheck()
        {
            return Ok(new BaseResponse()
            {
                Message = "Healthy Service"
            });
        }
    }
}
