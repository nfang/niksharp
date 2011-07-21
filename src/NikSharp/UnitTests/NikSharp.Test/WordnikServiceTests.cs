using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NikSharp.Model.Enums;
using System.Net;
using System.Diagnostics;
using NikSharp.Model;

namespace NikSharp.Test
{
    [TestClass]
    public class WordnikServiceTests
    {
        private WordnikService _service;

        public WordnikServiceTests()
        {
            _service = new WordnikService("Wordnik_API_Key");
        }

        #region /account
        [TestMethod]
        public void Authenticate_ExistingUser_ReturnNotNull()
        {
            var response = _service.Authenticate("username", "password");
            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Authenticate_InvalidUser_ReturnError()
        {
            var response = _service.Authenticate("nfang", "password");
            Assert.IsNull(response);
            Assert.IsNotNull(_service.LastError);
            Trace.WriteLine(_service.LastError.Message);
        }

        [TestMethod]
        public void GetTokenStatus_ReturnNotNull()
        {
            var response = _service.GetTokenStatus();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Valid);
        }

        [TestMethod]
        public void GetUser_ReturnNotNull()
        {
            _service.Authenticate("username", "password");
            var response = _service.GetUser();
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
            Assert.AreEqual("username", response.Username);
        }

        [TestMethod]
        public void GetUserWordList_ValidParams_ReturnNotNull()
        {
            _service.Authenticate("username", "password");
            var response = _service.GetUserWordList();
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }
        #endregion

        #region /word
        [TestMethod]
        public void GetWord_ValidParams_ReturnNotNull()
        {
            var response = _service.GetWord("masquerade");

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetExamples_ValidParams_ReturnNotNull()
        {
            var response = _service.GetExamples("masquerade");

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetDefinitions_ValidParams_ReturnNotNull()
        {
            var response = _service.GetDefinitions("masquerade");

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetFrequency_ValidParams_ReturnNotNull()
        {
            var response = _service.GetFrequency("masquerade", startYear: 1985, endYear: 2000);

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);

            foreach (var item in response.Frequency)
            {
                Assert.IsNotNull(item);
            }
        }

        [TestMethod]
        public void GetTopExample_ValidParams_ReturnNotNull()
        {
            var response = _service.GetTopExample("dinosaur");

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetRelatedWords_ValidParams_ReturnNotNull()
        {
            var response = _service.GetRelatedWords("masquerade", type: RelationshipType.Hyponym, limit: 2);

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);

            Assert.IsTrue(response.Count() <= 2);
        }

        [TestMethod]
        public void GetPhrases_ValidParams_ReturnNotNull()
        {
            var response = _service.GetPhrases("masquerade", wlmi: 5);

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);

            Assert.IsTrue(response.All(rw => rw.WLMI >= 5));
        }

        [TestMethod]
        public void GetHyphenation_ValidParams_ReturnNotNull()
        {
            var response = _service.GetHyphenation("hyphenation");

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetPronunciations_ValidParams_ReturnNotNull()
        {
            var response = _service.GetPronunciations("masquerade", false, typeFormat: PronunciationTypeFormat.AHD);

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetAudio_ValidParams_ReturnNotNull()
        {
            var response = _service.GetAudio("masquerade");

            Assert.IsNotNull(_service.LastHttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
            Assert.IsNotNull(response);
        }
        #endregion

        #region /words
        [TestMethod]
        public void GetRandomWord_ReturnNotNull()
        {
            var response = _service.GetRandomWord();
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
        }

        [TestMethod]
        public void GetRandomWords_ReturnNotNull()
        {
            var response = _service.GetRandomWords();
            Assert.IsNotNull(response);
            foreach (var item in response)
            {
                Assert.IsNotNull(item);
            }
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
        }

        [TestMethod]
        public void SearchWord_ValidParams_ReturnNotNull()
        {
            var response = _service.SearchWord("bookmark", limit: 2);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() <= 2);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
        }

        [TestMethod]
        public void GetWordOfTheDay_SpecifiedDate_ReturnNotNull()
        {
            var response = _service.GetWordOfTheDay(new DateTime(1985, 12, 10));
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
        }

        [TestMethod]
        public void SearchQuery_ValidParams_ReturnNotNull()
        {
            var response = _service.SearchQuery("bookmark", limit: 2);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.SearchResults.Count <= 2);
            Assert.AreEqual(HttpStatusCode.OK, _service.LastHttpResponse.StatusCode);
        } 
        #endregion

        #region /wordList
        [TestMethod]
        public void GetWordList_ValidParam_ReturnNotNull()
        {
            _service.Authenticate("username", "password");
            var response = _service.GetWordList("computer-words--1");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeleteWords_ValidParam_CountChanges()
        {
            _service.Authenticate("username", "password");
            var nOldCount = _service.GetWordList("computer-words--1").NumberWordsInList;
            _service.DeleteWords("computer-words--1", new string[] { "iMac" });
            Assert.IsNull(_service.LastError);
            var nNewCount = _service.GetWordList("computer-words--1").NumberWordsInList;
            Assert.AreEqual(nOldCount - 1, nNewCount);
        }

        [TestMethod]
        public void AddWords_ValidParam_CountChanges()
        {
            _service.Authenticate("username", "password");
            var nOldCount = _service.GetWordList("computer-words--1").NumberWordsInList;
            _service.AddWords("computer-words--1", new string[] { "iMac" });
            Assert.IsNull(_service.LastError);
            var nNewCount = _service.GetWordList("computer-words--1").NumberWordsInList;
            Assert.AreEqual(nOldCount + 1, nNewCount);
        }

        [TestMethod]
        public void CreateWordList_ValidParam_CountChanges()
        {
            _service.Authenticate("username", "password");
            var response = _service.CreateWordList("Insurance", "Words about insurance", WordListType.Private);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Name, "Insurance");
        }

        [TestMethod]
        public void DeleteWordList_ValidParam_CountChanges()
        {
            _service.Authenticate("username", "password");
            var nOldCount = _service.GetUserWordList().Count();
            _service.DeleteWordList("insurance");
            var nNewCount = _service.GetUserWordList().Count();
            Assert.AreEqual(nOldCount - 1, nNewCount);
        } 
        #endregion
    }
}
