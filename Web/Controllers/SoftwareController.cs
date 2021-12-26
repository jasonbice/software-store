using System.Threading;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("software")]
    public class SoftwareController : ControllerBase
    {
        private readonly ISoftwareService softwareService;

        public SoftwareController(ISoftwareService softwareService) => this.softwareService = softwareService;

        [HttpGet]
        public async Task<IActionResult> SearchAsync(
            [FromQuery] SoftwareSearchRequest searchRequest,
            CancellationToken cancellationToken)
        {
            var searchResponse = await softwareService.SearchAsync(searchRequest, cancellationToken);

            return Ok(searchResponse);
        }
    }
}