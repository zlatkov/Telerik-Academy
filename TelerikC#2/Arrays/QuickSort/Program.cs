using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {

        private static void QuickSortStrings(List<string> list, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = ((left + right) / 2);
            string x = list[pivot];

            while (i <= j)
            {
                while (list[i].CompareTo(x) == -1)
                {
                    i++;
                }
                while (x.CompareTo(list[j]) == -1)
                {
                    j--;
                }
                if (i <= j)
                {
                    string tmp = list[i];
                    list[i++] = list[j];
                    list[j--] = tmp;
                }
            }
            if (left < j)
            {
                QuickSortStrings(list, left, j);
            }
            if (i < right)
            {
                QuickSortStrings(list, i, right);
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<string> list = new List<string>();
            for (int i = 0; i < n; ++i)
            {
                string tmp = Console.ReadLine();
                list.Add(tmp);
            }

            QuickSortStrings(list, 0, n - 1);
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
