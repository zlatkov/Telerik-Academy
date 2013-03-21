using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Represents the DashBoard which displays the time left and information about all the players in the game.
    /// </summary>
    public class DashBoard 
    {
        private const string SecondsLeftLabel = "Seconds left:";
        private const string ScoreLabel = "Score:";
        private const string HealthLabel = "Health:";

        public DashBoard(ObjectColor scoreboardColor)
        {
            this.Color = scoreboardColor;
        }

        /// <summary>
        /// Gets the color of the DashBoard.
        /// </summary>
        public ObjectColor Color { private set; get; }

        /// <summary>
        /// Converts the text from the DashBoard to static objects, which can be rendered by the renderer
        /// used in the game.
        /// </summary>
        public List<StaticObject> ConvertToStaticObjects(int secondsLeft, List<Player> players)
        {
            int lastCol = 0;

            //Holds all the converted static objects.
            List<StaticObject> result = new List<StaticObject>();

            //Converts the SecondsLeftLabel to static objects.
            for (int i = 0; i < DashBoard.SecondsLeftLabel.Length; ++i, ++lastCol)
            {
                result.Add(new StaticObject(new GridPosition(0, lastCol), SecondsLeftLabel[i], this.Color));
            }
            lastCol++;

            string secondsLeftString = secondsLeft.ToString();

            //Converts the time left argument to static objects.
            for (int i = 0; i < secondsLeftString.Length; ++i, ++lastCol)
            {
                result.Add(new StaticObject(new GridPosition(0, lastCol), secondsLeftString[i], this.Color));
            }
            lastCol += 3;

            for (int p = 0; p < players.Count; ++p)
            {
                var player = players[p];

                //Converts the name of each player to static objects.
                for (int i = 0; i < player.Name.Length; ++i, ++lastCol)
                {
                    result.Add(new StaticObject(new GridPosition(0, lastCol), player.Name[i], this.Color));
                }

                result.Add(new StaticObject(new GridPosition(0, lastCol++), '(', this.Color));

                //Converts the HealthLabel to static objects.
                for (int i = 0; i < DashBoard.HealthLabel.Length; ++i, ++lastCol)
                {
                    result.Add(new StaticObject(new GridPosition(0, lastCol), DashBoard.HealthLabel[i], this.Color));
                }
                ++lastCol;

                string tmpHealth = player.Health.ToString();

                //Converts the health of the current player to static objects.
                for (int i = 0; i < tmpHealth.Length; ++i, ++lastCol)
                {
                    result.Add(new StaticObject(new GridPosition(0, lastCol), tmpHealth[i], this.Color));
                }
                lastCol++;

                result.Add(new StaticObject(new GridPosition(0, lastCol++), '|', this.Color));
                lastCol++;

                //Converts the ScoreLabel to static objects.
                for (int i = 0; i < DashBoard.ScoreLabel.Length; ++i, ++lastCol)
                {
                    result.Add(new StaticObject(new GridPosition(0, lastCol), DashBoard.ScoreLabel[i], this.Color));
                }
                lastCol++;

                string tmpScore = player.Score.ToString();

                //Converts the score of the current player to static objects.
                for (int i = 0; i < tmpScore.Length; ++i, ++lastCol)
                {
                    result.Add(new StaticObject(new GridPosition(0, lastCol), tmpScore[i], this.Color));
                }

                result.Add(new StaticObject(new GridPosition(0, lastCol++), ')', this.Color));

                if (p < players.Count - 1)
                {
                    result.Add(new StaticObject(new GridPosition(0, lastCol++), ',', this.Color));
                }
                ++lastCol;
            }

            return result;
        }
    }
}
