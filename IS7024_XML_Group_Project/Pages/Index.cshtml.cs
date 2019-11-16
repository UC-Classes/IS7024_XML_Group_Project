using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickTypeCandy;
using QuickTypeWeather;

namespace IS7024_XML_Group_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
	        double temp = 0;
	        //pull in JSON stream for candy
		
	        string jsonString = GetData("https://raw.githubusercontent.com/UC-Classes/IS7024_XML_Group_Project/master/candyfile.txt");
	        var candy = Candy.FromJson(jsonString);
	        ViewData["Candy"] = candy;

	        // get our weather data and key
	        string weatherAPIKey = System.IO.File.ReadAllText("WeatherAPIKey.txt");
	        string weatherData = GetData("https://api.weatherbit.io/v2.0/current?&city=Cincinnati&country=USA&key=" + weatherAPIKey);

	        // parse to objects
	        QuickTypeWeather.Weather weather = QuickTypeWeather.Weather.FromJson(weatherData);
	        QuickTypeWeather.Datum[] allWeatherData = weather.Data;

	        //check temperature from weather data
	        foreach (QuickTypeWeather.Datum datum in allWeatherData)
	        {
		        temp = datum.Temp;
	        }
	        // if statement to show message temperature is below 5*C
	        if (temp < 5)
	        {
		        ViewData["WeatherMessage"] = "Bundle up, it's cold!";

	        }
	        else
	        {
		        ViewData["WeatherMessage"] = "Temperature is great!";

	        }
        }
        public string GetData(string endpoint)
        {
	        string downloadedData = "";
	        using (WebClient webClient = new WebClient())
	        {
		        downloadedData = webClient.DownloadString(endpoint);
		
	        }
	        return downloadedData;
        }
    }
}
