namespace Builder
{
    public class CarManualBuider : ICarBuilder
    {
        public Car Build()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public ICarBuilder WithComputer(bool gps)
        {
            throw new System.NotImplementedException();
        }

        public ICarBuilder WithEngineHp(int hp)
        {
            throw new System.NotImplementedException();
        }

        public ICarBuilder WithGPS(bool computer)
        {
            throw new System.NotImplementedException();
        }

        public ICarBuilder WithNumberOfDoors(int number)
        {
            throw new System.NotImplementedException();
        }
    }
}
