using Microsoft.Extensions.Caching.Memory;
using System;

namespace DecoratorDesignPattern.WeatherInterface
{
    public class WeatherServiceCashingDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherService;
        private readonly IMemoryCache _memoryCache;
        public WeatherServiceCashingDecorator(IWeatherService weatherService, IMemoryCache memoryCache)
        {
            _weatherService = weatherService;
            _memoryCache = memoryCache;
        }

        public CurrentWeather GetCurrentWeather(string location)
        {
            var cacheKey = $"WeatherConditions::{location}";
            if(_memoryCache.TryGetValue<CurrentWeather>(cacheKey, out var currentWeather))
            {
                return currentWeather;
            }

            var currentConditions = _weatherService.GetCurrentWeather(location);
            _memoryCache.Set<CurrentWeather>(cacheKey, currentConditions, TimeSpan.FromMinutes(30));

            return currentConditions;

        }

        public LocationForecast GetForecast(string location)
        {
            var cacheKey = $"WeatherForecast::{location}";
            if (_memoryCache.TryGetValue<LocationForecast>(cacheKey, out var forecast))
            {
                return forecast;
            }

            var currentForecast = _weatherService.GetForecast(location);
            _memoryCache.Set<LocationForecast>(cacheKey, currentForecast, TimeSpan.FromMinutes(30));

            return currentForecast;
        }
    }
}
