using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikSharp.Model.Enums
{
    [Serializable]
    public static class RelationshipType
    {
        public const string Antonym = "antonym";
        public const string CrossReference = "cross-reference";
        public const string Equivalent = "equivalent";
        public const string EtymologicallyRelatedTerm = "etymologically-related-term";
        public const string Form = "form";
        public const string Hypernym = "hypernym";
        public const string Hyponym = "hyponym";
        public const string InflectedForm = "inflected-form";
        public const string Primary = "primary";
        public const string RelatedWord = "related-word";
        public const string Rhyme = "rhyme";
        public const string SameContext = "same-context";
        public const string Synonym = "synonym";
        public const string Unknown = "unknown";
        public const string Variant = "variant";
        public const string VerbForm = "verb-form";
        public const string VerbStem = "verb-stem";
    }
}
