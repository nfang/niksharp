using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikDefinition : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "partOfSpeech")]
        public string PartOfSpeech { get; set; }
        [JsonProperty(PropertyName = "sourceDictionary")]        
        public string SourceDictionary { get; set; }
        [JsonProperty(PropertyName = "sequence")]
        public int Sequence { get; set; }
    }

    [Serializable]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikSimpleDefinition : WordnikResponseModel
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "partOfSpeech")]
        public string PartOfSpeech { get; set; }
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
    }
}
