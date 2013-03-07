using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Discipline : CommentCollection
    {
        public Discipline(string name, uint numberOfLectures, uint numberOfExcercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExcercises = numberOfExcercises;
        }

        public string Name { private set; get; }
        public uint NumberOfLectures { private set; get; }
        public uint NumberOfExcercises { private set; get; }
    }
}
