using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Represents an event which is thrown when the game finishes.
    /// </summary>
    public class GameOverEventArgs : EventArgs
    {
        //Holds the alive players which have the biggest score when the game ends.
        private List<Player> playersWithMaximalScore;

        public GameOverEventArgs(List<Player> playersWithMaximalScore)
        {
            this.playersWithMaximalScore = new List<Player>();
            foreach (var player in playersWithMaximalScore)
            {
                this.playersWithMaximalScore.Add(player);
            }
        }

        /// <summary>
        /// Gets the alive players which have the biggest score when the game ends.
        /// </summary>
        public List<Player> PlayersWithMaximalScore
        {
            get
            {
                return this.playersWithMaximalScore;
            }
        }
    }
}
