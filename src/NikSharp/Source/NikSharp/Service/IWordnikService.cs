using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikSharp.Model;
using System.Net;

namespace NikSharp
{
    /// <summary>
    /// <seealso cref="http://developer.wordnik.com/doc"/>
    /// </summary>
    public interface IWordnikService
    {
        HttpWebResponse LastHttpResponse { get; set; }

        #region Synchronous methods
        /// <summary>
        /// Authenticates a User
        /// </summary>
        WordnikToken Authenticate(string username, string password);
        /// <summary>
        /// Returns usage statistics for the API account
        /// </summary>
        WordnikTokenStatus GetTokenStatus();
        /// <summary>
        /// Returns the logged-in User
        /// </summary>
        WordnikUser GetUser();
        /// <summary>
        /// Fetches WordList objects for the logged-in User
        /// </summary>
        IEnumerable<WordnikWordList> GetUserWordList(int? skip = null, int? limit = null);
        /// <summary>
        /// Get a word as a string, returns the WordObject that represents it
        /// </summary>
        WordnikWord GetWord(string word, bool? useCanonical = null, bool? includeSuggestions = null);
        /// <summary>
        /// Returns examples for a word
        /// </summary>
        WordnikExampleCollection GetExamples(string word, int? limit = null, bool? includeDuplicates = null, string contentProvider = null, bool? useCanonical = null);
        /// <summary>
        /// Returns definitions for a word
        /// </summary>
        IEnumerable<WordnikDefinition> GetDefinitions(string word, int? limit = null, string partOfSpeech = null, bool? includeRelated = null, string sourceDictionaries = null, bool? useCanonical = null, bool? includeTags = null);
        /// <summary>
        /// Returns word usage over time
        /// </summary>
        WordnikFrequencyCollection GetFrequency(string word, bool? useCanonical = null, int? startYear = null, int? endYear = null);
        /// <summary>
        /// Returns a top example for a word
        /// </summary>
        WordnikExample GetTopExample(string word, string contentProvider = null, bool? useCanonical = null);
        /// <summary>
        /// Return related words (thesaurus data) for a word
        /// </summary>
        IEnumerable<WordnikRelatedWords> GetRelatedWords(string word, string partOfSpeech = null, string sourceDictionary = null, int? limit = null, bool? useCanonical = null, string type = null);
        /// <summary>
        /// Fetches bi-gram phrases for a word
        /// </summary>
        IEnumerable<WordnikPhrases> GetPhrases(string word, int? limit = null, decimal? wlmi = null, bool? useCanonical = null);
        /// <summary>
        /// Returns syllable information for a word
        /// </summary>
        IEnumerable<WordnikHyphenation> GetHyphenation(string word, bool? useCanonical = null, string sourceDictionary = null, int? limit = null);
        /// <summary>
        /// Returns text pronunciations for a given word
        /// </summary>
        IEnumerable<WordnikPronunciation> GetPronunciations(string word, bool? useCanonical = null, string sourceDictionary = null, string typeFormat = null, int? limit = null);
        /// <summary>
        /// Fetches audio metadata for a word
        /// </summary>
        IEnumerable<WordnikAudio> GetAudio(string word, bool? useCanonical = null, int? limit = null);

        WordnikWord GetRandomWord(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null);

        IEnumerable<WordnikWord> GetRandomWords(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, string sortBy = null, string sortOrder = null, int? limit = null);

        IEnumerable<WordnikWordFrequency> SearchWord(string word, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null);

        WordnikWordOfTheDay GetWordOfTheDay(DateTime? date = null, string category = null, string creator = null);

        WordnikSearchResultCollection SearchQuery(string query, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null);

        WordnikWordList GetWordList(string permaLink);

        void DeleteWords(string permaLink, IEnumerable<string> wordsToDelete);

        IEnumerable<WordnikWordListWord> GetWords(string permaLink, string sortBy = null, string sortOrder = null, int? skip = null, int? limit = null);

        void AddWords(string permaLink, IEnumerable<string> wordsToAdd);

        void DeleteWordList(string permaLink);

        WordnikWordList CreateWordList(string name, string description, string type); 
        #endregion

        #region Asynchronous methods

        IAsyncResult BeginGetTokenStatus();

        WordnikTokenStatus EndGetTokenStatus(IAsyncResult result);

        IAsyncResult BeginGetUser();

        WordnikUser EndGetUser(IAsyncResult result);

        IAsyncResult BeginGetUserWordList(int? skip = null, int? limit = null);

