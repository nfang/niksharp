using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikSharp.Model;
using NikSharp.Utility;
using System.Text.RegularExpressions;

namespace NikSharp
{
    public partial class WordnikService : IWordnikService
    {
        #region Synchronous methods
        public WordnikWord GetRandomWord(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null)
        {
            var resp = PerformWebRequest<WordnikWord>(string.Format(GlobalVars.WordsRandomWordBasePath, ApiResponseFormat), "hasDictionaryDef", hasDictionaryDef, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength);
            return resp;
        }

        public IEnumerable<WordnikWord> GetRandomWords(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, string sortBy = null, string sortOrder = null, int? limit = null)
        {
            var resp = PerformWebRequest<IEnumerable<WordnikWord>>(string.Format(GlobalVars.WordsRandomWordsBasePath, ApiResponseFormat), "hasDictionaryDef", hasDictionaryDef, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength);
            return resp;
        }

        public IEnumerable<WordnikWordFrequency> SearchWord(string word, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null)
        {
            if (!ValidationUtil.RequiredString(word)) return null;

            var resp = PerformWebRequest<IEnumerable<WordnikWordFrequency>>(string.Format(GlobalVars.WordsSearchWordBasePath, ApiResponseFormat), "query", word, "caseSensitive", caseSensitive, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength, "skip", skip, "limit", limit);
            return resp;
        }

        public WordnikWordOfTheDay GetWordOfTheDay(DateTime? date = null, string category = null, string creator = null)
        {
            string _date = null;
            if (date.HasValue)
                _date = date.Value.ToString("yyyy-MM-dd");

            return PerformWebRequest<WordnikWordOfTheDay>(string.Format(GlobalVars.WordsWordOfTheDayBasePath, ApiResponseFormat), "date", _date, "category", category, "creator", creator);
        }

        public WordnikSearchResultCollection SearchQuery(string query, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null)
        {
            if (!ValidationUtil.RequiredString(query)) return null;

            var resp = PerformWebRequest<WordnikSearchResultCollection>(string.Format(GlobalVars.WordsSearchQueryBasePath, ApiResponseFormat, query), "caseSensitive", caseSensitive, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength, "skip", skip, "limit", limit);
            return resp;
        }
        #endregion

        #region Asynchronous methods
        public IAsyncResult BeginGetRandomWord(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null)
        {
            var resp = BeginPerformWebRequest<WordnikWord>(string.Format(GlobalVars.WordsRandomWordBasePath, ApiResponseFormat), "hasDictionaryDef", hasDictionaryDef, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength);
            return resp;
        }

        public WordnikWord EndGetRandomWord(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikWord>(result);
        }

        public IAsyncResult BeginGetRandomWords(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, string sortBy = null, string sortOrder = null, int? limit = null)
        {
            var resp = BeginPerformWebRequest<IEnumerable<WordnikWord>>(string.Format(GlobalVars.WordsRandomWordsBasePath, ApiResponseFormat), "hasDictionaryDef", hasDictionaryDef, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength);
            return resp;
        }

        public IEnumerable<WordnikWord> EndGetRandomWords(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikWord>>(result);
        }

        public IAsyncResult BeginSearchWord(string word, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null)
        {
            if (!ValidationUtil.RequiredString(word)) return null;

            var resp = BeginPerformWebRequest<IEnumerable<WordnikWordFrequency>>(string.Format(GlobalVars.WordsSearchWordBasePath, ApiResponseFormat), "query", word, "caseSensitive", caseSensitive, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength, "skip", skip, "limit", limit);
            return resp;
        }

        public IEnumerable<WordnikWordFrequency> EndSearchWord(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikWordFrequency>>(result);
        }

        public IAsyncResult BeginGetWordOfTheDay(DateTime? date = null, string category = null, string creator = null)
        {
            string _date = null;
            if (date.HasValue)
                _date = date.Value.ToString("yyyy-MM-dd");

            return BeginPerformWebRequest<WordnikWordOfTheDay>(string.Format(GlobalVars.WordsWordOfTheDayBasePath, ApiResponseFormat), "date", _date, "category", category, "creator", creator);
        }

        public WordnikWordOfTheDay EndGetWordOfTheDay(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikWordOfTheDay>(result);
        }

        public IAsyncResult BeginSearchQuery(string query, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null)
        {
            if (!ValidationUtil.RequiredString(query)) return null;

            var resp = BeginPerformWebRequest<WordnikSearchResultCollection>(string.Format(GlobalVars.WordsSearchQueryBasePath, ApiResponseFormat, query), "caseSensitive", caseSensitive, "includePartOfSpeech", includePartOfSpeech,
                "excludePartOfSpeech", excludePartOfSpeech, "minCorpusCount", minCorpusCount, "maxCorpusCount", maxCorpusCount, "minDictionaryCount", minDictionaryCount, "maxDictionaryCount", maxDictionaryCount,
                "minLength", minLength, "maxLength", maxLength, "skip", skip, "limit", limit);
            return resp;
        }

        public WordnikSearchResultCollection EndSearchQuery(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikSearchResultCollection>(result);
        }
        #endregion
    }
}
