using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NikSharp.Utility
{
    public static class ValidationUtil
    {
        public static bool RequiredString(string param)
        {
            if (string.IsNullOrEmpty(param) || Regex.IsMatch(param, "^\\s+$"))
                return false;
            return true;
        }
    }
}
