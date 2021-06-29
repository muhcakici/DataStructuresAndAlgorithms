using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsApp
{
    public interface IGraph<T>
    {
        bool IsWeightedGraph { get; }
        int VertexCount { get; }
        IGraphVertex<T> ReferanceVertex { get; }
        bool ContainsVertex(T key);
        IGraphVertex<T> GetVertex(T key);
        IEnumerable<IGraphVertex<T>> VerticesAsEnumereble { get; }
        bool HasEdge(T source, T dest);
        IGraph<T> Clone();
    }

    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }
        IEnumerable<IEdge<T>> Edges { get; }
        IEdge<T> GetEdge(IGraphVertex<T> targetVertex);
    }

    public interface IEdge<T>
    {
        W Weight<W>() where W : IComparable;
        T TargetVertexKey { get; }
        IGraphVertex<T> TargetVertex { get; }
    }

    public class Edge<T, C> : IEdge<T> where C : IComparable
    {
        private object weight;
        public T TargetVertexKey => TargetVertex.Key;
        public IGraphVertex<T> TargetVertex { get; private set; }
        public Edge(IGraphVertex<T> target, C weight)
        {
            this.TargetVertex = target;
        }
        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
    }
}
