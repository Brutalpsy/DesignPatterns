using Facade.Entities;

namespace Facade
{
    public class WeatherFacadeDto
    {
        public int Fehrenheit { get; set; }
        public int Celsius { get; set; }
        public City City { get; set; }
        public State State { get; set; }
    }
}
