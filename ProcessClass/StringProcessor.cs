using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public class StringProcessor : IStringProcessor
    {
        private StringHelper helper;

        public StringProcessor()
        {
            helper = new StringHelper();
        }

        /// <summary>
        /// Process the input string collection as per the business rules
        /// 1. truncates to max length of 15 chars
        /// 2. removes contiguous duplicate characters in the same case and replaces by a single character in the same case. 
        /// 3. dollar sign ($) is replaced with a pound sign (£), 
        /// 4. underscores (_) and number 4 are removed
        /// </summary>
        /// <param name="inputCollection">string collection to process</param>
        /// <returns>A non null processed string collection</returns>
        public List<string> ProcessStringCollection(List<string> inputCollection)
        {
            List<string> output = new List<string>();
            if (inputCollection != null)
            {
                foreach (string str in inputCollection)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        string processedString = string.Empty;

                        //Remove continuous duplicate alphabets in the string
                        processedString = helper.ReplaceConsecutiveMultipleChars(str);

                        //Replace $ with £
                        processedString = helper.ReplaceCharacter(processedString, "$", "£");

                        //Remove _ from the string
                        processedString = helper.ReplaceCharacter(processedString, "_", "");

                        //Remove 4 from the string
                        processedString = helper.ReplaceCharacter(processedString, "4", "");

                        //Return the maximum of 15 letters of the string
                        processedString = helper.GetMaxStringLength(processedString);

                        //Add the processed string to output if it is not null or empty
                        if (!string.IsNullOrEmpty(processedString))
                            output.Add(processedString);
                    }
                }
            }
            return output;
        }
    }
}