        IEnumerable<WordnikWordList> EndGetUserWordList(IAsyncResult result);

        IAsyncResult BeginGetWord(string word, bool? useCanonical = null, bool? includeSuggestions = null);

        WordnikWord EndGetWord(IAsyncResult result);

        IAsyncResult BeginGetExamples(string word, int? limit = null, bool? includeDuplicates = null, string contentProvider = null, bool? useCanonical = null);

        WordnikExampleCollection EndGetExamples(IAsyncResult result);

        IAsyncResult BeginGetDefinitions(string word, int? limit = null, string partOfSpeech = null, bool? includeRelated = null, string sourceDictionaries = null, bool? useCanonical = null, bool? includeTags = null);

        IEnumerable<WordnikDefinition> EndGetDefinitions(IAsyncResult result);

        IAsyncResult BeginGetFrequency(string word, bool? useCanonical = null, int? startYear = null, int? endYear = null);

        WordnikFrequencyCollection EndGetFrequency(IAsyncResult result);

        IAsyncResult BeginGetTopExample(string word, string contentProvider = null, bool? useCanonical = null);

        WordnikExample EndGetTopExample(IAsyncResult result);

        IAsyncResult BeginGetRelatedWords(string word, string partOfSpeech = null, string sourceDictionary = null, int? limit = null, bool? useCanonical = null, string type = null);

        IEnumerable<WordnikRelatedWords> EndGetRelatedWords(IAsyncResult result);

        IAsyncResult BeginGetPhrases(string word, int? limit = null, decimal? wlmi = null, bool? useCanonical = null);

        IEnumerable<WordnikPhrases> EndGetPhrases(IAsyncResult result);

        IAsyncResult BeginGetHyphenations(string word, bool? useCanonical = null, string sourceDictionary = null, int? limit = null);

        IEnumerable<WordnikHyphenation> EndGetHyphenations(IAsyncResult result);

        IAsyncResult BeginGetPronunciations(string word, bool? useCanonical = null, string sourceDictionary = null, string typeFormat = null, int? limit = null);

        IEnumerable<WordnikPronunciation> EndGetPronunciations(IAsyncResult result);

        IAsyncResult BeginGetAudios(string word, bool? useCanonical, int? limit);

        IEnumerable<WordnikAudio> EndGetAudios(IAsyncResult result);

        IAsyncResult BeginGetRandomWord(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null);

        WordnikWord EndGetRandomWord(IAsyncResult result);

        IAsyncResult BeginGetRandomWords(bool? hasDictionaryDef = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, string sortBy = null, string sortOrder = null, int? limit = null);

        IEnumerable<WordnikWord> EndGetRandomWords(IAsyncResult result);

        IAsyncResult BeginSearchWord(string word, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null);

        IEnumerable<WordnikWordFrequency> EndSearchWord(IAsyncResult result);

        IAsyncResult BeginGetWordOfTheDay(DateTime? date = null, string category = null, string creator = null);

        WordnikWordOfTheDay EndGetWordOfTheDay(IAsyncResult result);

        IAsyncResult BeginSearchQuery(string query, bool? caseSensitive = null, string includePartOfSpeech = null, string excludePartOfSpeech = null, int? minCorpusCount = null, int? maxCorpusCount = null,
            int? minDictionaryCount = null, int? maxDictionaryCount = null, int? minLength = null, int? maxLength = null, int? skip = null, int? limit = null);

        WordnikSearchResultCollection EndSearchQuery(IAsyncResult result);

        IAsyncResult BeginGetWordList(string permaLink);

        WordnikWordList EndGetWordList(IAsyncResult result);

        IAsyncResult BeginDeleteWords(string permaLink, IEnumerable<string> wordsToDelete);

        void EndDeleteWords(IAsyncResult result);

        IAsyncResult BeginGetWords(string permaLink, string sortBy = null, string sortOrder = null, int? skip = null, int? limit = null);

        IEnumerable<WordnikWordListWord> EndGetWords(IAsyncResult result);

        IAsyncResult BeginAddWords(string permaLink, IEnumerable<string> wordsToAdd);

        void EndAddWords(IAsyncResult result);

        IAsyncResult BeginDeleteWordList(string permaLink);

        void EndDeleteWordList(IAsyncResult result);

        IAsyncResult BeginCreateWordList(string name, string description, string type);

        WordnikWordList EndCreateWordList(IAsyncResult result);
        #endregion
    }
}
