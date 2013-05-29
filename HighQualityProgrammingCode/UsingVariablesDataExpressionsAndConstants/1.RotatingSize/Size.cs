using System;
using System.Linq;

namespace RotatingFigure
{
    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }
    }
}
