using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammock;

namespace NikSharp.Extension
{
    public static class RestResponseExt
    {
        public static RestResponse Clone(this RestResponse target, RestResponseBase source)
        {
            return new RestResponse()
            {
                Cookies = source.Cookies,
                ContentType = source.ContentType,
                Headers = source.Headers,
                InnerResponse = source.InnerResponse,
                InnerException = source.InnerException,
                Tag = source.Tag,
                RequestDate = source.RequestDate,
                RequestKeptAlive = source.RequestKeptAlive,
                RequestMethod = source.RequestMethod,
                RequestUri = source.RequestUri,
                ResponseDate = source.ResponseDate,
                ResponseUri = source.ResponseUri,
                SkippedDueToRateLimitingRule = source.SkippedDueToRateLimitingRule,
                StatusCode = source.StatusCode,
                StatusDescription = source.StatusDescription,
                IsMock = source.IsMock,
                TimedOut = source.TimedOut,
                TimesTried = source.TimesTried
            };
        }
    }
}
