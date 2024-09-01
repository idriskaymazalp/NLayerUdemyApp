using Microsoft.AspNetCore.Mvc;

namespace NLayer.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DateController : ControllerBase
    {
        private readonly ILogger<DateController> _logger;

        public DateController(ILogger<DateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetToday()
        {
            Response response = new Response() 
            {
                Basarili= "Evet",
                Sonuc= DateTime.Now.ToString()
            };  

            return Ok(response);
        }
    }

    public class Response
    {
        public string Sonuc { get; set; }
        public string Basarili { get; set; }
    }
}
