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
        public WordnikToken Authenticate(string username, string password)
        {
            if (!ValidationUtil.RequiredString(username) || !ValidationUtil.RequiredString(password)) return null;

            var token = PerformWebRequest<WordnikToken>(WebMethod.Post, password,
                string.Format(GlobalVars.AccountAuthenticationBasePath, ApiResponseFormat, username));
            AuthToken = token;
            return token;
        }

        public WordnikTokenStatus GetTokenStatus()
        {
            return PerformWebRequest<WordnikTokenStatus>(string.Format(GlobalVars.AccountTokenStatusBasePath, ApiResponseFormat));
        }

        public WordnikUser GetUser()
        {
            if (AuthToken == null)
                return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return PerformWebRequest<WordnikUser>(WebMethod.Get, null, headers, string.Format(GlobalVars.AccountUserBasePath, ApiResponseFormat));
        }

        public IEnumerable<WordnikWordList> GetUserWordList(int? skip = null, int? limit = null)
        {
            if (AuthToken == null) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return PerformWebRequest<IEnumerable<WordnikWordList>>(WebMethod.Get, null, headers,
                string.Format(GlobalVars.AccountWordListsBasePath, ApiResponseFormat));
        } 
        #endregion

        #region Asynchronous methods
        public IAsyncResult BeginGetTokenStatus()
        {
            return BeginPerformWebRequest<WordnikTokenStatus>(string.Format(GlobalVars.AccountTokenStatusBasePath, ApiResponseFormat));
        }

        public WordnikTokenStatus EndGetTokenStatus(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikTokenStatus>(result);
        }

        public IAsyncResult BeginGetUser()
        {
            if (AuthToken == null) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return BeginPerformWebRequest<WordnikUser>(WebMethod.Get, null, headers, string.Format(GlobalVars.AccountUserBasePath, ApiResponseFormat));
        }

        public WordnikUser EndGetUser(IAsyncResult result)
        {
            return EndPerformWebRequest<WordnikUser>(result);
        }

        public IAsyncResult BeginGetUserWordList(int? skip = null, int? limit = null)
        {
            if (AuthToken == null) return null;

            var headers = new NameValueCollection();
            headers.Add("auth_token", AuthToken.Token);

            return BeginPerformWebRequest<IEnumerable<WordnikWordList>>(WebMethod.Get, null, headers,
                string.Format(GlobalVars.AccountWordListsBasePath, ApiResponseFormat));
        }

        public IEnumerable<WordnikWordList> EndGetUserWordList(IAsyncResult result)
        {
            return EndPerformWebRequest<IEnumerable<WordnikWordList>>(result);
        } 
        #endregion
    }
}
