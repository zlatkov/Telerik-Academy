using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensions
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = default(T);
            foreach (T item in collection)
            {
                sum += item;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;
            foreach (T item in collection)
            {
                product *= item;
            }
            return product;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            dynamic average = Sum<T>(collection);
            return average / collection.Count();
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (collection.Count() == 0)
            {
                return default(T);
            }

            T result = collection.First();
            foreach (T item in collection)
            {
                if (result.CompareTo(item) == 1)
                {
                    result = item;
                }
            }
            return result;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (collection.Count() == 0)
            {
                return default(T);
            }

            T result = collection.First();
            foreach (T item in collection)
            {
                if (result.CompareTo(item) == -1)
                {
                    result = item;
                }
            }
            return result;
        }
    }
}
