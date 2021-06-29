using LinkedList_DoubleList;
using System;
using System.Collections.Generic;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new MinHeap<int>(new int[] { 23, 12, 44, 16, 6, 32, 55 });
            foreach (var item in heap)
                Console.WriteLine(heap.DeleteMinMax());
        }
    }
}
