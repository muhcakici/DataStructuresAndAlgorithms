using System;

namespace SortingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new char[] { 'M', 'U', 'H', 'A', 'M', 'E','T' };
            foreach (var item in arr)
            {
                Console.Write($"{item,5}");
            }
            Console.WriteLine();
            InsertionSort.Sort(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item,5}");
            }
        }
    }
}
