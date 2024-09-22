using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using System.Diagnostics;

namespace NLayer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BugunGunlerdenNeAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7142/");
                Response? response = await httpClient.GetFromJsonAsync<Response>("/Date/GetToday");

                ViewData["BugünTarih"] = response.Sonuc;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Warning, "Kullanici Id" + ex.Message);
            }


            return View();
        }

        public class Response
        {
            public string Sonuc { get; set; }
            public string Basarili { get; set; }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            //Check 2
            return View(errorViewModel);
        }
    }
}
