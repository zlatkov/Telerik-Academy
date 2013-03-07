using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            private set
            {
                if (this.width < 0)
                {
                    throw new ArgumentOutOfRangeException("The width must be greater than 0.");
                }
                else
                {
                    this.width = value;
                }
            }
            get
            {
                return this.width;
            }
        }

        public double Height
        {
            private set
            {
                if (this.height < 0)
                {
                    throw new ArgumentOutOfRangeException("The height must be greater than 0.");
                }
                else
                {
                    this.height = value;
                }
            }
            get
            {
                return this.height;
            }
        }

        public abstract double CalculateSurface();
    }
}
