using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 20;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2; 

            for (int i = startRow; i < WorldRows; ++i)
            {
                IndestructibleBlock indestructibleBlockLeft = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock indestructibleBlockRight = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));

                engine.AddObject(indestructibleBlockLeft);
                engine.AddObject(indestructibleBlockRight);
            }

            for (int i = 0; i < WorldCols; ++i)
            {
                IndestructibleBlock indestructibleBlockTop = new IndestructibleBlock(new MatrixCoords(startRow - 1, i));

                engine.AddObject(indestructibleBlockTop);
            }

            Random random = new Random();

            for (int row = 0; row < 3; ++row)
            {
                for (int i = startCol; i < endCol; i++)
                {
                    int rand = random.Next(4);
                    Block currBlock;
                    if (rand == 0)
                    {
                        currBlock = new ExplodingBlock(new MatrixCoords(startRow + row, i));
                    }
                    else if (rand == 1)
                    {

                        currBlock = new GiftBlock(new MatrixCoords(startRow + row, i));
                    }
                    else if (rand == 2)
                    {
                        currBlock = new UnpassableBlock(new MatrixCoords(startRow + row, i));
                    }
                    else
                    {
                        currBlock = new Block(new MatrixCoords(startRow + row, i));
                    }
                    engine.AddObject(currBlock);
                }
            }

            MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, WorldCols / 2),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            ShootingRacket theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            engine.AddObject(new TrailObject(new MatrixCoords(WorldRows - 1, 2), 5));
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            EngineShootingRacket gameEngine = new EngineShootingRacket(renderer, keyboard, 120);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            

            gameEngine.Run();
        }
    }
}
