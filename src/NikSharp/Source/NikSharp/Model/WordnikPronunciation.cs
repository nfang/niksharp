using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikPronunciation : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "seq")]
        public int Seq { get; set; }
        [JsonProperty(PropertyName = "raw")]
        public string Raw { get; set; }
        [JsonProperty(PropertyName = "rawType")]
        public string RawType { get; set; }
    }
}
