using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GenericList
{
    public class GenericList<T> where T:IComparable
    {
        private T[] items;
        private int count;
        private int capacity;

        public GenericList() : this(8)
        {
        }

        public GenericList(int capacity)
        {
            this.count = 0;
            Resize(capacity);
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return items[index];
                }
            }
        }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                Resize(Count * 2);
            }
            items[this.count++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    items[i] = items[i + 1];
                }
                this.count--;
            } 
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (Capacity == Count)
                {
                    Resize(Count * 2);
                }

                T tmp1 = items[index];
                items[index] = item;

                for (int i = index + 1; i < Count; ++i)
                {
                    T tmp2 = items[i];
                    items[i] = tmp1;
                    tmp1 = tmp2;
                }
                items[this.count++] = tmp1;
            }
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (items[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (items[i].CompareTo(item) == 0)
                {
                    RemoveAt(i);
                }
            }
        }

        public void Clear()
        {
            this.count = 0;
        }

        public T Min()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else
            {
                int resultIndex = 0;
                for (int i = 1; i < Count; ++i)
                {
                    if (items[i].CompareTo(items[resultIndex]) == -1)
                    {
                        resultIndex = i;
                    }
                }
                return items[resultIndex];
            }
        }

        public T Max()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else
            {
                int resultIndex = 0;
                for (int i = 1; i < Count; ++i)
                {
                    if (items[i].CompareTo(items[resultIndex]) == 1)
                    {
                        resultIndex = i;
                    }
                }
                return items[resultIndex];
            }
        }

        private void Resize(int newCapacity)
        {
            T[] tmpItems = new T[Capacity];
            for (int i = 0; i < Count; ++i)
            {
                tmpItems[i] = items[i];
            }

            items = new T[newCapacity];

            for (int i = 0; i < Capacity; ++i)
            {
                items[i] = tmpItems[i];
            }

            this.capacity = newCapacity;
        }

        private void Swap(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < Count; ++i)
            {
                result.Append(items[i]);
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
