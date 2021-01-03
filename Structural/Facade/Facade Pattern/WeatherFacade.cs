using Facade.Entities;
using Facade.Services;

namespace Facade
{
    public class WeatherFacade : IWeatherFacade
    {
        private readonly ConverterService _converterService;
        private readonly GeoLookupService _geoLookupService;
        private readonly WeatherService _weatherService;

        public WeatherFacade(): this(new ConverterService(), new GeoLookupService(), new WeatherService())
        {

        }

        public WeatherFacade(ConverterService  converterService,GeoLookupService geoLookupService, WeatherService weatherService )
        {
            _converterService = converterService;
            _geoLookupService = geoLookupService;
            _weatherService = weatherService;
        }

        public WeatherFacadeDto GetTemperatureInCity(string zipCode)
        {

            City city = _geoLookupService.GetCityForZipCode(zipCode);
            State state = _geoLookupService.GetStateForZipCode(zipCode);

            int fahrenheit = _weatherService.GetTempFahrenheit(city, state);
            int celcius = _converterService.ConvertFahrenheitToCelcious(fahrenheit);

            return new WeatherFacadeDto
            {
                State = state,
                City = city,
                Celsius = celcius,
                Fehrenheit = fahrenheit
            };
        }
    }
}
