using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToUnicode
{
    class TextToUnicode
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            StringBuilder unicodeRepresentation = new StringBuilder();
            foreach (char symbol in s)
            {
                unicodeRepresentation.AppendFormat("\\u{0:X4}", (int)symbol);
            }

            Console.WriteLine(unicodeRepresentation.ToString());
        }
    }
}
