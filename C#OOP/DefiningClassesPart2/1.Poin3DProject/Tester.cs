using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poin3DProject
{
    class Tester
    {
        static void Main(string[] args)
        {
            Path path = new Path();
            path.AddPoint(new Point3D(1, 1, 1));
            path.AddPoint(new Point3D(2, 3, 4));
            path.AddPoint(new Point3D(4, 6, 7));
            path.AddPoint(new Point3D(43 ,325, 23));
            path.AddPoint(new Point3D(4329, 0, 0));

            path.RemoveLastPoint();
            path.RemovePointAt(1);

            PathStorage.SavePath(path, "data.txt");

            Path newPath = PathStorage.LoadPath("data.txt");

            for (int i = 0; i < newPath.Count; ++i)
            {
                Console.WriteLine(newPath[i]);
            }
        }
    }
}
