using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    class Frog : Animal
    {
        public Frog(string name, char sex, int age)
            : base(name, sex, age)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Frog sound.");
        }
    }
}
