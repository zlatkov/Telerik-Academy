using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : Human
    {
        private List<Discipline> disciplines;

        public Teacher(string name, List<Discipline> disciplines)
            : base(name)
        {
            this.disciplines = disciplines;
        }

        public List<Discipline> Disciplines
        {
            private set
            {
                this.disciplines = value;
            }
            get
            {
                return this.disciplines;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            if (this.disciplines.Count(x => x.Name == discipline.Name) == 0)
            {
                this.disciplines.Add(discipline);
            }
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.RemoveAll(x => x.Name == discipline.Name);
        }
    }
}
