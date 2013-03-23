using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public abstract class EncryptableBinaryDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; protected set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override string ToString()
        {
            if (this.IsEncrypted)
            {
                return String.Format("{0}[encrypted]", this.GetType().Name);
            }
            else
            {
                return base.ToString();
            }
        }
    }

