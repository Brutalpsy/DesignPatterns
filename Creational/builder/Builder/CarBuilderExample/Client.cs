namespace Builder
{
    public class Client
    {
        public Car GetSportsCar()
        {
            var director = new CarDirector();
            var builder = new CarBuilder();

            return director.BuildSportsCar(builder);
        }

        public Car GetRegularCarWithoutGps() 
        {
           return new CarBuilder()
               .WithNumberOfDoors(3)
               .WithComputer(false)
               .WithEngineHp(116)
               .WithGPS(false)
               .Build();
        }
    }
}
