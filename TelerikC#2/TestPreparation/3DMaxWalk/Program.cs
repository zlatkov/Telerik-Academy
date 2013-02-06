using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DMaxWalk
{
    class Position
    {
        public int x;
        public int y;
        public int z;

        public Position(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
    class Program
    {
        static bool Valid(Position position, int width, int height, int depth)
        {
            return (position.x >= 0 && position.x < width &&
                    position.y >= 0 && position.y < height &&
                    position.z >= 0 && position.z < depth);
        }

        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string[] dim = firstLine.Split(' ');


       
            int width = int.Parse(dim[0]);
            int height = int.Parse(dim[1]);
            int depth = int.Parse(dim[2]);

            int[,,] cube = new int[width, height, depth];
            bool[, ,] visited = new bool[width, height, depth];

            for (int j = 0; j < height; ++j)
            {
                string line = Console.ReadLine();
                string[] depthSequence = line.Split(new string[] {" | "}, StringSplitOptions.None);

                for (int k = 0; k < depth; ++k)
                {
                    string[] widthSquence = depthSequence[k].Split(' ');
                    for (int i = 0; i < width; ++i)
                    {
                        cube[i, j, k] = int.Parse(widthSquence[i]);
                    }
                }
            }

            int[] deltaX = {1, -1, 0,  0, 0,  0};
            int[] deltaY = {0,  0, 1, -1, 0,  0};
            int[] deltaZ = {0,  0, 0,  0, 1, -1};

            Position currentPosition = new Position(width >> 1, height >> 1, depth >> 1);
            Position nextPosition;

            int result = cube[currentPosition.x, currentPosition.y, currentPosition.z];

            while (true)
            {
                visited[currentPosition.x, currentPosition.y, currentPosition.z] = true;
                int tmpMaxvalue = int.MinValue;
                int countSameValue = 0;

                Position nextMove = new Position(currentPosition.x, currentPosition.y, currentPosition.z);
                for (int i = 0; i < 6; ++i)
                {
                    nextPosition = new Position(currentPosition.x + deltaX[i],
                                                currentPosition.y + deltaY[i],
                                                currentPosition.z + deltaZ[i]);

                    while (Valid(nextPosition, width, height, depth))
                    {
                        if (tmpMaxvalue == cube[nextPosition.x, nextPosition.y, nextPosition.z])
                        {
                            countSameValue++;
                        }
                        else if (tmpMaxvalue < cube[nextPosition.x, nextPosition.y, nextPosition.z])
                        {
                            countSameValue = 1;
                            nextMove = nextPosition;
                            tmpMaxvalue = cube[nextPosition.x, nextPosition.y, nextPosition.z];
                        }

                        nextPosition = new Position(nextPosition.x + deltaX[i],
                                                    nextPosition.y + deltaY[i],
                                                    nextPosition.z + deltaZ[i]);
                    }
                }


                if (countSameValue == 1)
                {
                    if (!visited[nextMove.x, nextMove.y, nextMove.z])
                    {
                        result += tmpMaxvalue;
                        currentPosition = nextMove;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
