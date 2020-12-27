namespace Builder
{
    public interface ICarBuilder
    {
        void Reset();
        ICarBuilder WithNumberOfDoors(int number);
        ICarBuilder WithEngineHp(int hp);
        ICarBuilder WithComputer(bool gps);
        ICarBuilder WithGPS(bool computer);
        Car Build();
    }
}
