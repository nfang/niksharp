using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikWordList : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }
        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty(PropertyName = "numberWordsInList")]
        public long NumberWordsInList { get; set; }
    }
}
