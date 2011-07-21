using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikSharp.Model;
using System.Collections.Specialized;
using Hammock.Web;
using NikSharp.Utility;

namespace NikSharp
{
    public partial class WordnikService : IWordnikService
    {
        #region Synchronous methods
        public WordnikWordList GetWordList(string permaLink)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            return PerformWebRequest<WordnikWordList>(WebMethod.Get, null, headers, string.Format(GlobalVars.WLWordListBasePath, ApiResponseFormat, permaLink));
        }

        public void DeleteWords(string permaLink, IEnumerable<string> wordsToDelete)
        {
            if (AuthToken == null) return;
            if (!ValidationUtil.RequiredString(permaLink)) return;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            headers.Add("Content-Type", "application/json");

            StringBuilder builder = new StringBuilder();
#if NET40
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToDelete)));
#else
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToDelete.ToArray())));
#endif

            PerformWebRequest(WebMethod.Post, builder.ToString(), headers, string.Format(GlobalVars.WLDeleteWordsBasePath, ApiResponseFormat, permaLink));
        }

        public IEnumerable<WordnikWordListWord> GetWords(string permaLink, string sortBy = null, string sortOrder = null, int? skip = null, int? limit = null)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return PerformWebRequest<IEnumerable<WordnikWordListWord>>(WebMethod.Get, null, headers, string.Format(GlobalVars.WLFetchWordsBasePath, ApiResponseFormat, permaLink),
                "sortBy", sortBy, "sortOrder", sortOrder, "skip", skip, "limit", limit);
        }

        public void AddWords(string permaLink, IEnumerable<string> wordsToAdd)
        {
            if (AuthToken == null) return;
            if (!ValidationUtil.RequiredString(permaLink)) return;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            headers.Add("Content-Type", "application/json");

            StringBuilder builder = new StringBuilder();
#if NET40
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToAdd)));
#else
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToAdd.ToArray())));
#endif

            PerformWebRequest(WebMethod.Post, builder.ToString(), headers, string.Format(GlobalVars.WLAddWordsBasePath, ApiResponseFormat, permaLink));
        }

        public void DeleteWordList(string permaLink)
        {
            if (AuthToken == null) return;
            if (!ValidationUtil.RequiredString(permaLink)) return;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            PerformWebRequest(WebMethod.Delete, null, headers, string.Format(GlobalVars.WLDeleteWordListBasePath, ApiResponseFormat, permaLink));
        }

        public WordnikWordList CreateWordList(string name, string description, string type)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(name)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            headers.Add("Content-Type", "application/json");

            WordnikNewWordList nwl = new WordnikNewWordList()
            {
                Name = name,
                Description = description,
                Type = type
            };
            return PerformWebRequest<WordnikWordList>(WebMethod.Post, nwl.ToJson(), headers, string.Format(GlobalVars.WLCreateWordListBasePath, ApiResponseFormat));
        } 
        #endregion

        #region Asynchronous methods
        public IAsyncResult BeginGetWordList(string permaLink)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            return BeginPerformWebRequest<WordnikWordList>(WebMethod.Get, null, headers, string.Format(GlobalVars.WLWordListBasePath, ApiResponseFormat, permaLink));
        }

        public WordnikWordList EndGetWordList(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikWordList>(result);
        }

        public IAsyncResult BeginDeleteWords(string permaLink, IEnumerable<string> wordsToDelete)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            headers.Add("Content-Type", "application/json");

            StringBuilder builder = new StringBuilder();
#if NET40
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToDelete)));
#else
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToDelete.ToArray())));
#endif

            return BeginPerformWebRequest(WebMethod.Post, builder.ToString(), headers, string.Format(GlobalVars.WLDeleteWordsBasePath, ApiResponseFormat, permaLink));
        }

        public void EndDeleteWords(IAsyncResult result)
        {
            EndPerformWebRequest(result);
        }

        public IAsyncResult BeginGetWords(string permaLink, string sortBy = null, string sortOrder = null, int? skip = null, int? limit = null)
        {
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return BeginPerformWebRequest<IEnumerable<WordnikWordListWord>>(WebMethod.Get, null, headers, string.Format(GlobalVars.WLFetchWordsBasePath, ApiResponseFormat, permaLink),
                "sortBy", sortBy, "sortOrder", sortOrder, "skip", skip, "limit", limit);
        }

        public IEnumerable<WordnikWordListWord> EndGetWords(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikWordListWord>>(result);
        }

        public IAsyncResult BeginAddWords(string permaLink, IEnumerable<string> wordsToAdd)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            headers.Add("Content-Type", "application/json");

            StringBuilder builder = new StringBuilder();
#if NET40
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToAdd)));
#else
            builder.Append(string.Format("[\"{0}\"]", string.Join("\",\"", wordsToAdd.ToArray())));
#endif
            return BeginPerformWebRequest(WebMethod.Post, builder.ToString(), headers, string.Format(GlobalVars.WLAddWordsBasePath, ApiResponseFormat, permaLink));
        }

        public void EndAddWords(IAsyncResult result)
        {
            EndPerformWebRequest(result);
        }

        public IAsyncResult BeginDeleteWordList(string permaLink)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(permaLink)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return BeginPerformWebRequest(WebMethod.Delete, null, headers, string.Format(GlobalVars.WLDeleteWordListBasePath, ApiResponseFormat, permaLink));
        }

        public void EndDeleteWordList(IAsyncResult result)
        {
            EndPerformWebRequest(result);
        }

        public IAsyncResult BeginCreateWordList(string name, string description, string type)
        {
            if (AuthToken == null) return null;
            if (!ValidationUtil.RequiredString(name)) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);
            headers.Add("Content-Type", "application/json");

            WordnikNewWordList nwl = new WordnikNewWordList()
            {
                Name = name,
                Description = description,
                Type = type
            };
            return BeginPerformWebRequest<WordnikWordList>(WebMethod.Post, nwl.ToJson(), headers, string.Format(GlobalVars.WLCreateWordListBasePath, ApiResponseFormat));
        }

        public WordnikWordList EndCreateWordList(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikWordList>(result);
        } 
        #endregion
    }
}
