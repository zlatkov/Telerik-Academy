using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Bit64Array
{
    public class Bit64Array : IEnumerable<ulong>
    {
        private ulong bits;

        public Bit64Array(ulong bits = 0)
        {
            this.bits = bits;
        }

        public Bit64Array(int bits)
        {
            this.bits = (ulong)bits;
        }

        public ulong this[int index]
        {
            set
            {
                if (index < 0 || index >= 64)
                {
                    throw new ArgumentOutOfRangeException("The index must be between 0 and 63 (inclusive).");
                }
                if (value == 0)
                {
                    this.bits &= ~(1ul << index);
                }
                else if (value == 1)
                {
                    this.bits |= 1ul << index;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The value must be either 1 or 0.");
                }
            }
            get
            {
                if (index < 0 || index >= 64)
                {
                    throw new ArgumentOutOfRangeException("The index must be between 0 and 63 (inclusive).");
                }
                else
                {
                    return (this.bits >> index) & 1;
                }
            }
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 0; i < 64; ++i)
            {
                yield return (this.bits >> i) & 1;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        { 
            return this.GetEnumerator(); 
        }

        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 63; i >= 0; --i)
            {
                result.Append((this.bits >> i) & 1);
            }
            return result.ToString();
        }

        public override int GetHashCode()
        {
            /* We will split our 64 bit array in two 32 bit blocks.
             * The first block will contain the bits from 32 to 63.
             * The second block will contain the bits from 0 to 31.
             * After that we will compute the 32 bit hash code using 
             * the bits of the first block XOR the bits of the second block. */

            int first32BitBlock = (int)(this.bits >> 32);
            int second32BitBlock = (int)(this.bits & (ulong)(0xffffffff));

            return first32BitBlock ^ second32BitBlock;
        }

        public override bool Equals(object obj)
        {
            Bit64Array bitArray = obj as Bit64Array;
            if (bitArray == null)
            {
                return false;
            }
            else 
            {
                return this.bits == bitArray.bits;
            }
        }

        public static bool operator ==(Bit64Array a, Bit64Array b)
        {
            return Bit64Array.Equals(a, b);
        }

        public static bool operator !=(Bit64Array a, Bit64Array b)
        {
            return !Bit64Array.Equals(a, b);
        }
    }
}
