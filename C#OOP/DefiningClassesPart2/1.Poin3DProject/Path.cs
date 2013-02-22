using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poin3DProject
{
    public class Path
    {
        private List<Point3D> path = new List<Point3D>();

        public Path()
        {
        }

        public Path(List<Point3D> path)
        {
            this.path = path;
        }

        public int Count
        {
            get
            {
                return path.Count;
            }
        }

        public void AddPoint(Point3D point)
        {
            path.Add(point);
        }

        public void RemoveLastPoint()
        {
            RemovePointAt(path.Count - 1);
        }

        public void RemovePointAt(int index)
        {
            if (index >= 0 && index < path.Count)
            {
                path.RemoveAt(index);
            }
        }

        public Point3D this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return path[index];
                }
            }
        }
    }
}
