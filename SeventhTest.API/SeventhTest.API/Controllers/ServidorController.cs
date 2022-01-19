using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeventhTest.API.Controllers
{
    [Route("api/server")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        [HttpGet("Ola")]
        public string Hello() 
        {
            return "Olá";
        }
    }
}
