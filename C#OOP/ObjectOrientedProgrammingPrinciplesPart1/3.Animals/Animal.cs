using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public abstract class Animal : ISound
    {
        private string name;
        private char sex;
        private int age;

        public Animal(string name, char sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }

        public int Age 
        {
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The age must be a number greater than 0.");
                }
                else
                {
                    this.age = value;
                }
            }
            get
            {
                return this.age;
            }
        }

        public char Sex 
        {
            private set
            {
                if (value != 'f' && value != 'm')
                {
                    throw new ArgumentException("The sex must be either m or f.");
                }
                else
                {
                    this.sex = value;
                }
            }
            get
            {
                return this.sex;
            }
        }

        public string Name 
        {
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name must be nonempty, and not null.");
                }
                else
                {
                    this.name = value;
                }
            }
            get
            {
                return this.name;
            }
        }

        public abstract void ProduceSound();

        public static double CalculateAverage(Animal[] animals)
        {
            double sum = 0d;
            foreach(Animal animal in animals)
            {
                sum += animal.age;
            }
            return sum / (double)animals.Length;
        }
    }
}
