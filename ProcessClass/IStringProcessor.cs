using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface IStringProcessor
    {
        List<string> ProcessStringCollection(List<string> inputCollection);
    }
}
