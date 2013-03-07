using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    class Tester
    {
        static void Main(string[] args)
        {
            Cat[] cats =
            {
                new Cat("Cat1", 'm', 3),
                new Cat("Cat2", 'm', 1),
                new Cat("Cat3", 'f', 5)
            };

            Dog[] dogs =
            {
                new Dog("Dog1", 'f', 6),
                new Dog("Dog2", 'm', 3)
            };

            Frog[] frogs =
            {
                new  Frog("Frog1", 'f', 2)
            };

            Kitten[] kittens = 
            {
                new Kitten("Kitten1", 8),
                new Kitten("Kitten2", 5),
                new Kitten("Kitten3", 2)
            };

            Tomcat[] tomcats = 
            {
                new Tomcat("Tomcat1", 3),
                new Tomcat("Tomcat4", 5)
            };

            cats[0].ProduceSound();
            dogs[0].ProduceSound();
            frogs[0].ProduceSound();
            kittens[0].ProduceSound();
            tomcats[0].ProduceSound();

            Console.WriteLine("Average age of dogs: " + Animal.CalculateAverage(dogs));
            Console.WriteLine("Average age of frogs: " + Animal.CalculateAverage(frogs));
            Console.WriteLine("Average age of kittens: " + Animal.CalculateAverage(kittens));
            Console.WriteLine("Average age of tomcats: " + Animal.CalculateAverage(tomcats));
        }
    }
}
