using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HellowordController : ControllerBase
    {
        [HttpGet]
        public string index()
        {
            return "Hello Word!";
        }
    }
}
