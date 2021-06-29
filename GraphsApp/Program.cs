using GraphsApp.Graph.AdjancencyMatrix;
using GraphsApp.Search;
using System;

namespace GraphsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>();
            for (int i = 0; i < 7; i++)
            {
                graph.AddVertex(i);
            }
            var first = new BreadthFirst<int>();
            first.Find(graph, 100);
            

            //var graph = new Graph<char>();
            //graph.AddVertex('A');
            //graph.AddVertex('B');
            //graph.AddVertex('C');
            //graph.AddVertex('D');

            //graph.AddEdge('A', 'B');
            //graph.AddEdge('A', 'D');
            //graph.AddEdge('C', 'D');
            //graph.AddEdge('A', 'C');


            //foreach (var vertex in graph)
            //{
            //    Console.WriteLine($"{vertex}({graph.EdgesCount(vertex)})");
            //    foreach (var edge in graph.Edges(vertex))
            //    {
            //        Console.WriteLine("\t{0}",edge);
            //    }
            //}


            
            var graph2 = new Graph<int>();
            for (int i = 0; i < 12; i++)
                graph2.AddVertex(i);

            graph2.AddEdge(0, 1);
            graph2.AddEdge(1, 4);
            graph2.AddEdge(0, 4);
            graph2.AddEdge(0, 2);
            graph2.AddEdge(2, 9);
            graph2.AddEdge(2, 10);
            graph2.AddEdge(2, 5);
            graph2.AddEdge(9, 11);
            graph2.AddEdge(10, 11);
            graph2.AddEdge(5, 6);
            graph2.AddEdge(5, 7);
            graph2.AddEdge(5, 8);
            graph2.AddEdge(7, 8);

            //DFS
            var algorithm = new DepthFirst<int>();
            var result = algorithm.Find(graph2, 7);
            if (result)
            {
                Console.WriteLine("The vertex has found.");
            }
            else
            {
                Console.WriteLine("The vertex not found.");
            }

            //BFS
            var algorithm2 = new BreadthFirst<int>();
            var result2 = algorithm2.Find(graph2, 8);
            if (result2)
            {
                Console.WriteLine("The vertex has found.");
            }
            else
            {
                Console.WriteLine("The vertex not found.");
            }

            











        }
    }
}
