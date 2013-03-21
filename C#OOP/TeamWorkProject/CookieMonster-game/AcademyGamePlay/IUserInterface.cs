using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    public interface IUserInterface
    {
        /// <summary>
        /// Handles the screenHeight movement requests.
        /// </summary>
        event EventHandler OnLeftRequest;

        /// <summary>
        /// Handles the right movement requests.
        /// </summary>
        event EventHandler OnRightRequest;

        /// <summary>
        /// Handles the up movement requests.
        /// </summary>
        event EventHandler OnUpRequest;

        /// <summary>
        /// Handles the down movement requests.
        /// </summary>
        event EventHandler OnDownRequest;

        /// <summary>
        /// Handles the action requests.
        /// </summary>
        event EventHandler OnActionRequest;

        /// <summary>
        /// Processes the user input.
        /// </summary>
        void ProcessInput();
    }
}
