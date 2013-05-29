using System;
using System.Linq;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Messaging.Instance.AddMessage("Testing Singleton.");

            if (Messaging.Instance.HasMessage("Testing Singleton."))
            {
                Console.WriteLine("Singleton works!");
            }
            if (Messaging.Instance.HasMessage("Other Message."))
            {
                Console.WriteLine("Singleton does not work..");
            }
        }
    }
}
