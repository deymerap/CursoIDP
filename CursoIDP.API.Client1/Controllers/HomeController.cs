using CursoIDP.API.Client1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CursoIDP.API.Client1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Temperatura()
        {
            var vHttpClient = _clientFactory.CreateClient("APIClient");
            var vResponse = await vHttpClient.GetAsync("api/weatherforecast").ConfigureAwait(false);
            vResponse.EnsureSuccessStatusCode();

            var vJson = await vResponse.Content.ReadAsStringAsync();
            var temp = JsonSerializer.Deserialize<List<WeatherForecastModel>>(vJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(temp);
        }
    }
}
