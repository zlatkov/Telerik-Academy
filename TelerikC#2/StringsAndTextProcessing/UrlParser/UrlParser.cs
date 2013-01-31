using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UrlParser
{
    class UrlParser
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            Match match = Regex.Match(url, @"\s*([^\s]*)://([^\s]*)(/[^\s]*)");

            string protocol = match.Groups[1].Value;
            string server = match.Groups[2].Value;
            string resource = match.Groups[3].Value;

            Console.WriteLine("Protocol: " + protocol);
            Console.WriteLine("Server: " + server);
            Console.WriteLine("Resource: " + resource);
        }
    }
}
