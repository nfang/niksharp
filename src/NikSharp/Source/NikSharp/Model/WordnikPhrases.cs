using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikPhrases : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "gram1")]
        public string Gram1 { get; set; }
        [JsonProperty(PropertyName = "gram2")]
        public string Gram2 { get; set; }
        [JsonProperty(PropertyName = "mi")]
        public decimal MI { get; set; }
        [JsonProperty(PropertyName = "wlmi")]
        public decimal WLMI { get; set; }
    }
}
