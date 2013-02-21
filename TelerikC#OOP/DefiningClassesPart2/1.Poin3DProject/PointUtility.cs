using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poin3DProject
{
    public static class PointUtility
    {
        public static double Distance(Point3D a, Point3D b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2d) + Math.Pow(a.Y - b.Y, 2d) + Math.Pow(a.Z - b.Z, 2d));
        }
    }
}
