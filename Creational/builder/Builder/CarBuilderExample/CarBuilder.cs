namespace Builder
{
    public class CarBuilder : ICarBuilder
    {
        private Car _car;
        public CarBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _car = new Car();
        }

        public ICarBuilder WithComputer(bool computer)
        {
            _car.Computer = computer;
            return this;
        }

        public ICarBuilder WithEngineHp(int hp)
        {
            _car.EngineHP = hp;
            return this;
        }

        public ICarBuilder WithGPS(bool gps)
        {
            _car.GPS = gps;
            return this;
        }

        public ICarBuilder WithNumberOfDoors(int number)
        {
            _car.NumberOfDoors = number;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }
}
