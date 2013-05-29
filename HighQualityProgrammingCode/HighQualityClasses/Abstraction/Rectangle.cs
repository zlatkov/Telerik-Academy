namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("The width cannot be negative.");
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException("The height cannot be negative.");
            }

            this.Width = width;
            this.Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
