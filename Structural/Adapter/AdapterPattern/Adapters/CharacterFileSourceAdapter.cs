using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class CharacterFileSourceAdapter: ICharacterSourceAdapter
    {
        private readonly string _path;
        private readonly CharacterFileSource _characterFileSource;

        public CharacterFileSourceAdapter(string path): this(path, new CharacterFileSource())
        {

        }
        public CharacterFileSourceAdapter(string path, CharacterFileSource characterFileSource)
        {
            _path = path;
            _characterFileSource = characterFileSource;
        }

        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return (await _characterFileSource.GetCharacterFromFile(_path))
                .Select(character => new CharacterToPersonAdapter(character));
        }
    }
}
