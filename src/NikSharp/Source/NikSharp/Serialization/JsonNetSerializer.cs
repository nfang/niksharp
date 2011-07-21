using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammock.Serialization;
#if NET40
using System.Dynamic;
#endif
using Hammock;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace NikSharp.Serialization
{
    class JsonNetSerializer : Utf8Serializer, ISerializer, IDeserializer
    {
        private readonly JsonSerializer _serializer;

        public JsonNetSerializer()
        {
            if (_serializer == null)
            {
                _serializer = JsonSerializer.Create(new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public JsonNetSerializer(JsonSerializerSettings settings)
        {
            if (_serializer == null)
                _serializer = JsonSerializer.Create(settings);
        }

        public virtual string ContentType
        {
            get { return "application/json"; }
        }

        public string Serialize(object instance, Type type)
        {
            using (var sw = new StringWriter())
            using (var jtw = new JsonTextWriter(sw))
            {
                _serializer.Serialize(jtw, instance);
                return sw.ToString();
            }
        }

        public T Deserialize<T>(RestResponse<T> response)
        {
            if (response.ContentType.Equals("application/json") && response.StatusCode == HttpStatusCode.OK)
            {
                using (var sr = new StringReader(response.Content))
                using (var jtr = new JsonTextReader(sr))
                {
                    return _serializer.Deserialize<T>(jtr);
                }

            }
            return default(T);
        }

        public object Deserialize(RestResponse response, Type type)
        {
            if (response.ContentType.Equals("application/json"))
            {
                using (var sr = new StringReader(response.Content))
                using (var jtr = new JsonTextReader(sr))
                {
                    return _serializer.Deserialize(jtr, type);
                }
            }
            return null;
        }
#if NET40
        public dynamic DeserializeDynamic<T>(RestResponse<T> response) where T : DynamicObject
        {
            throw new NotImplementedException();
        }
#endif
    }
}
