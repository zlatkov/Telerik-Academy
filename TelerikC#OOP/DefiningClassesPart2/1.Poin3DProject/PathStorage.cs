using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Poin3DProject
{
    public static class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < path.Count; ++i)
                    {
                        writer.WriteLine(path[i]);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Path LoadPath(string fileName)
        {
            Path path = new Path();
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitted = line.Split(' ');
                        path.AddPoint(new Point3D(Convert.ToDouble(splitted[0]), Convert.ToDouble(splitted[1]), Convert.ToDouble(splitted[2])));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return path;
        }
    }
}
