using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace APIVersion.Controllers.v1
{
    
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult Get() => Ok("👋 Hello API - Version 1");
        }
    }