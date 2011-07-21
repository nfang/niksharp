using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikFrequencyCollection : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty(PropertyName = "frequency")]
        public List<WordnikFrequency> Frequency { get; set; }
        [JsonProperty(PropertyName = "unknownYearCount")]
        public int UnknownYearCount { get; set; }
    }

    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikFrequency
    {
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }

    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikWordFrequency : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "wordstring")]
        public string WordString { get; set; }
        [JsonProperty(PropertyName = "count")]
        public long Count { get; set; }
    }
}
