using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface ICharacterSourceAdapter
    {
        public Task<IEnumerable<Person>> GetCharacters();
    }
}
