using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikSharp.Model;
using System.IO;
using System.Net;
//using System.Web.Script.Serialization;
using Hammock;
using NikSharp.Model.Enums;
using System.Reflection;
using NikSharp.Utility;
using NikSharp.Serialization;
using Hammock.Web;
using System.Collections.Specialized;
using NikSharp.Extension;

namespace NikSharp
{
    public partial class WordnikService : IWordnikService
    {
        private readonly RestClient _restClient;
        private readonly JsonNetSerializer _jsonSerializer;
        private string _defaultResponseFormat;

        //private WordnikService(string format)
        //{
        //    _restClient = new RestClient()
        //    {
        //        Authority = GlobalVars.WordnikAPIAuthority,
        //        VersionPath = "v4",
        //        UserAgent = "NikSharp"
        //    };
        //    _jsonSerializer = new JsonNetSerializer();
        //    ApiResponseFormat = (string.IsNullOrEmpty(format) ? ResponseFormat.Json : format);
        //}

        public WordnikService(string apiKey/*, string format*/)
            //: this("json")
        {
            _restClient = new RestClient()
            {
                Authority = GlobalVars.WordnikAPIAuthority,
                VersionPath = "v4",
                UserAgent = "NikSharp"
            };
            _restClient.AddHeader("api_key", apiKey);
            _jsonSerializer = new JsonNetSerializer();
            ApiResponseFormat = ResponseFormat.Json; // (string.IsNullOrEmpty(format) ? ResponseFormat.Json : format);
            this.ApiKey = apiKey;
        }

        public string ApiKey { get; private set; }

        public WordnikToken AuthToken { get; private set; }

        public string ApiResponseFormat
        {
            get { return _defaultResponseFormat; }
            set
            {
                if (_defaultResponseFormat == value) return;
                _defaultResponseFormat = value;
                if (ApiResponseFormat.Equals(ResponseFormat.Json))
                {
                    if (_restClient.Serializer == null || !(_restClient.Serializer is JsonNetSerializer))
                        _restClient.Serializer = _jsonSerializer;
                    if (_restClient.Deserializer == null || !(_restClient.Deserializer is JsonNetSerializer))
                        _restClient.Deserializer = _jsonSerializer;
                }
                if (ApiResponseFormat.Equals(ResponseFormat.Xml))
                {
                    throw new NotSupportedException("Xml format is not supported for now.");
                }

            }
        }

        public HttpWebResponse LastHttpResponse { get; set; }

        public WordnikError LastError { get; private set; }

        private void SetError(RestResponseBase response)
        {
            var _errorResponse = new RestResponse().Clone(response);
            _errorResponse.SetContent(response.Content);
            LastError = _restClient.Deserializer.Deserialize(_errorResponse, typeof(WordnikError)) as WordnikError;
        }

        private RestRequest PrepareWebRequest(WebMethod method, string content, NameValueCollection headers, string path, params object[] fragments)
        {
            string requestUrl = PathUtil.GetPathWithParams(path, fragments);
            var request = new RestRequest()
            {
                Path = requestUrl,
                Method = method
            };
            if (method == WebMethod.Post && !string.IsNullOrEmpty(content))
            {
                request.AddPostContent(Encoding.Default.GetBytes(content));
            }
            if (headers != null && headers.Count != 0)
            {
                foreach (var key in headers.AllKeys)
                    request.AddHeader(key, headers[key]);
            }
            if (!request.GetAllHeaders().Names.Contains("Content-Type"))
                request.AddHeader("Content-Type", "text/plain");
            return request;
        }

        private object PerformWebRequest(WebMethod method, string content, NameValueCollection headers, string path, params object[] fragments)
        {
            var request = PrepareWebRequest(method, content, headers, path, fragments);
            return _restClient.Request(request);
        }

        private T PerformWebRequest<T>(string path, params object[] fragments)
            where T : class
        {
            return PerformWebRequest<T>(WebMethod.Get, null, null, path, fragments);
        }

        private T PerformWebRequest<T>(WebMethod method, string content, string path, params object[] fragments)
            where T : class
        {
            return PerformWebRequest<T>(method, content, null, path, fragments);
        }

        private T PerformWebRequest<T>(WebMethod method, string content, NameValueCollection headers, string path, params object[] fragments)
            where T : class
        {
            var request = PrepareWebRequest(method, content, headers, path, fragments);
            return PerformWebRequest<T>(request);
        }

        private T PerformWebRequest<T>(RestRequest request) where T : class
        {
            var response = _restClient.Request<T>(request);
            LastHttpResponse = response.InnerResponse as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                SetError(response);
                return null;
            }
            return response.ContentEntity;
        }

        private IAsyncResult BeginPerformWebRequest(WebMethod method, string content, NameValueCollection headers, string path, params object[] fragments)
        {
            var request = PrepareWebRequest(method, content, headers, path, fragments);
            return _restClient.BeginRequest(request);
        }

        private IAsyncResult BeginPerformWebRequest<T>(string path, params object[] fragments)
            where T : class
        {
            return BeginPerformWebRequest<T>(WebMethod.Get, null, null, path, fragments);
        }

        private IAsyncResult BeginPerformWebRequest<T>(WebMethod method, string content, string path, params object[] fragments)
            where T : class
        {
            return BeginPerformWebRequest<T>(method, content, null, path, fragments);
        }

        private IAsyncResult BeginPerformWebRequest<T>(WebMethod method, string content, NameValueCollection headers, string path, params object[] fragments)
            where T : class
        {
            var request = PrepareWebRequest(method, content, headers, path, fragments);
            return BeginPerformWebRequest<T>(request);
        }

        private IAsyncResult BeginPerformWebRequest<T>(RestRequest request) where T : class
        {
            return _restClient.BeginRequest<T>(request);
        }

        private object EndPerformWebRequest(IAsyncResult result)
        {
            var response = _restClient.EndRequest(result);
            return response.ContentEntity;
        }

        private T EndPerformWebRequest<T>(IAsyncResult result) where T : class
        {
            var response = _restClient.EndRequest<T>(result);
            LastHttpResponse = response.InnerResponse as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                SetError(response);
                return null;
            }
            return response.ContentEntity;
        }

        private T EndPerformWebRequest<T>(IAsyncResult result, TimeSpan timeout) where T : class
        {
            var response = _restClient.EndRequest<T>(result, timeout);
            LastHttpResponse = response.InnerResponse as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                SetError(response);
                return null;
            }
            return response.ContentEntity;
        }
    }
}