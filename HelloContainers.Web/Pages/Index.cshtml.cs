using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HelloContainers.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HelloContainers.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ILogger<IndexModel> _logger;
        private readonly string _remoteServiceBaseUrl;
        private HttpClient _httpClient;

        [BindProperty(SupportsGet = true)]
        public WeatherForecast[] WeatherItems { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            _remoteServiceBaseUrl = _config["ApiBaseUrl"];
        }

        public async Task OnGetAsync()
        {
            _httpClient = new HttpClient();
            var uri = _remoteServiceBaseUrl + "/weatherforecast";
            var responseString = await _httpClient.GetStringAsync(uri);

            WeatherItems = JsonConvert.DeserializeObject<WeatherForecast[]>(responseString);
        }
    }
}
