using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public class Circle : Shape
    {
        public Circle(double diameter)
            : base(diameter, diameter)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Width * this.Width / 4d; //PI * (diameter / 2) * (diameter / 2)
        }
    }
}
