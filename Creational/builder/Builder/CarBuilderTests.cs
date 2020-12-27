using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder
{
    [TestClass]
    public class CarBuilderTests
    {
        private readonly Client _client = new Client();

        [TestMethod]
        public void ShouldNotReturnSUV()
        {
            var suv = new CarBuilder()
                .WithGPS(true)
                .WithEngineHp(200)
                .WithNumberOfDoors(5)
                .Build();

            var result = _client.GetRegularCarWithoutGps();

            Assert.AreNotEqual(suv.EngineHP, result.EngineHP);
            Assert.AreNotEqual(suv.NumberOfDoors, result.NumberOfDoors);
        }

        [TestMethod]
        public void ShouldReturnSportsCar()
        {
            var regularCar = new CarBuilder()
                .WithEngineHp(650)
                .WithGPS(true)
                .WithComputer(true)
                .WithNumberOfDoors(2)
                .Build();

            var result = _client.GetSportsCar();

            Assert.AreEqual(regularCar.Computer, result.Computer);
            Assert.AreEqual(regularCar.GPS, result.GPS);
            Assert.AreEqual(regularCar.EngineHP, result.EngineHP);
            Assert.AreEqual(regularCar.NumberOfDoors, result.NumberOfDoors);
        }

        [TestMethod]
        public void ShouldReturnGetRegularCarWithoutGps()
        {
            var regularCar = new CarBuilder()
                 .WithNumberOfDoors(3)
                 .WithComputer(false)
                 .WithEngineHp(116)
                 .WithGPS(false)
                 .Build();

            var result = _client.GetRegularCarWithoutGps();

            Assert.AreEqual(regularCar.Computer, result.Computer);
            Assert.AreEqual(regularCar.GPS, result.GPS);
            Assert.AreEqual(regularCar.EngineHP, result.EngineHP);
            Assert.AreEqual(regularCar.NumberOfDoors, result.NumberOfDoors);
        }
    }
}
