using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikWordListWord : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "numberCommentsOnWord")]
        public int NumberOfCommentsOnWord { get; set; }
        [JsonProperty(PropertyName = "numberLists")]
        public int NumberOfLists { get; set; }
    }
}
