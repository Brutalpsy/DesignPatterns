
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AdapterPattern
{
    public class TestRunner
    {
        private readonly ITestOutputHelper _output;
        public TestRunner(ITestOutputHelper  testOutputHelper)
        {
            _output = testOutputHelper;
        }

        [Fact]
        public async Task DisplayCharactersFromFile()
        {
            var service = new StarWarsCharacterDisplayService(new CharacterFileSourceAdapter(@"Data/People.json"));

            var result = await service.ListCharacters();

            _output.WriteLine(result);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService(new StarWarsApiCharacterSourceAdapter());

            var result = await service.ListCharacters();

            _output.WriteLine(result);

            Assert.NotNull(result);
        }

    }
}