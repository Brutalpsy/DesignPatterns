using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class StarWarsApi
    {
        public async Task<List<Person>> GetCharacters()
        {
            using (var client = new HttpClient())
            {
                var url = "https://swapi.dev/api/people/";
                var result = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
            }
        }
    }
}