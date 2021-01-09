using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        private readonly StarWarsApi _starWarsApi;

        public StarWarsApiCharacterSourceAdapter() :this(new StarWarsApi())
        {
        }

        public StarWarsApiCharacterSourceAdapter(StarWarsApi starWarsApi)
        {
            _starWarsApi = starWarsApi;
        }

        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await _starWarsApi.GetCharacters();
        }
    }
}
