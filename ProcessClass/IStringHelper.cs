using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface IStringHelper
    {
        string ReplaceConsecutiveMultipleChars(string str);
        string ReplaceCharacter(string str, string oldChar, string newChar);
        string GetMaxStringLength(string str);
    }
}
