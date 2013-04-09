using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Represents the game engine.
    /// </summary>
    public class Engine
    {
        private List<GameObject> staticObjects;    //Holds all the static objects in the game.
        private List<MovingObject> movingObjects;  //Holds all the moving objects in the game.
        private List<Player> players;              //Holds all the players in the game.
        private List<GameObject> allObjects;       //Holds all the objects in the game.

        private IRenderer renderer;
        private DashBoard scoreBoard;
        private bool gameIsOver;       //Determines if the game has ended.
        private Timer timer;          

        public const int MaximumPlayers = 4;  //The maximum number of players which can play the game.

        public event EventHandler<GameOverEventArgs> OnGameOver;  //Dispatches when the game finishes.

        public Engine(IRenderer renderer, int gameLengthSeconds)
        {
            this.scoreBoard = new DashBoard(ObjectColor.White);
            this.timer = new Timer(gameLengthSeconds);
            this.gameIsOver = false;
            this.renderer = renderer;

            this.staticObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.players = new List<Player>();
            this.allObjects = new List<GameObject>();
        }

        /// <summary>
        /// Adds a new object to the objects in the game.
        /// </summary>
        public virtual void AddObject(GameObject obj)
        {
            if (obj is Player)
            {
                this.players.Add(obj as Player);
                if (this.players.Count > 4)
                {
                    throw new ArgumentException("The maximum number of allowed players is: " + Engine.MaximumPlayers);
                }
                this.movingObjects.Add(obj as MovingObject);
            }
            else if (obj is MovingObject)
            {
                this.movingObjects.Add(obj as MovingObject);
            }
            else
            {
                this.staticObjects.Add(obj);
            }
            this.allObjects.Add(obj);
        }

        /// <summary>
        /// Checks if there is a winner or all the players are dead.
        /// </summary>
        protected virtual void CheckForGameOver()
        {
            EventHandler<GameOverEventArgs> handler = OnGameOver;
            if (this.players.Count == 0)
            {
                this.gameIsOver = true;

                if (handler != null)
                {
                    handler(this, new GameOverEventArgs(new List<Player>()));
                }
            }
            else if (this.players.Count == 1)
            {
                this.gameIsOver = true;

                if (handler != null)
                {
                    handler(this, new GameOverEventArgs(new List<Player>() { this.players[0] }));
                }
            }
        }

        /// <summary>
        /// Is invoked when the timer has finished.
        /// </summary>
        protected virtual void TimeFinished(object sender, EventArgs args)
        {
            this.gameIsOver = true;

            int playerMaxScore = 0;
            List<Player> playersWithMaximalScore = new List<Player>();

            foreach (var player in this.players)
            {
                playerMaxScore = Math.Max(playerMaxScore, player.Score);
            }

            foreach (var player in this.players)
            {
                if (player.Score == playerMaxScore)
                {
                    playersWithMaximalScore.Add(player);
                }
            }

            EventHandler<GameOverEventArgs> handler = OnGameOver;
            if (handler != null)
            {
                handler(this, new GameOverEventArgs(playersWithMaximalScore));
            }
        }

        /// <summary>
        /// Starts the game with the provided data.
        /// </summary>
        public virtual void Run()
        {
            //Attathes an event handler when the timer finishes.
            this.timer.OnTimerFinished += TimeFinished;

            while (!gameIsOver)
            {
                //Holds the objects from the score board.
                List<StaticObject> scoreBoardObjects = this.scoreBoard.ConvertToStaticObjects(this.timer.SecondsLeft, this.players);
                foreach (var scoreBoardObject in scoreBoardObjects)
                {
                    this.renderer.EnqueueForRendering(scoreBoardObject);
                }

                this.timer.Update();
                this.renderer.RenderAllObjects();

                foreach (var player in this.players)
                {
                    player.MakeMove();
                }

                this.renderer.ClearQueue();

                CollisionDispatcher.HandleCollisions(this.staticObjects, this.movingObjects);

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                List<GameObject> producedObjects = new List<GameObject>();

                //Adds the new objects which were produced.
                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                //Remove all the objects which are destroyed.
                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.players.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }

                //Check if there is a winner.
                CheckForGameOver();

                //Check if the timer has finished.
                this.timer.Check();
            }
        }
    }
}

