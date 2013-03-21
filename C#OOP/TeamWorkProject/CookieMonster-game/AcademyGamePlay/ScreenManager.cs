using System;
using System.Threading;

namespace AcademyGamePlay
{
    /// <summary>
    /// Represents the starting game screen.
    /// </summary>
    static class ScreenManager
    {
        public static string gameName = "Tanks Game";

        static private int screenHeight;
        static private int screenWidth;

        static ScreenManager()
        {
            Console.CursorVisible = false;
            screenHeight = 35;
            screenWidth = 100;
        }

        public static void SetScreenResolution(int height, int width)
        {
            screenHeight = height;
            screenWidth = width;
        }

        /// <summary>
        /// The screen which is showed when the game is started.
        /// </summary>
        public static void SplashScreen()
        {
            Console.Clear();
            Console.WindowWidth = screenWidth;
            Console.WindowHeight = screenHeight;

            Console.SetCursorPosition(screenWidth / 2 - 10, screenHeight / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cookie Monster Team");
            Thread.Sleep(500);
            Console.SetCursorPosition(screenWidth / 2 - 2, screenHeight / 2 + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("2013");

            Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition(screenWidth / 2 - 4, screenHeight / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Presents");
            Thread.Sleep(500);
            Console.Clear();
            Console.SetCursorPosition(screenWidth / 2 - 5, screenHeight / 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(gameName);
            Thread.Sleep(1500);
            Console.Clear();
        }

        /// <summary>
        /// The screen which is showed at the beginning of each game.
        /// </summary>
        public static void NewGameStartScreen()
        {
            Console.Clear();
            Console.WindowWidth = screenWidth;
            Console.WindowHeight = screenHeight;

            Console.SetCursorPosition(screenWidth / 2 - 5, screenHeight / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Get Ready!");
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 3; i >= 1; --i)
            {
                Console.SetCursorPosition(screenWidth / 2, screenHeight / 2);
                Console.Write(i);
                Thread.Sleep(800);
            }

            Console.SetCursorPosition(screenWidth / 2 - 3, screenHeight / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fight!");
            Thread.Sleep(800);
            Console.SetCursorPosition(0, 0);
            Console.Clear();
        }

        /// <summary>
        /// The screen which is showed when the game ends
        /// </summary>
        public static void GameOver(object sender, GameOverEventArgs args)
        {
            Console.Clear();
            if (args.PlayersWithMaximalScore.Count == 0)
            {
                Console.WriteLine("DRAW.");
            }
            else if (args.PlayersWithMaximalScore.Count == 1)
            {
                Console.WriteLine("The winner is: " + args.PlayersWithMaximalScore[0].Name);
                if (args.PlayersWithMaximalScore[0].Score > 0)
                {
                    Console.WriteLine("With Score: " + args.PlayersWithMaximalScore[0].Score);
                }
            }
            else
            {
                Console.WriteLine("Players with maximum score of {0} :", args.PlayersWithMaximalScore[0].Score);
                foreach (var player in args.PlayersWithMaximalScore)
                {
                    Console.WriteLine(player.Name);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine();

            Console.SetCursorPosition(screenWidth / 2 - 7, screenHeight / 2 - 2);
            Console.Write("GAME OVER!");


            System.Threading.Thread.Sleep(1500);

            Console.SetCursorPosition(screenWidth / 2 - 10, screenHeight / 2 + 1);
            Console.Write("New game (Y/N): ");
            string input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.SetCursorPosition(screenWidth / 2 - 6, screenHeight / 2 + 2);
                Console.WriteLine("GoodBye");

                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}
