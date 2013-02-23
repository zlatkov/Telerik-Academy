using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _7.CapitalizeWordFirstLetter
{
    public static class CapitalizeWordFirstLetter
    {
        public static string ToTitleCase(this string text)
        {
            TextInfo info = CultureInfo.InvariantCulture.TextInfo;
            return info.ToTitleCase(text);
        }
    }
}
