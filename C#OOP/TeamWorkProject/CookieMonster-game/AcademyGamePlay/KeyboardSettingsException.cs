using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// This exception is thrown when some of the required keys is missing in the settings file.
    /// </summary>
    public class KeyboardSettingsException : ApplicationException
    {
        public KeyboardSettingsException(string missingKey)
            : base("The settings file is missing:" + missingKey)
        {
            this.MissingKey = missingKey; 
        }

        /// <summary>
        /// Gets the key which is missing in the file.
        /// </summary>
        public string MissingKey { private set; get; }
    }
}
