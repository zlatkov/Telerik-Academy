using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, char sex, int age)
            : base(name, sex, age)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Dog sound.");
        }
    }
}
