using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingRocks
{
    public class Rock : GameObject
    {
        public static List<char> PossibleSymbols = new List<char>() 
            { 
                '^', 
                '@', 
                '*', 
                '&', 
                '+', 
                '%', 
                '$', 
                '#', 
                '!', 
                '.', 
                ';' 
            };

        public static List<ConsoleColor> PossibleColors = new List<ConsoleColor>()
            {
                ConsoleColor.Yellow,
                ConsoleColor.White,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow//,
                //ConsoleColor.Blue
            };

        public static Random random = new Random();

        private int x;
        private int y;

        private int boundaryX;
        private int boundaryY;

        private char symbol;
        private ConsoleColor color;

        private bool visible;

        public Rock(int BoundaryX, int BoundaryY)
        {
            visible = true;

            boundaryX = BoundaryX;
            boundaryY = BoundaryY;

            x = random.Next(0, boundaryX);
            y = 0;

            symbol = PossibleSymbols[random.Next(0, PossibleSymbols.Count)];
            color = PossibleColors[random.Next(0, PossibleColors.Count)];
        }

        public Rock(int BoundaryX, int BoundaryY, int ClusterX, char ClusterSymbol, ConsoleColor ClusterColor)
        {
            visible = true;

            boundaryX = BoundaryX;
            boundaryY = BoundaryY;

            x = ClusterX;
            y = 0;

            symbol = ClusterSymbol;
            color = ClusterColor;
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

        public char Symbol
        {
            get
            {
                return symbol;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
        }

        public void MoveDown()
        {
            if (y + 1 < boundaryY)
            {
                y++; 
            }
            else
            {
                visible = false;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
