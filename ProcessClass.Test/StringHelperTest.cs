using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processor;

namespace Processor.Test
{
    [TestClass]
    public class StringHelperTest
    {
        StringHelper _helper;

        public StringHelperTest()
        {
            _helper = new StringHelper();
        }

        #region Test cases for GetMaxStringLength

        [TestMethod]
        public void GetMaxStringLength_ReturnsNullWhenNullStringPassed()
        {
            var result = _helper.GetMaxStringLength(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMaxStringLength_Returns15CharactersForInputMoreThan15Chars()
        {

            var result = _helper.GetMaxStringLength("1234567890abcdefgh");

            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void GetMaxStringLength_ReturnsLessCharactersFoInputBelow15Chars()
        {

            var result = _helper.GetMaxStringLength("1234567890");

            Assert.IsTrue(result.Length <= 15);
        }

        #endregion

        #region Test cases for ReplaceCharacters

        [TestMethod]
        public void ReplaceCharacters_ReturnsNullWhenNullStringPassed()
        {

            var result = _helper.ReplaceCharacter(null, "$", "£");

            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow("ABcdDD$56f", null, "£", "ABcdDD$56f")] // oldChar null test 
        [DataRow("ABcdDD$56f", "$", null, "ABcdDD$56f")] // newChar null test
        public void ReplaceCharacters_ReturnsInputStringWhenNullPassedForOldOrNewChar(string input, string oldString, string newString, string expectedResult)
        {

           var result = _helper.ReplaceCharacter(input, oldString, newString);

           Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ReplaceCharacters_ReplaceDollarWithPound()
        {

            var result = _helper.ReplaceCharacter("ABcdDD$56f", "$", "£");

            Assert.IsTrue(!result.Contains("$"));
            Assert.AreEqual('£', result[6]);
        }

        #endregion

        #region Test cases for ReplaceConsecutiveMultipleChars

        [TestMethod]
        public void ReplaceConsecutiveMultipleChars_ReturnsNullWhenNullStringPassed()
        {

            var result = _helper.ReplaceConsecutiveMultipleChars(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow("AAABBBbbbDDeee££456$", "ABbDe££456$")] // Replaces consecutive Alphabets
        [DataRow("AAABBB111bbbDDeee££4456$", "AB111bDe££4456$")] // Do not replace consecutive numbers
        [DataRow("AAABB***111bbbDDeee££4456$///!!", "AB***111bDe££4456$///!!")] // Do not replace consecutive special characters
        public void ReplaceConsecutiveMultipleChars_ReplacesOnlyConsecutiveAlphabets(string input,string expectedOutput)
        {
            var result = _helper.ReplaceConsecutiveMultipleChars(input);

            Assert.AreEqual(expectedOutput, result);
        }
        #endregion
    }
}
