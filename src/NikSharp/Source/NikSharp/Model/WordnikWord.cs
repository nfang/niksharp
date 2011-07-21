using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikWord : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "canonicalForm")]
        public string CanonicalForm { get; set; }
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "vulgar")]
        public string Vulgar { get; set; }
    }
}
