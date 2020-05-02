using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Processor;

namespace Processor.Test
{

    [TestClass]
    public class StringProcessorTest
    {
        IStringProcessor _processor;

        public StringProcessorTest()
        {
            _processor = new StringProcessor();
        }

        #region Test cases for ProcessStringCollection

        [TestMethod]
        public void ProcessStringCollection_ReturnsEmptyListWhenNullIsPassed()
        {

            var result = _processor.ProcessStringCollection(null);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow("AAABB***111bbbDDeee££2256$///!!", "AB***111bDe££22")] // Removes consecutive duplicate alphabets from the string
        [DataRow("AAABB_***111bbbDDeee££2256$///!!", "AB***111bDe££22")] // Removes underscores from the string
        [DataRow("AAABB4***111bbbDDeee££2256$///!!", "AB***111bDe££22")] // Removes number 4 from the string
        [DataRow("AAABB$***111bbbDDeee££2256$///!!", "AB£***111bDe££2")] // Replaces dollar with pound in the string
        public void ProcessStringCollection_RemovesAndReplacesCharsAsExpected(string inputString, string expectedOutput)
        {
            List<string> input = new List<string>();

            input.Add(inputString);

            var result = _processor.ProcessStringCollection(input);

            Assert.AreEqual(expectedOutput, result[0]);
        }

        [TestMethod]
        public void ProcessStringCollection_ReturnsMax15Characters()
        {

            List<string> input = new List<string>();

            input.Add("AAABB$***111bbbDDeee££2256$///!!");

            var result = _processor.ProcessStringCollection(input);

            Assert.AreEqual(15, result[0].Length);
        }

        [TestMethod]
        public void ProcessStringCollection_ReturnsEmptyListForInputWithAllNumeral4()
        {

            List<string> input = new List<string>();

            input.Add("44444444");

            var result = _processor.ProcessStringCollection(input);

            Assert.AreEqual(0, result.Count);
        }

        #endregion
    }
}
