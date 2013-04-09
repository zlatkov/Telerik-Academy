using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AcademyGamePlay
{
    class TanksGame
    {
        const int battleFieldHeight = 35;  
        const int battleFieldWidth = 100;  
        const int battleTime = 120; // in seconds.

        static void Main()
        {
            ScreenManager.SetScreenResolution(battleFieldHeight, battleFieldWidth);
            ScreenManager.SplashScreen();

            while(true)
            {
                ScreenManager.NewGameStartScreen();

                ConsoleRenderer renderer = new ConsoleRenderer(battleFieldHeight, battleFieldWidth);
                
                Engine gameEngine = new Engine(renderer, battleTime);
                gameEngine.OnGameOver += ScreenManager.GameOver; 

                Initialize(gameEngine);

                gameEngine.Run();

            } 
        }

        /// <summary>
        /// Initializes the game engine.
        /// </summary>
        static void Initialize(Engine gameEngine)
        {
            KeyboardInterface keyboard1 = new KeyboardInterface(Environment.CurrentDirectory + "../../../player1settings.txt");
            KeyboardInterface keyboard2 = new KeyboardInterface(Environment.CurrentDirectory + "../../../player2settings.txt");

            HumanPlayer p1 = new HumanPlayer("player1", new GridPosition(2, 2), ObjectColor.Yellow, keyboard1);
            HumanPlayer p2 = new HumanPlayer("player2", new GridPosition(battleFieldHeight - 3, battleFieldWidth - 4), ObjectColor.White, keyboard2);

            gameEngine.AddObject(p1);
            gameEngine.AddObject(p2);

            int startRow = 1;
            // Left wall
            for (int i = startRow; i < battleFieldHeight - 1; i++)
            {
                Wall pillar = new Wall(new GridPosition(i, 0));
                gameEngine.AddObject(pillar);
            }

            // Top wall
            for (int i = 1; i < battleFieldWidth - 2; i++)
            {
                Wall pillar = new Wall(new GridPosition(startRow, i));
                gameEngine.AddObject(pillar);
            }

            // Right wall
            for (int i = startRow; i < battleFieldHeight - 1; i++)
            {
                Wall pillar = new Wall(new GridPosition(i, battleFieldWidth - 2));
                gameEngine.AddObject(pillar);
            }

            // Bottom wall
            for (int i = 1; i < battleFieldWidth - 2; i++)
            {
                Wall pillar = new Wall(new GridPosition(battleFieldHeight - 2, i));
                gameEngine.AddObject(pillar);
            }

            Random rand = new Random();

            for (int i = 0; i < 100; ++i)
            {
                gameEngine.AddObject(BlockFactory.CreateBlock(
                    rand.Next(20),
                    new GridPosition(rand.Next(3, battleFieldHeight - 3), rand.Next(3, battleFieldWidth - 4)),
                    ObjectColor.White)
                    );
            }

            for (int i = 0; i < 5; ++i)
            {
                gameEngine.AddObject(BlockFactory.CreateBlock(1,
                    new GridPosition(rand.Next(3, battleFieldHeight - 3), rand.Next(3, battleFieldWidth - 4)),
                    ObjectColor.Gray)
                    );
            }

            for (int i = 0; i < 5; ++i)
            {
                gameEngine.AddObject(BlockFactory.CreateBlock(2,
                    new GridPosition(rand.Next(3, battleFieldHeight - 3), rand.Next(3, battleFieldWidth - 4)),
                    ObjectColor.Gray)
                    );
            }
        }

    }
}
