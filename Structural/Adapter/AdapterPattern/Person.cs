using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdapterPattern
{
    public class Person
    {
        [JsonProperty("name")]
        public virtual string Name { get; set; }
        [JsonProperty("gender")]
        public virtual string Gender { get; set; }
        [JsonProperty("hair_color")]
        public virtual string HairColor { get; set; }
    }

    public class Character
    {
        [JsonProperty("name")]
        public string FullName { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("hair_color")]
        public string Hair { get; set; }
    }

    public enum ECharacterSource
    {
        File,
        Api
    }

    public class ApiResult<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
