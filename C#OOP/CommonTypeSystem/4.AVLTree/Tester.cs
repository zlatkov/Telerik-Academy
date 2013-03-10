using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AVLTree
{
    class Tester
    {
        static void Main(string[] args)
        {
            AVLTree<int, int> tree1 = new AVLTree<int, int>();
            AVLTree<int, int> tree2 = new AVLTree<int, int>();

            tree1.Insert(1, 1);
            tree1.Insert(465456544, 465456544);
            tree1.Insert(43, 43);
            tree1.Insert(-43, -43);
            tree1.Insert(-66, -66);
          
            tree2.Insert(1, 1);
            tree2.Insert(465456544, 465456544);
            tree2.Insert(43, 43);
            tree2.Insert(-43, -43);
            tree2.Insert(-66, -66);

            Console.WriteLine(tree1);

            Console.WriteLine("hash codes: " + tree1.GetHashCode() + "  " + tree2.GetHashCode());
            Console.WriteLine("tree1 == tree2 " + (tree1 == tree2));

            foreach (var node in tree1)
            {
                Console.WriteLine(node);
            }


        }
    }
}
