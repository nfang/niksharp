using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikSharp.Utility
{
    public static class PathUtil
    {
        public static string GetPathWithParams(string path, params object[] query)
        {
            if ((query.Length & 1) == 1) throw new ArgumentException("malformed argument list", "query");

            if (query == null || query.Length == 0) return path;

            StringBuilder builder = new StringBuilder(string.Concat(path, "?"));
            for (int i = 0; i < query.Length; i += 2)
            {
                if (query[i + 1] != null)
#if NET40
                    builder.Append(string.Format("{0}&", string.Join("=", query[i], query[i + 1])));
#else
                    builder.Append(string.Format("{0}&", string.Join("=", new string[] { query[i].ToString(), query[i + 1].ToString()})));
#endif
            }

            return builder.ToString(0, builder.Length - 1);
        }

    }
}
