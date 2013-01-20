using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingRocks
{
    public class Dwarf : GameObject
    {
        private int x;
        private int y;

        private int boundaryX;

        private const string symbols = "(O)";
        private const ConsoleColor color = ConsoleColor.White;

        private bool collided;

        int livesLeft;

        public Dwarf(int BoundaryX, int BoundaryY)
        {
            livesLeft = 5;
            collided = false;

            boundaryX = BoundaryX;

            x = BoundaryX / 2;
            y = BoundaryY - 1;
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public bool Collided
        {
            get
            {
                return collided;
            }
            set
            {
                collided = value;
                if (collided == true)
                {
                    if (livesLeft > 0)
                    {
                        livesLeft--;
                    }
                }
            }
        }

        public int LivesLeft
        {    
            get
            {
                return livesLeft;
            }
        }
        

        public void MoveRight()
        {
            if (x + 1 < boundaryX - 1)
            {
                x++;
            }
        }

        public void MoveLeft()
        {
            if (x - 1 > 0)
            {
                x--;
            }
        }

        public void Draw()
        {
            if (collided)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x, y);
                Console.Write('X');
            }
            else
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x - 1, y);
                Console.Write(symbols);
            }
        }
    }
}
