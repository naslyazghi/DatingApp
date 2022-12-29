using API.Data;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))] //Use our action filter
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {   

    }
}