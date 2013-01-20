using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDamage
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

        static bool Equals(Point a, Point b)
        {
            return a.x == b.x && a.y == b.y;
        }

        static bool LiesOnLine(Point a1, Point a2, Point b)
        {
            return (b.x >= a1.x && b.x <= a2.x && b.y >= a1.y && b.y <= a2.y);
        }

        static bool Inside(Point a1, Point a2, Point b)
        {
            return (b.x >= a1.x && b.y >= a1.y && b.x <= a2.x && b.y <= a2.y);
        }

        static void Main(string[] args)
        {
            Point[] shipPoint = new Point[4];
            int horizontalLineY;

            for (int i = 0; i < 4; ++i)
            {
                shipPoint[i] = new Point();
            }

            shipPoint[0].Read();
            shipPoint[2].Read();

            if (shipPoint[0].x > shipPoint[2].x)
            {
                int tmp = shipPoint[2].x;
                shipPoint[2].x = shipPoint[0].x;
                shipPoint[0].x = tmp;
            }

            if (shipPoint[0].y > shipPoint[2].y)
            {
                int tmp = shipPoint[2].y;
                shipPoint[2].y = shipPoint[0].y;
                shipPoint[0].y = tmp;
            }

            shipPoint[1] = new Point(shipPoint[2].x, shipPoint[0].y);
            shipPoint[3] = new Point(shipPoint[0].x, shipPoint[2].y);

            horizontalLineY = int.Parse(Console.ReadLine());

            int totalDamage = 0;

            for (int k = 0; k < 3; ++k)
            {
                Point catapult = new Point();
                Point catapultTarget = new Point();

                catapult.x = int.Parse(Console.ReadLine());
                catapult.y = int.Parse(Console.ReadLine());

                catapultTarget.x = catapult.x;
                catapultTarget.y = 2 * horizontalLineY - catapult.y;

                bool equalsShipPoint = false;
                bool liesOnShipSide = false;
                bool insideShip = false;

                for (int i = 0; i < 4; ++i)
                {
                    if (Equals(catapultTarget, shipPoint[i]))
                    {
                        equalsShipPoint = true;
                        break;
                    }
                }

                if (!equalsShipPoint)
                {
                    if (LiesOnLine(shipPoint[0], shipPoint[1], catapultTarget) ||
                        LiesOnLine(shipPoint[1], shipPoint[2], catapultTarget) ||
                        LiesOnLine(shipPoint[3], shipPoint[2], catapultTarget) ||
                        LiesOnLine(shipPoint[0], shipPoint[3], catapultTarget))
                    {
                        liesOnShipSide = true;
                    }
                }

                if (!equalsShipPoint && !liesOnShipSide)
                {
                    if (Inside(shipPoint[0], shipPoint[2], catapultTarget))
                    {
                        insideShip = true;
                    }
                }

                if (equalsShipPoint)
                {
                    totalDamage += 25;
                }
                else if (liesOnShipSide)
                {
                    totalDamage += 50;
                }
                else if (insideShip)
                {
                    totalDamage += 100;
                }

            }

            Console.WriteLine(totalDamage + "%");
        }
    }
}
