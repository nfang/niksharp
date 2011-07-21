using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikSharp.Model;
using NikSharp.Utility;

namespace NikSharp
{
    public partial class WordnikService : IWordnikService
    {
        #region Synchronous methods
        public WordnikWord GetWord(string word, bool? useCanonical = null, bool? includeSuggestions = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<WordnikWord>(string.Format(GlobalVars.WordWordBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "includeSuggestions", includeSuggestions);
            return resp;
        }

        public WordnikExampleCollection GetExamples(string word, int? limit = null, bool? includeDuplicates = null, string contentProvider = null, bool? useCanonical = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<WordnikExampleCollection>(string.Format(GlobalVars.WordExamplesBasePath, ApiResponseFormat, word),
                "limit", limit, "includeDuplicates", includeDuplicates, "contentProvider", contentProvider, "useCanonical", useCanonical);
            return resp;
        }

        public IEnumerable<WordnikDefinition> GetDefinitions(string word, int? limit = null, string partOfSpeech = null, bool? includeRelated = null, string sourceDictionaries = null, 
            bool? useCanonical = null, bool? includeTags = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikDefinition>>(string.Format(GlobalVars.WordDefinitionsBasePath, ApiResponseFormat, word),
                "limit", limit, "partOfSpeech", partOfSpeech, "includeRelated", includeRelated, "sourceDictionaries", sourceDictionaries, "useCanonical", useCanonical,
                "includeTags", includeTags);
            return resp;
        }

        public WordnikFrequencyCollection GetFrequency(string word, bool? useCanonical = null, int? startYear = null, int? endYear = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<WordnikFrequencyCollection>(string.Format(GlobalVars.WordFrequencyBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "startYear", startYear, "endYear", endYear);
            return resp;
        }

        public WordnikExample GetTopExample(string word, string contentProvider = null, bool? useCanonical = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<WordnikExample>(string.Format(GlobalVars.WordTopExampleBasePath, ApiResponseFormat, word),
                "contentProvider", contentProvider, "useCanonical", useCanonical);
            return resp;
        }

        public IEnumerable<WordnikRelatedWords> GetRelatedWords(string word, string partOfSpeech = null, string sourceDictionary = null, int? limit = null, bool? useCanonical = null, string type = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikRelatedWords>>(string.Format(GlobalVars.WordRelatedBasePath, ApiResponseFormat, word),
                "partOfSpeech", partOfSpeech, "sourceDictionary", sourceDictionary, "limit", limit, "useCanonical", useCanonical, "type", type);
            return resp;
        }

        public IEnumerable<WordnikPhrases> GetPhrases(string word, int? limit = null, decimal? wlmi = null, bool? useCanonical = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikPhrases>>(string.Format(GlobalVars.WordPhrasesBasePath, ApiResponseFormat, word),
                "limit", limit, "wlmi", wlmi, "useCanonical", useCanonical);
            return resp;
        }

        public IEnumerable<WordnikHyphenation> GetHyphenation(string word, bool? useCanonical = null, string sourceDictionary = null, int? limit = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikHyphenation>>(string.Format(GlobalVars.WordHyphenationBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "sourceDictionary", sourceDictionary, "limit", limit);
            return resp;
        }

        public IEnumerable<WordnikPronunciation> GetPronunciations(string word, bool? useCanonical = null, string sourceDictionary = null, string typeFormat = null, int? limit = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikPronunciation>>(string.Format(GlobalVars.WordPronunciationsBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "sourceDictionary", sourceDictionary, "typeFormat", typeFormat, "limit", limit);
            return resp;
        }

        public IEnumerable<WordnikAudio> GetAudio(string word, bool? useCanonical = null, int? limit = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikAudio>>(string.Format(GlobalVars.WordAudioBasePath, ApiResponseFormat, word),
                "useCanonicalForm", useCanonical, "limit", limit);
            return resp;
        }
        #endregion

        #region Asynchronous methods
        public IAsyncResult BeginGetWord(string word, bool? useCanonical = null, bool? includeSuggestions = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            return BeginPerformWebRequest<WordnikWord>(string.Format(GlobalVars.WordWordBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "includeSuggestions", includeSuggestions);
        }

        public WordnikWord EndGetWord(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikWord>(result);
        }

        public IAsyncResult BeginGetExamples(string word, int? limit = null, bool? includeDuplicates = null, string contentProvider = null, bool? useCanonical = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<WordnikExampleCollection>(string.Format(GlobalVars.WordExamplesBasePath, ApiResponseFormat, word),
                "limit", limit, "includeDuplicates", includeDuplicates, "contentProvider", contentProvider, "useCanonical", useCanonical);
            return resp;
        }

        public WordnikExampleCollection EndGetExamples(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikExampleCollection>(result);
        }

        public IAsyncResult BeginGetDefinitions(string word, int? limit = null, string partOfSpeech = null, bool? includeRelated = null, string sourceDictionaries = null, bool? useCanonical = null, bool? includeTags = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikDefinition>>(string.Format(GlobalVars.WordDefinitionsBasePath, ApiResponseFormat, word),
                "limit", limit, "partOfSpeech", partOfSpeech, "includeRelated", includeRelated, "sourceDictionaries", sourceDictionaries, "useCanonical", useCanonical,
                "includeTags", includeTags);
            return resp;
        }

        public IEnumerable<WordnikDefinition> EndGetDefinitions(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikDefinition>>(result);
        }

        public IAsyncResult BeginGetFrequency(string word, bool? useCanonical = null, int? startYear = null, int? endYear = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<WordnikFrequencyCollection>(string.Format(GlobalVars.WordFrequencyBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "startYear", startYear, "endYear", endYear);
            return resp;
        }

        public WordnikFrequencyCollection EndGetFrequency(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikFrequencyCollection>(result);
        }

        public IAsyncResult BeginGetTopExample(string word, string contentProvider = null, bool? useCanonical = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<WordnikExample>(string.Format(GlobalVars.WordTopExampleBasePath, ApiResponseFormat, word),
                "contentProvider", contentProvider, "useCanonical", useCanonical);
            return resp;
        }

        public WordnikExample EndGetTopExample(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikExample>(result);
        }

        public IAsyncResult BeginGetRelatedWords(string word, string partOfSpeech = null, string sourceDictionary = null, int? limit = null, bool? useCanonical = null, string type = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikRelatedWords>>(string.Format(GlobalVars.WordRelatedBasePath, ApiResponseFormat, word),
                "partOfSpeech", partOfSpeech, "sourceDictionary", sourceDictionary, "limit", limit, "useCanonical", useCanonical, "type", type);
            return resp;
        }

        public IEnumerable<WordnikRelatedWords> EndGetRelatedWords(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikRelatedWords>>(result);
        }

        public IAsyncResult BeginGetPhrases(string word, int? limit = null, decimal? wlmi = null, bool? useCanonical = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikPhrases>>(string.Format(GlobalVars.WordPhrasesBasePath, ApiResponseFormat, word),
                "limit", limit, "wlmi", wlmi, "useCanonical", useCanonical);
            return resp;
        }

        public IEnumerable<WordnikPhrases> EndGetPhrases(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikPhrases>>(result);
        }

        public IAsyncResult BeginGetHyphenations(string word, bool? useCanonical = null, string sourceDictionary = null, int? limit = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikHyphenation>>(string.Format(GlobalVars.WordHyphenationBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "sourceDictionary", sourceDictionary, "limit", limit);
            return resp;
        }

        public IEnumerable<WordnikHyphenation> EndGetHyphenations(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikHyphenation>>(result);
        }

        public IAsyncResult BeginGetPronunciations(string word, bool? useCanonical = null, string sourceDictionary = null, string typeFormat = null, int? limit = null)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikPronunciation>>(string.Format(GlobalVars.WordPronunciationsBasePath, ApiResponseFormat, word),
                "useCanonical", useCanonical, "sourceDictionary", sourceDictionary, "typeFormat", typeFormat, "limit", limit);
            return resp;
        }

        public IEnumerable<WordnikPronunciation> EndGetPronunciations(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikPronunciation>>(result);
        }

        public IAsyncResult BeginGetAudios(string word, bool? useCanonical, int? limit)
        {
            if(!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikAudio>>(string.Format(GlobalVars.WordAudioBasePath, ApiResponseFormat, word),
                "useCanonicalForm", useCanonical, "limit", limit);
            return resp;
        }

        public IEnumerable<WordnikAudio> EndGetAudios(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikAudio>>(result);
        }
        #endregion
    }
}
