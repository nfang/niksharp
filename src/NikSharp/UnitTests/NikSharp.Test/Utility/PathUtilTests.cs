using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NikSharp.Utility;

namespace NikSharp.Test.Utility
{
    [TestClass]
    public class PathUtilTests
    {
        private const string BaseUrl = @"http://api.wordnik.com/v4";

        [TestMethod]
        public void GetPath_ValidParams()
        {
            string path = PathUtil.GetPathWithParams("/word.json/word", "useCanonical", false, "includeSuggestions", false);
            string expectedPath = @"/word.json/word?useCanonical=False&includeSuggestions=False";
            Assert.AreEqual(expectedPath, path);

            path = PathUtil.GetPathWithParams("/word.json/word", "useCanonical", false, "includeSuggestions", null);
            expectedPath = @"/word.json/word?useCanonical=False";
            Assert.AreEqual(expectedPath, path);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A parameter list with odd number of parameters was accepted.")]
        public void GetPath_InvalidParams_ThrowsException()
        {
            PathUtil.GetPathWithParams("/word.json/word", "useCanonical", false, "includeSuggestions");
        }

        [TestMethod]
        public void RequiredString_EmptyString_ReturnFalse()
        {
            string test = "";
            Assert.IsFalse(ValidationUtil.RequiredString(test));
        }

        [TestMethod]
        public void RequiredString_AllSpaces_ReturnFalse()
        {
            string test = "       ";
            Assert.IsFalse(ValidationUtil.RequiredString(test));
        }

        [TestMethod]
        public void RequiredString_SpacesInWords_ReturnTrue()
        {
            string test = "Required String with whitespaces";
            Assert.IsTrue(ValidationUtil.RequiredString(test));
        }
    }
}
