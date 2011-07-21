using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikSharp.Model.Enums
{
    [Serializable]
    public static class ResponseFormat
    {
        public const string Json = @"json";
        public const string Xml = @"xml";
    }

    [Serializable]
    public static class PronunciationTypeFormat
    {
        /// <summary>
        /// The American Heritage Dictionary pronunciation symbols
        /// </summary>
        public const string AHD = @"ahd";
        /// <summary>
        /// The Arpabet format
        /// </summary>
        public const string Arpabet = @"arpabet";
        /// <summary>
        /// GCIDE diacritical signs
        /// </summary>
        public const string GcideDiacritical = @"gcide-diacritical";
    }

    [Serializable]
    public static class SortBy
    {
        public const string Alpha = @"alpha";
        public const string Count = @"count";
    }

    [Serializable]
    public static class SortOrder
    {
        public const string Asc = @"asc";
        public const string Desc = @"desc";
    }

    [Serializable]
    public static class WordListType
    {
        public const string Private = @"PRIVATE";
        public const string Public = @"PUBLIC";
    }
}
