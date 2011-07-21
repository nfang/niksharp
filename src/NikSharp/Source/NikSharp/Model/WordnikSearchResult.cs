using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikSearchResult : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "count")]
        public long Count { get; set; }
        [JsonProperty(PropertyName = "lexicality")]
        public double Lexicality { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikSearchResultCollection : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "searchResults")]
        public List<WordnikSearchResult> SearchResults { get; set; }
        [JsonProperty(PropertyName = "totalResults")]
        public int TotalResults { get; set; }
    }
}
