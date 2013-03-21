using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace AcademyGamePlay
{
    /// <summary>
    /// The user interacts with the game using a kayboard.
    /// </summary>
    public class KeyboardInterface : IUserInterface
    {
        //All the needed keys to control a player.
        private const string moveLeftKey = "moveLeftKey";
        private const string moveRightKey = "moveRightKey";
        private const string moveDownKey = "moveDownKey";
        private const string moveUpKey = "moveUpKey";
        private const string actionKey = "actionKey";

        //Simulates a buffer when the users press keys on the keyboard.
        private static List<ConsoleKeyInfo> keysPressed;

        //The maximum number of keys which are stored in the buffer.
        private const int MaximumBufferSize = 64;

        //Maps one of the keys to a string.
        private Dictionary<string, string> keyMapping; 

        public event EventHandler OnLeftRequest;
        public event EventHandler OnRightRequest;
        public event EventHandler OnUpRequest;
        public event EventHandler OnDownRequest;
        public event EventHandler OnActionRequest;

        /// <summary>
        /// Creates an object of the KeyboradInterface class.
        /// </summary>
        /// <param name="fileSettings">Name of a file, which contains the settings.</param>
        public KeyboardInterface(string fileSettings)
        {
            if (KeyboardInterface.keysPressed == null)
            {
                KeyboardInterface.keysPressed = new List<ConsoleKeyInfo>();
            }
            InitializeSettings(fileSettings);
        }

        /// <summary>
        /// Loads the settings from the specified file.
        /// </summary>
        /// <param name="fileSettings">The name of the file, which contains the settings.</param>
        private void InitializeSettings(string fileSettings)
        {
            keyMapping = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(fileSettings))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    keyMapping.Add(parts[0], parts[1]);
                }

                //If some of the keys is not specified in the settings file, an exception in thrown.
                if (!keyMapping.ContainsKey(moveLeftKey))
                {
                    throw new KeyboardSettingsException(moveLeftKey);
                }
                else if (!keyMapping.ContainsKey(moveUpKey))
                {
                    throw new KeyboardSettingsException(moveUpKey);
                }
                else if (!keyMapping.ContainsKey(moveRightKey))
                {
                    throw new KeyboardSettingsException(moveRightKey);
                }
                else if (!keyMapping.ContainsKey(moveDownKey))
                {
                    throw new KeyboardSettingsException(moveDownKey);
                }
                else if (!keyMapping.ContainsKey(actionKey))
                {
                    throw new KeyboardSettingsException(actionKey);
                }
            }   
        }

        /// <summary>
        /// Processes an input from the player.
        /// </summary>
        public void ProcessInput()
        {
            //Adds the pressed key to the buffer.
            if (Console.KeyAvailable)
            {
                KeyboardInterface.keysPressed.Add(Console.ReadKey(true));
            }

            if (KeyboardInterface.keysPressed.Count > KeyboardInterface.MaximumBufferSize)
            {
                KeyboardInterface.keysPressed.RemoveAt(0);
            }

            //If there are available keys in the buffer, retreives the first key from the buffer which can be used
            //from the current player.
            if (KeyboardInterface.keysPressed.Count > 0)
            {
                for (int i = 0; i < KeyboardInterface.keysPressed.Count; ++i)
                {
                    ConsoleKeyInfo keyData = KeyboardInterface.keysPressed[i];
                    EventHandler handler = null;

                    if (keyData.Key.ToString() == keyMapping[moveLeftKey])
                    {
                        handler = this.OnLeftRequest;
                    }
                    else if (keyData.Key.ToString() == keyMapping[moveUpKey])
                    {
                        handler = OnUpRequest;
                    }
                    else if (keyData.Key.ToString() == keyMapping[moveRightKey])
                    {
                        handler = this.OnRightRequest;
                    }
                    else if (keyData.Key.ToString() == keyMapping[moveDownKey])
                    {
                        handler = this.OnDownRequest;
                    }
                    else if (keyData.Key.ToString() == keyMapping[actionKey])
                    {
                        handler = this.OnActionRequest;
                    }

                    if (handler != null)
                    {
                        handler(this, new EventArgs());

                        KeyboardInterface.keysPressed.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
