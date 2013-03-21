using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AcademyGamePlay
{
    /// <summary>
    /// The object which describes the human player.
    /// </summary>
    public class HumanPlayer : Player
    {
        //The interface which controls the player.
        private IUserInterface userInterface;

        public HumanPlayer(string name, GridPosition position, ObjectColor color, IUserInterface userInterface)
            : base(name, position, color)
        {
            this.userInterface = userInterface;

            this.userInterface.OnLeftRequest += OnMoveLeft;

            this.userInterface.OnRightRequest += OnMoveRight;

            this.userInterface.OnDownRequest += OnMoveDown;

            this.userInterface.OnUpRequest += OnMoveUp;

            this.userInterface.OnActionRequest += OnShoot;
        }

        public override void MakeMove()
        {
            this.userInterface.ProcessInput();
        }

    }
}
