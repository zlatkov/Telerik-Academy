using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Human : CommentCollection
    {
        public Human()
        {
        }

        public Human(string name)
        {
            this.Name = name;
        }

        public string Name { protected set; get; }
    }
}
