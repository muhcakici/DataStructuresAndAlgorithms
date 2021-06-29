using BinaryHeap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsApp.MinimumSpaningTree
{
    public class Prims<T,W>
        where W:IComparable
    {
        public List<MSTEdge<T,W>> FindMinimumSpaningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, W>>();
            dfs(graph, graph.ReferanceVertex,
                new MinHeap<MSTEdge<T, W>>(),
                new HashSet<T>(), edges);
            return edges;
        }

        private void dfs(IGraph<T> graph,
            IGraphVertex<T> currentVertex,
            MinHeap<MSTEdge<T,W>> spannTreeNeighbours,
            HashSet<T> spanTreeVertex,
            List<MSTEdge<T,W>> spanTreeEdges)
        {
            while (true)
            {
                foreach (var edge in currentVertex.Edges)
                {
                    spannTreeNeighbours.Add(new MSTEdge<T, W>(currentVertex.Key, 
                        edge.TargetVertexKey, 
                        edge.Weight<W>()));
                }
            }

            var minNeighboursEdge=spannTreeNeighbours.DeleteMinMax();

            while (spanTreeVertex.Contains(minNeighboursEdge.Source) &&
                spanTreeVertex.Contains(minNeighboursEdge.Destination))
            {
                minNeighboursEdge = spannTreeNeighbours.DeleteMinMax();

                if (spannTreeNeighbours.Count()==0)
                    return;
            }

            if (!spanTreeVertex.Contains(minNeighboursEdge.Source))
            {
                spanTreeVertex.Add(minNeighboursEdge.Source);
            }

            spanTreeVertex.Add(minNeighboursEdge.Destination);

            spanTreeEdges.Add(minNeighboursEdge);

            var graph1 = graph;
            currentVertex = graph1.GetVertex(minNeighboursEdge.Destination);
        }
    }
}
