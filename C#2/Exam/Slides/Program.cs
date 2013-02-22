using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Slides
{
    class Move
    {
        public bool isTeleport;
        public int moveX;
        public int moveY;
        public int moveZ;

        public Move(int MoveX, int MoveY, int MoveZ, bool IsTeleport = false)
        {
            moveX = MoveX;
            moveY = MoveY;
            moveZ = MoveZ;
            isTeleport = IsTeleport;
        }

        public static Move operator + (Move a, Move b)
        {
            Move result = new Move(0, 0, 0);
            result.moveX = a.moveX + b.moveX;
            result.moveY = a.moveY + b.moveY;
            result.moveZ = a.moveZ + b.moveZ;

            return result;
        }

        public static bool operator ==(Move a, Move b)
        {
            return (a.moveX == b.moveX && a.moveY == b.moveY && a.moveZ == b.moveZ);
        }

        public static bool operator !=(Move a, Move b)
        {
            return (a.moveX != b.moveX || a.moveY != b.moveY || a.moveZ != b.moveZ);
        }
    }

    class Program
    {
        static Move GetCharMove(char ch)
        {
            if (ch == 'L')
            {
                return new Move(-1, 0, 0);
            }
            else if (ch == 'R')
            {
                return new Move(1, 0, 0);
            }
            else if (ch == 'F')
            {
                return new Move(0, 0, -1);
            }
            else //if (ch == 'B')
            {
                return new Move(0, 0, 1);
            }

        }

        static Move ParseMove(string s)
        {
            if (s[0] == 'S')
            {
                Move result = new Move(0, 1, 0, false);
                for (int i = 2; i < s.Length; ++i)
                {
                    result = result + GetCharMove(s[i]);
                }
                return result;
            }
            else if (s[0] == 'T')
            {
                string[] parts = s.Split(' ');
                int newWidth = int.Parse(parts[1]);
                int newDepth = int.Parse(parts[2]);

                return new Move(newWidth, 0, newDepth, true);
            }
            else if (s[0] == 'E')
            {
                return new Move(0, 1, 0);
            }
            else
            {
                return new Move(0, 0, 0);
            }
        }
        static void Main(string[] args)
        {
            string dim = Console.ReadLine();
            string[] parts = dim.Split(' ');

            int width = int.Parse(parts[0]);
            int height = int.Parse(parts[1]);
            int depth = int.Parse(parts[2]);

            Move[,,] cube = new Move[width, height, depth];

            for (int j = 0; j < height; ++j)
            {
                string line = Console.ReadLine();
                string[] widthParts = line.Split(new string[] { " | " }, StringSplitOptions.None);
                for (int k = 0; k < depth; ++k)
                {
                    MatchCollection collection = Regex.Matches(widthParts[k], @"\((.+?)\)");
                    for (int i = 0; i < collection.Count; ++i)
                    {
                        string tmp = collection[i].Groups[1].Value;
                        cube[i, j, k] = ParseMove(tmp);

                        //Console.WriteLine(cube[i, j, k].moveX + " " +
                        //    cube[i, j, k].moveY + " " + cube[i, j, k].moveZ + " " + cube[i, j, k].isTeleport);
                    }
                }
            }

            string startDim = Console.ReadLine();
            string[] startParts = startDim.Split(' ');

            int startWidth = int.Parse(startParts[0]);
            int startDepth = int.Parse(startParts[1]);

            Move currentPosition = new Move(startWidth, 0, startDepth);
            Move nextMove, nextPosition;
            string answer;

            while (true)
            {
                nextPosition = currentPosition;
                nextMove = cube[currentPosition.moveX, currentPosition.moveY, currentPosition.moveZ];


                //Console.WriteLine("{0} {1} {2}", currentPosition.moveX, currentPosition.moveY, currentPosition.moveZ);
                //Console.WriteLine("{0} {1} {2} {3}", nextMove.moveX, nextMove.moveY, nextMove.moveZ, nextMove.isTeleport);

                if (nextMove.isTeleport)
                {
                    nextPosition = new Move(nextMove.moveX, nextPosition.moveY, nextMove.moveZ);
                    nextPosition.isTeleport = false;
                }
                else
                {
                    nextPosition = nextPosition + nextMove;
                    nextPosition.isTeleport = false;
                }


                if (nextPosition == currentPosition) // in basket
                {
                    answer = "No";
                    break;
                }
                else if (nextPosition.moveY >= height)
                {
                    answer = "Yes";
                    break;
                }
                else if (nextPosition.moveX >= 0 && nextPosition.moveX < width &&
                         nextPosition.moveY >= 0 && nextPosition.moveY < height &&
                         nextPosition.moveZ >= 0 && nextPosition.moveZ < depth)
                {
                    currentPosition = nextPosition;
                }
                else
                {
                    answer = "No";
                    break;
                }
            }
            Console.WriteLine(answer);
            Console.WriteLine("{0} {1} {2}", currentPosition.moveX, currentPosition.moveY, currentPosition.moveZ);
        }
    }
}
