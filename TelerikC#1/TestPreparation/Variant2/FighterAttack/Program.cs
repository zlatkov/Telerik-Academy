using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class Program
    {
        public class Point
        {
            public int x;
            public int y;

            public Point()
            {
            }

            public Point(int X, int Y)
            {
                x = X;
                y = Y;
            }

            public void Read()
            {
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static int Inside(Point a1, Point a2, Point b)
        {
            return Convert.ToInt32(b.x >= a1.x && b.y >= a1.y && b.x <= a2.x && b.y <= a2.y);
        }

        static void Main(string[] args)
        {
            Point[] plant = new Point[2];

            plant[0] = new Point();
            plant[1] = new Point();

            plant[0].Read();
            plant[1].Read();

            if (plant[0].x > plant[1].x)
            {
                Swap(ref plant[0].x, ref plant[1].x);
            }

            if (plant[0].y > plant[1].y)
            {
                Swap(ref plant[0].y, ref plant[1].y);
            }

            Point missle = new Point();
            missle.Read();

            int distance = int.Parse(Console.ReadLine());
            missle.x += distance;

            int damage = 0;
            damage += 100 * Inside(plant[0], plant[1], new Point(missle.x, missle.y));
            damage += 75 * Inside(plant[0], plant[1], new Point(missle.x + 1, missle.y));
            damage += 50 * Inside(plant[0], plant[1], new Point(missle.x, missle.y - 1));
            damage += 50 * Inside(plant[0], plant[1], new Point(missle.x, missle.y + 1));

            Console.WriteLine(damage + "%");
        }
    }
}
