using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace my_secured_app.Controllers
{
    [Route("")]
    [ApiController]
    public class HelthcheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
            appName = "my-secured-app",
            appVersion = "1.0"
            });
        }
    }
}