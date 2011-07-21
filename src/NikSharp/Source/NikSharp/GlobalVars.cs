using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikSharp
{
    public static class GlobalVars
    {
        public const string WordnikAPIAuthority = @"http://api.wordnik.com/";

        public const string AccountAuthenticationBasePath = @"/account.{0}/authenticate/{1}";
        public const string AccountTokenStatusBasePath = @"/account.{0}/apiTokenStatus";
        public const string AccountUserBasePath = @"/account.{0}/user";
        public const string AccountWordListsBasePath = @"/account.{0}/wordLists";

        public const string WordWordBasePath = @"/word.{0}/{1}";
        public const string WordExamplesBasePath = @"/word.{0}/{1}/examples";
        public const string WordDefinitionsBasePath = @"/word.{0}/{1}/definitions";
        public const string WordFrequencyBasePath = @"/word.{0}/{1}/frequency";
        public const string WordTopExampleBasePath = @"/word.{0}/{1}/topExample";
        public const string WordRelatedBasePath = @"/word.{0}/{1}/related";
        public const string WordPhrasesBasePath = @"/word.{0}/{1}/phrases";
        public const string WordHyphenationBasePath = @"/word.{0}/{1}/hyphenation";
        public const string WordPronunciationsBasePath = @"/word.{0}/{1}/pronunciations";
        public const string WordAudioBasePath = @"/word.{0}/{1}/audio";

        public const string WordsRandomWordBasePath = @"/words.{0}/randomWord";
        public const string WordsRandomWordsBasePath = @"/words.{0}/randomWords";
        public const string WordsSearchWordBasePath = @"/words.{0}/search";
        public const string WordsWordOfTheDayBasePath = @"/words.{0}/wordOfTheDay";
        public const string WordsSearchQueryBasePath = @"/words.{0}/search/{1}";

        public const string WLWordListBasePath = @"/wordList.{0}/{1}";
        public const string WLDeleteWordsBasePath = @"/wordList.{0}/{1}/deleteWords";
        public const string WLFetchWordsBasePath = @"/wordList.{0}/{1}/words";
        public const string WLAddWordsBasePath = @"/wordList.{0}/{1}/words";
        public const string WLUpdateWordListBasePath = @"/wordList.{0}/{1}"; // PUT Method
        public const string WLDeleteWordListBasePath = @"/wordList.{0}/{1}"; // DELETE Method
        public const string WLCreateWordListBasePath = @"/wordLists.{0}";
    }
}
