using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuotesInString
{
    class QuotesInString
    {
        static void Main(string[] args)
        {
            string stringWithEscapeSequence = "The \"use\" of quotations causes difficulties";
            string quotedString = @"The ""use"" of quotations causes difficulties";
        }
    }
}
