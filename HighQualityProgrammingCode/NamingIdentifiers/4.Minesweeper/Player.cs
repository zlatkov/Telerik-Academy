using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Minesweeper
{
    public class Player
    {
        string name;
        int score;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Player() { }

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
