using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class CharacterFileSource
    {
        public async Task<List<Character>> GetCharacterFromFile(string path)
             =>  JsonConvert.DeserializeObject<List<Character>>(await File.ReadAllTextAsync(path));
    }
}
