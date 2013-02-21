using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poin3DProject
{
    public struct Point3D
    {
        private static readonly Point3D center = new Point3D(0d, 0d, 0d);

        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Point3D Center 
        { 
            get
            {
                return center;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.X, this.Y, this.Z);
        }
    }
}
