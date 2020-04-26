using Microsoft.AspNetCore.Mvc;

namespace StarterWebApplication.Infrastructure
{
    [ApiController]
    [ApplicationExceptionFilter]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        
    }
}