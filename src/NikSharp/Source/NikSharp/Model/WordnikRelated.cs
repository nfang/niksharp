using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikSharp.Model.Enums;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikRelatedWords : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "words")]
        public List<string> Words { get; set; }
        [JsonProperty(PropertyName = "relationshipType")]
        public string RelationshipType { get; set; }
    }
}
