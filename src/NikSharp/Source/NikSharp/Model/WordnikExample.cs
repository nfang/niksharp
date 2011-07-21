using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikExample : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }
        [JsonProperty(PropertyName = "provider")]
        public WordnikExampleProvider Provider { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "rating")]
        public decimal Rating { get; set; }
        [JsonProperty(PropertyName = "exampleId")]
        public long ExampleId { get; set; }
        [JsonProperty(PropertyName = "documentId")]
        public long DocumentId { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikSimpleExample : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikExampleProvider
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikExampleCollection : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "examples")]
        public IEnumerable<WordnikExample> Examples { get; set; }
        [JsonProperty(PropertyName = "totalResults")]
        public int TotalResults { get; set; }
    }
}
