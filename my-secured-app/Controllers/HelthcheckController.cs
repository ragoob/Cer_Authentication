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
        public async Task<IActionResult> GetAsync()
        {
            var Cert = await HttpContext.Connection.GetClientCertificateAsync();
            if (Cert != null)
            {
                Console.WriteLine(Cert.SubjectName.Name);

            }
            else
            {
                Console.WriteLine("No Cert Recived to server");
            }
            return Ok(new { 
            appName = "my-secured-app",
            appVersion = "1.0"
            });
        }
    }
}