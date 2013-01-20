using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteUserName
{
    class ReadWriteUserName
    {
        static void ReadUserName()
        {
            Console.Write("Enter your name: ");

            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}!", userName);
        }
        static void Main(string[] args)
        {
            ReadUserName();
        }
    }
}
