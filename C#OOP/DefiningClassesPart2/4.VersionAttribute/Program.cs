using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.VersionAttribute
{
    [Version(2,11)]
    class Program
    {
        static void Main(string[] args)
        {
            VersionAttribute versionAttribute = 
                (VersionAttribute)Attribute.GetCustomAttribute(typeof(Program), typeof(VersionAttribute));

            if (versionAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                Console.WriteLine(versionAttribute.Version);
            }

        }
    }
}
