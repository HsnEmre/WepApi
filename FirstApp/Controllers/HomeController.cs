using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatusCode = 200,
                Message = "Hello Asp.Net Core Web APP"
            };

            return Ok(result);
            //Hatalı ise BadRequest
            //Bulunamadı ise badrequest 
        }
    }
}
