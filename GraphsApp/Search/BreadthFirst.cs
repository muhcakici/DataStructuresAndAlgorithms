using System;
using System.Collections.Generic;

namespace GraphsApp.Search
{
    public class BreadthFirst<T>
    {
        public bool Find(IGraph<T> graph, T vertexKey)
        {
            return bfs(graph.ReferanceVertex,new HashSet<T>(), vertexKey);
        }
        private bool bfs(IGraphVertex<T> referanceVertex, 
            HashSet<T> visited, T searchVertex)
        {
            var bfsQueue = new Queue<IGraphVertex<T>>();
            bfsQueue.Enqueue(referanceVertex);
            visited.Add(referanceVertex.Key);
            Console.WriteLine(referanceVertex.Key);
            while (bfsQueue.Count>0)
            {
                var current = bfsQueue.Dequeue();
                if (current.Key.Equals(searchVertex))
                    return true;
                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.TargetVertexKey))
                        continue;
                    visited.Add(edge.TargetVertexKey);
                    Console.WriteLine(edge.TargetVertexKey);
                    bfsQueue.Enqueue(edge.TargetVertex);
                }
            }
            return false;
        }
    }
}
