using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringObjectTypeCasting
{
    class StringObjectTypeCasting
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";

            object helloWorld = hello + " " + world;

            string helloWorldString = (string)helloWorld;
        }
    }
}
