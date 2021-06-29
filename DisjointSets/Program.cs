using System;

namespace DisjointSets
{
    class Program
    {
        static void Main(string[] args)
        {
            var disjointSets = new DisJointSet<int>();
            for (int i = 1; i <= 8; i++)
                disjointSets.MakeSet(i);

            foreach (var item in disjointSets)
                Console.WriteLine(item);
            Console.WriteLine();

            disjointSets.Union(1, 2);
            disjointSets.Union(2, 3);
            disjointSets.Union(3, 4);
            disjointSets.Union(5, 6);
            disjointSets.Union(7, 8);

            disjointSets.PathFind(3);

            Console.WriteLine(disjointSets.FindSet(1));
            Console.WriteLine(disjointSets.FindSet(2));
            Console.WriteLine(disjointSets.FindSet(6));
            Console.WriteLine(disjointSets.FindSet(5));
            Console.WriteLine(disjointSets.FindSet(8));
            Console.WriteLine(disjointSets.FindSet(7));
            Console.WriteLine(disjointSets.FindSet(4));


            Console.WriteLine();
            Console.WriteLine(disjointSets.Count);


        }
    }
}
