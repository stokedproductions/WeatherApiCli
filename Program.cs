using System;
using System.Threading.Tasks;
using WeatherService;
using PDFGenerator;
using DotNetEnv;

namespace MyWeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // get our city from the arguments if there is not one end the program else continue
            string city = string.Join(" ", args);
            if (city.Length == 0)
            {
                Console.WriteLine("You need to specify a City Name..");
                Console.WriteLine("USAGE: dotnet run Cape Town ");
                Environment.Exit(-1);
            }

            // Load our environment variable
            Env.Load();
            string? weatherAppApiToken = Environment.GetEnvironmentVariable("WEATHERAPP_API_TOKEN");
            if (weatherAppApiToken == null || weatherAppApiToken.Length == 0)
            {
                Console.Write("No API Key set in the .env file");
                Environment.Exit(-1);
            }

            // Get the weather report from our API if it does not return any then we exit;
            var weatherService = new WeatherService.WeatherService();
            WeatherData? weatherData = await WeatherService.WeatherService.GetWeatherDataAsync(city, weatherAppApiToken);
            if (weatherData != null)
            {
                // create a PDF if we got some data..
                PDFGenerator.PDFGenerator.GeneratePdf(weatherData, city);
            }
            else
            {
                Console.WriteLine("We did not getting any weather data for your request");
            }

        }

    }
}
