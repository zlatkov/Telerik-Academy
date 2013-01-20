using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks
{
    class FallingRocks
    {
        const int WindowWidth = 100;
        const int WindowHeight = 50;
        const int GameMenuWidth = 40;
        const int MaximumClusterSize = 3;
        const int MaximumNumberOfRocks = 32; //Approximate number of maximum rocks currently in the game.

        private static bool exitGame = false;

        const double MaximumGameSpeed = 120d;
        const double Acceleration = 0.3d;
        static double gameSpeed = 0d;

        static ulong gameScore = 0ul;

        static Dwarf player;
        static List<Rock> rocks = new List<Rock>();

        static Random random = new Random();



        private static void InitializeConsoleSettings()
        {
            Console.BufferHeight = Console.WindowHeight = WindowHeight;
            Console.BufferWidth = Console.WindowWidth = WindowWidth;
        }

        private static void RestartGame()
        {
            player = new Dwarf(WindowWidth - GameMenuWidth, WindowHeight);
            gameSpeed = 0d;
            gameScore = 0;
        }

        private static void GetUserInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    player.MoveLeft();
                    DetermineCollisions();
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    player.MoveRight();
                    DetermineCollisions();
                }
            }
        }

        private static void MoveRocks()
        {
            List<int> rocksToRemove = new List<int>();
            for (int i = 0; i < rocks.Count; ++i)
            {
                rocks[i].MoveDown();

                if (rocks[i].Visible == false)
                {
                    rocksToRemove.Add(i);
                }
            }

            gameScore += (ulong)(gameSpeed * rocksToRemove.Count);

            gameSpeed += (double)(rocksToRemove.Count * Acceleration);
            gameSpeed = Math.Min(gameSpeed, MaximumGameSpeed);

            foreach (int rockIndex in rocksToRemove)
            {
                rocks.RemoveAt(rockIndex);
            }
        }

        private static void GenerateNewRocks()
        {
            //75% change of generating ne rock and the number of rocks doens't exceed the maximum value.
            if (random.Next(0, 4) != 0 && rocks.Count() < MaximumNumberOfRocks)
            {
                //33% chance of generating new cluster.
                if (random.Next(0, 100) < 33)
                {
                    Rock newRock = new Rock(WindowWidth - GameMenuWidth, WindowHeight);
                    int clusterSize = random.Next(0, Math.Min(newRock.X, MaximumClusterSize)) + 1;

                    if (clusterSize >= 2)
                    {

                        rocks.Add(newRock);
                        for (int i = 1; i < clusterSize; ++i)
                        {
                            rocks.Add(new Rock(WindowWidth - GameMenuWidth, WindowHeight, newRock.X - i, newRock.Symbol, newRock.Color));
                        }
                    }
                }
                //generate single block.
                else
                {
                    rocks.Add(new Rock(WindowWidth - GameMenuWidth, WindowHeight));
                }
            }
        }

        private static void DetermineCollisions()
        {
            bool collisionExists = false;
            foreach (Rock rock in rocks)
            {
                if (rock.Y == player.Y &&  (rock.X == player.X - 1 || rock.X == player.X || rock.X == player.X + 1))
                {
                    collisionExists = true;
                    break;
                }
            }

            if (collisionExists)
            {
                player.Collided = true;
                rocks.Clear();
            }
        }

        private static void DrawGameMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(WindowWidth - GameMenuWidth + 10, (WindowHeight / 2) - 6);
            Console.Write("Difficulty: " + (int)((gameSpeed / 10d) + 1));

            Console.SetCursorPosition(WindowWidth - GameMenuWidth + 10, (WindowHeight / 2) - 3);
            Console.Write("Your score: " + gameScore);

            Console.SetCursorPosition(WindowWidth - GameMenuWidth + 10, (WindowHeight / 2));
            Console.Write("Lives left: " + player.LivesLeft);
        }

        private static void PaintGameOver()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(WindowWidth / 3, WindowHeight / 2);
            Console.Write("GAME OVER");

            Console.SetCursorPosition(WindowWidth / 3, (WindowHeight / 2) + 3);
            Console.Write("Do you want to play another game [y/n] ?  ");
        }

        private static void Repaint()
        {
            if (player.LivesLeft > 0)
            {
                Console.Clear();

                DrawGameMenu();

                player.Draw();

                for (int i = 0; i < rocks.Count; ++i)
                {
                    rocks[i].Draw();
                }

                if (player.Collided)
                {
                    player.Collided = false;
                    Thread.Sleep(1200);
                }
                else
                {
                    Thread.Sleep((int)(150 - gameSpeed));
                }
            }
            else
            {
                PaintGameOver();

                while (true)
                {
                    char keyPressed = (char)Console.Read();

                    if (keyPressed == 'y')
                    {
                        RestartGame();
                        break;
                    }
                    else if (keyPressed == 'n')
                    {
                        exitGame = true;
                        break;
                    }
                    else
                    {
                        PaintGameOver();
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            InitializeConsoleSettings();
            RestartGame();

            while (true)
            {
                GetUserInput();
                MoveRocks();
                GenerateNewRocks();
                DetermineCollisions();
                Repaint();

                if (exitGame)
                {
                    break;
                }
            }
        }
    }
}
