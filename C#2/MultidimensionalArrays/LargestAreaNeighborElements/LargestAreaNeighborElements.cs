using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaNeighborElements
{
    class LargestAreaNeighborElements
    {
        class Position
        {
            private int x;
            private int y;

            public Position()
            {
                x = 0;
                y = 0;
            }

            public Position(int initialX, int initialY)
            {
                x = initialX;
                y = initialY;
            }

            public int X
            {
                get
                {
                    return x;
                }
                set
                {
                    x = value;
                }
            }

            public int Y
            {
                get
                {
                    return y;
                }
                set
                {
                    y = value;
                }
            }
        }

        static bool ValidCell(Position position, int n, int m)
        {
            return (position.X >= 0 && position.X < n && position.Y >= 0 && position.Y < m);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[] deltaX = new int[] { -1, 1, 0, 0 };
            int[] deltaY = new int[] { 0, 0, -1, 1 };

            bool[,] visited = new bool[n, m];

            int largestArea = 0;
            int tmpArea = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (visited[i, j] == false)
                    {
                        visited[i, j] = true;
                        tmpArea = 0;
                        Queue<Position> queue = new Queue<Position>();
                        queue.Enqueue(new Position(i, j));

                        while (queue.Count > 0)
                        {
                            tmpArea++;
                            Position currentPosition = queue.Dequeue();

                            for (int k = 0; k < 4; ++k)
                            {
                                Position nextPosition = new Position(currentPosition.X + deltaX[k], currentPosition.Y + deltaY[k]);
                                if (ValidCell(nextPosition, n, m) && visited[nextPosition.X, nextPosition.Y] == false 
                                    && matrix[currentPosition.X, currentPosition.Y] == matrix[nextPosition.X, nextPosition.Y])
                                {
                                    visited[nextPosition.X, nextPosition.Y] = true;
                                    queue.Enqueue(nextPosition);
                                }
                            }
                        }

                        if (tmpArea > largestArea)
                        {
                            largestArea = tmpArea;
                        }
                    }
                }
            }

            Console.WriteLine("The largeast area size is: " + largestArea);
        }
    }
}
