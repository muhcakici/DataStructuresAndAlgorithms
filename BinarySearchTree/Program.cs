using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new BST<int>() { 40, 30, 70, 80, 35, 45, 55 };
            foreach (var item in list)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            Console.WriteLine(list.Root.Item);
            BST<int>.InOrder(list.Root);
            
            Console.ReadKey();
        }
    }
}
