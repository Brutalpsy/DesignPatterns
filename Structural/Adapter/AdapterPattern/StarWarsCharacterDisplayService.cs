using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class StarWarsCharacterDisplayService
    {
        private readonly ICharacterSourceAdapter _characterSourceAdapter;

        public StarWarsCharacterDisplayService(ICharacterSourceAdapter characterSourceAdapter)
        {
            _characterSourceAdapter = characterSourceAdapter;
        }

        public async Task<string> ListCharacters()
        {
            var people = await _characterSourceAdapter.GetCharacters();

            var sb = new StringBuilder();
            var nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)} HAIR");

            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)} {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}
