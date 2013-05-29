using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Messaging
    {
        // A private instance of the class
        private static Messaging instance;
        private System.Collections.Generic.List<string> Messages;

        // The constructor for this message is private, so that cannot be instantiated
        private Messaging()
        {
            Messages = new System.Collections.Generic.List<string>();
        }

        // This private static property, will check if the static instance of the message
        // is instantiated if it is then it will return the static instance, if not it will
        // create a new instance.
        public static Messaging Instance
        {
            get
            {
                if (instance == null)
                    instance = new Messaging();
                return instance;
            }
        }

        public void AddMessage(string Message)
        {
            Messages.Add(Message);
        }

        public bool HasMessage(string Message)
        {
            return Messages.Contains(Message);
        }
    }

}
