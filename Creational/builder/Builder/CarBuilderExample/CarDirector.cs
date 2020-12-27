namespace Builder
{
    public class CarDirector
    {
        private ICarBuilder _carBuilder;

        public void SetBuilder(ICarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
        }

        public Car BuildSportsCar(ICarBuilder carBuilder)
        {
           return carBuilder
                .WithEngineHp(650)
                .WithGPS(true)
                .WithComputer(true)
                .WithNumberOfDoors(2).Build();
        }
    }
}
