using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderSubstring
{
    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder builder, int position, int length)
        {
            if (position < 0 || position >= builder.Length || length < 0 || position + length > builder.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                StringBuilder result = new StringBuilder();
                length = Math.Min(length, builder.Length - position + 1);
                for (int i = 0; i < length; ++i)
                {
                    result.Append(builder[position + i]);
                }
                return result;
            }
        }
    }
}
