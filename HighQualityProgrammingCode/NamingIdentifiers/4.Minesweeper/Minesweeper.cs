namespace _4.Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Minesweeper
    {
        const int MaxScore = 35;
        const int MaxTopPlayersToKeep = 5;

        private static readonly Random randomNumbersGenerator = new Random();

        static void Main(string[] аргументи)
        {
            string command = string.Empty;

            char[,] gameField = CreateGameField();
            char[,] mines = GenerateMines();
            List<Player> topPlayers = new List<Player>(MaxTopPlayersToKeep + 1);

            int row = 0;
            int col = 0;
            int count = 0;

            bool isNewGame = true;
            bool hasExploded = false;
            bool hasReachedMaxScore = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Try to clear the minefield without detonating a mine.\n" +
                                     "Commands:\n" +
                                     "'top' shows the top results,\n" + 
                                     "'restart' starts a new game,\n" +
                                     "'exit' exits the game.\n");

                    DisplayGameField(gameField);
                    isNewGame = false;
                }
                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        DisplayScores(topPlayers);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = GenerateMines();
                        DisplayGameField(gameField);
                        hasExploded = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                UpdateAdjacentMinesCount(gameField, mines, row, col);
                                count++;
                            }
                            if (MaxScore == count)
                            {
                                hasReachedMaxScore = true;
                            }
                            else
                            {
                                DisplayGameField(gameField);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError, invalid command!\n");
                        break;
                }
                if (hasExploded)
                {
                    DisplayGameField(mines);
                    Console.Write("\nYou have died with {0} points. ", count);
                    Console.Write("Enter your username: ");

                    string nickName = Console.ReadLine();
                    Player currentPlayer = new Player(nickName, count);
                    if (topPlayers.Count < MaxTopPlayersToKeep)
                    {
                        topPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Score < currentPlayer.Score)
                            {
                                topPlayers.Insert(i, currentPlayer);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }
                    topPlayers.Sort((Player p1, Player p2) => p2.Name.CompareTo(p1.Name));
                    topPlayers.Sort((Player p1, Player p2) => p2.Score.CompareTo(p1.Score));
                    DisplayScores(topPlayers);

                    gameField = CreateGameField();
                    mines = GenerateMines();
                    count = 0;
                    hasExploded = false;
                    isNewGame = true;
                }
                if (hasReachedMaxScore)
                {
                    Console.WriteLine("\nGood job! You have successfully opened {0} cells.", MaxScore);
                    DisplayGameField(mines);

                    Console.WriteLine("Enter your nickname: ");
                    string nickName = Console.ReadLine();
                    Player currentPlayer = new Player(nickName, count);

                    topPlayers.Add(currentPlayer);
                    DisplayScores(topPlayers);

                    gameField = CreateGameField();
                    mines = GenerateMines();

                    count = 0;
                    hasReachedMaxScore = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria.");
            Console.Read();
        }

        private static void DisplayScores(List<Player> players)
        {
            Console.WriteLine("\nPoints:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points.",
                        i + 1, players[i].Name, players[i].Score);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The result list is empty!\n");
            }
        }

        private static void UpdateAdjacentMinesCount(char[,] gameField,
            char[,] minesField, int row, int col)
        {
            char adjacentMinesCount = CountAdjacentMines(minesField, row, col);
            minesField[row, col] = adjacentMinesCount;
            gameField[row, col] = adjacentMinesCount;
        }

        private static void DisplayGameField(char[,] gameField)
        {
            int rowsCount = gameField.GetLength(0);
            int colsCount = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowsCount; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write(string.Format("{0} ", gameField[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int gameFieldRows = 5;
            int gameFieldColumns = 10;
            char[,] gameField = new char[gameFieldRows, gameFieldColumns];
            for (int i = 0; i < gameFieldRows; i++)
            {
                for (int j = 0; j < gameFieldColumns; j++)
                {
                    gameField[i, j] = '?';
                }
            }

            return gameField;
        }

        private static char[,] GenerateMines()
        {
            int rowsCount = 5;
            int colsCount = 10;
            char[,] minesField = new char[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    minesField[i, j] = '-';
                }
            }

            List<int> randomNumbersList = new List<int>();
            while (randomNumbersList.Count < 15)
            {
                int newRandomNumber = randomNumbersGenerator.Next(rowsCount * colsCount);
                if (!randomNumbersList.Contains(newRandomNumber))
                {
                    randomNumbersList.Add(newRandomNumber);
                }
            }

            foreach (int number in randomNumbersList)
            {
                int row = (number / colsCount);
                int col = (number % colsCount);
                
                minesField[row, col] = '*';
            }

            return minesField;
        }

        private static char CountAdjacentMines(char[,] gameField, int row, int col)
        {
            int adjacentMinesCount = 0;
            int rowsCount = gameField.GetLength(0);
            int colsCount = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, col] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (row + 1 < rowsCount)
            {
                if (gameField[row + 1, col] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (col - 1 >= 0)
            {
                if (gameField[row, col - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (col + 1 < colsCount)
            {
                if (gameField[row, col + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameField[row - 1, col - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < colsCount))
            {
                if (gameField[row - 1, col + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row + 1 < rowsCount) && (col - 1 >= 0))
            {
                if (gameField[row + 1, col - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row + 1 < rowsCount) && (col + 1 < colsCount))
            {
                if (gameField[row + 1, col + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            return char.Parse(adjacentMinesCount.ToString());
        }
    }
}
