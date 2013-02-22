using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeDecodeMessage
{
    class EncodeDecodeMessage
    {
        static string EncodeMessage(string message, string key)
        {
            StringBuilder result = new StringBuilder(message.Length);
            for (int i = 0; i < message.Length; ++i)
            {
                result.Append((char)(message[i] ^ key[i % key.Length]));
            }
            return result.ToString();
        }

        static string DecodeMessage(string message, string key)
        {
            string result = EncodeMessage(message, key);
            return result;
        }

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string key = Console.ReadLine();

            string encoded = EncodeMessage(message, key);
            string decoded = DecodeMessage(encoded, key);

            Console.WriteLine("{0} {1}", encoded, decoded);
        }
    }
}
