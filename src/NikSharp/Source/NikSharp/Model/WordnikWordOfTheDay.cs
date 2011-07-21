using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikWordOfTheDay : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "examples")]
        public List<WordnikSimpleExample> Examples { get; set; }
        [JsonProperty(PropertyName = "definitions")]
        public List<WordnikSimpleDefinition> Definitions { get; set; }
        [JsonProperty(PropertyName = "contentProvider")]
        public WordnikExampleProvider ContentProvider { get; set; }
        [JsonProperty(PropertyName = "publishDate")]
        public DateTime PublishDate { get; set; }
        [JsonProperty(PropertyName = "parentId")]
        public string ParentId { get; set; }
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
        [JsonProperty(PropertyName = "htmlExtra")]
        public string HtmlExtra { get; set; }
    }
}
