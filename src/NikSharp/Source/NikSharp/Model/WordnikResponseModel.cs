using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace NikSharp.Model
{
    public abstract class WordnikResponseModel
    {
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
