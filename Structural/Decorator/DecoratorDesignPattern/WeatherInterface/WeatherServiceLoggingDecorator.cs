using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DecoratorDesignPattern.WeatherInterface
{
    public class WeatherServiceLoggingDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<IWeatherService> _logger;

        public WeatherServiceLoggingDecorator(IWeatherService weatherService, ILogger<IWeatherService> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        public CurrentWeather GetCurrentWeather(string location)
        {
            var stopwatch = Stopwatch.StartNew();
            var currentWeather = _weatherService.GetCurrentWeather(location);

            stopwatch.Stop();
            var elapsedMilis = stopwatch.ElapsedMilliseconds;
            _logger.LogWarning($"Retrieved weather data for {location} - Elapsed ms: {elapsedMilis}");

            return currentWeather;
        }

        public LocationForecast GetForecast(string location)
        {
            var stopwatch = Stopwatch.StartNew();

            var forecast =  _weatherService.GetForecast(location);

            stopwatch.Stop();
            var elapsedMilis = stopwatch.ElapsedMilliseconds;
            _logger.LogWarning($"Retrieved forecast data for {location} - Elapsed ms: {elapsedMilis}");

            return forecast;
        }
    }
}
