using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace APIVersion.Controllers.v2
{

    [ApiVersion("2.0")]
     [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult Get() => Ok("👋 Hello API - Version 2");
    }

}