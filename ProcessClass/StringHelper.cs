using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public class StringHelper: IStringHelper
    {
        /// <summary>
        /// Method to replace consecutive multiple characters with single character
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ReplaceConsecutiveMultipleChars(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder output = new StringBuilder();

                // Add the first character of the string.
                output.Append(str[0]);

                // Start the loop at 1, because we already have the first character.
                for (int i = 1; i < str.Length; i++)
                {
                    // Check if the character is Alphabet
                    if (Char.IsLetter(str[i]))
                    {
                        // Check the current against the previous character.
                        if (str[i] != str[i - 1])
                        {
                            // If it is not the same, append it.
                            output.Append(str[i]);
                        }
                    }
                    else
                        output.Append(str[i]);

                }

                string result = output.ToString();
                return result;
            }

            return str;
        }

        /// <summary>
        /// Replace the old character with the new character in the string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oldChar"></param>
        /// <param name="newChar"></param>
        /// <returns></returns>
        public string ReplaceCharacter(string str, string oldChar, string newChar)
        {
            if (!string.IsNullOrEmpty(str) && oldChar != null && newChar != null)
                return str.Replace(oldChar, newChar);

            return str;
        }

        /// <summary>
        /// Method to truncate to max length 15
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMaxStringLength(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 15)
                return str.Substring(0, 15);

            return str;
        }
    }
}
