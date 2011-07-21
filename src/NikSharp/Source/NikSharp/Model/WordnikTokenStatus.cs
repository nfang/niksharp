using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikTokenStatus : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "valid")]
        public bool Valid { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "expiresInMillis")]
        public double ExpiresInMillis { get; set; }
        [JsonProperty(PropertyName = "totalRequests")]
        public int TotalRequests { get; set; }
        [JsonProperty(PropertyName = "remainingCalls")]
        public int RemainingCalls { get; set; }
        [JsonProperty(PropertyName = "resetsInMillis")]
        public double ResetsInMillis { get; set; }
    }
}
