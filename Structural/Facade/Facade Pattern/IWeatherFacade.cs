namespace Facade
{
    public interface IWeatherFacade
    {
       WeatherFacadeDto GetTemperatureInCity(string zipCode);
    }
}
