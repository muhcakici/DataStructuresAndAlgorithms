using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphsApp.Graph.AdjancencyMatrix
{
    public class Graph<T> : IGraph<T>, IEnumerable<T>
    {
        private BitArray[] matrix;
        private Dictionary<T, int> vertexIndices;
        private Dictionary<int, T> reverseVertexIndices;
        private Dictionary<T, GraphVertex<T>> vertexObjects;

        private int maxSize => matrix.Length;
        private int usedSize;
        private int nextAvailableIndex;

        public bool IsWeightedGraph => false;
        public int VertexCount => usedSize;

        public Graph()
        {
            vertexIndices = new Dictionary<T, int>();
            reverseVertexIndices = new Dictionary<int, T>();
            vertexObjects = new Dictionary<T, GraphVertex<T>>();
            matrix = new BitArray[1];
            for (int i = 0; i < maxSize; i++)
            {
                matrix[i] = new BitArray(maxSize);
            }
        }

        public IGraphVertex<T> ReferenceVertex =>
            getReferenceVertex();

        private GraphVertex<T> getReferenceVertex()
        {
            if (this.VertexCount == 0)
            {
                throw new Exception("This is empty.");
            }

            return vertexObjects[this.First()];
        }

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable
            => vertexObjects.Select(x => x.Value);

        public IGraphVertex<T> ReferanceVertex => getReferenceVertex();

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumereble => throw new NotImplementedException();

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public Graph<T> Clone()
        {
            // deep copy
            var graph = new Graph<T>();
            foreach (var vertex in this)
            {
                // add
            }

            foreach (var vertex in this)
            {
                foreach (var item in this.Edges(vertex))
                {
                    // add edge
                }
            }
            return graph;
        }

        public bool ContainsVertex(T key)
        {
            return vertexObjects.ContainsKey(key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertexIndices.Select(x => x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertexObjects[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }

            if (!vertexIndices.ContainsKey(source)
                || !vertexIndices.ContainsKey(dest))
            {
                throw new Exception("Source or destination vertex is not in this graph.");
            }


            var sourceIndex = vertexIndices[source];
            var destIndex = vertexIndices[dest];

            if (matrix[sourceIndex].Get(destIndex)
                && matrix[destIndex].Get(sourceIndex))
                return true;
            else
                return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> Edges(T vertex)
        {
            var index = vertexIndices[vertex];
            for (int i = 0; i < maxSize; i++)
            {
                if (matrix[i].Get(index))
                {
                    yield return reverseVertexIndices[i];
                }
            }
        }

        public int EdgesCount(T vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException();
            }

            if (!vertexIndices.ContainsKey(vertex))
            {
                throw new Exception("The vertex is not in this graph.");
            }
            var count = 0;
            var index = vertexIndices[vertex];
            for (int i = 0; i < maxSize; i++)
            {
                if (matrix[i].Get(index))
                {
                    count++;
                }
            }
            return count;
        }

        private class GraphVertex<T> : IGraphVertex<T>
        {
            private Graph<T> graph;
            private int vertexIndex;
            private T vertexKey;

            private int maxSize => graph.maxSize;
            private BitArray[] matrix => graph.matrix;

            private Dictionary<T, int> vertexIndices => graph.vertexIndices;
            private Dictionary<int, T> reverseVertexIndices => graph.reverseVertexIndices;

            public GraphVertex(Graph<T> _graph, T _vertexKey)
            {
                if (_graph == null)
                {
                    throw new ArgumentNullException("The graph has not been defiend.");
                }

                if (!_graph.vertexIndices.ContainsKey(_vertexKey))
                {
                    throw new ArgumentException("The vertex is not in this graph.");
                }

                graph = _graph;
                vertexKey = _vertexKey;
                vertexIndex = _graph.vertexIndices[vertexKey];
            }

            public T Key => vertexKey;

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges =>
                graph.Edges(vertexKey)
                .Select(x => new Edge<T, int>(graph.vertexObjects[x], 1));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                if (!vertexIndices.ContainsKey(targetVertex.Key))
                {
                    throw new Exception("The vertex is not in this graph.");
                }

                var index = vertexIndices[targetVertex.Key];
                var key = targetVertex as GraphVertex<T>;
                return new Edge<T, int>(targetVertex, 1);
            }

            public IEdge<T> GetOutEdge(IGraphVertex<T> targetVertex)
            {
                if (!vertexIndices.ContainsKey(targetVertex.Key))
                {
                    throw new Exception("The vertex is not in this graph.");
                }

                var index = vertexIndices[targetVertex.Key];
                var key = targetVertex as GraphVertex<T>;
                return new Edge<T, int>(targetVertex, 1);
            }
        }

        public void AddVertex(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (vertexIndices.ContainsKey(value))
            {
                throw new Exception("The vertex has been already defined.");
            }

            if (usedSize<maxSize/2)
            {
                halfMatrixSize();
            }
            if (nextAvailableIndex==maxSize)
            {
                doubleMatrixSize();
            }

            vertexIndices.Add(value, nextAvailableIndex);
            reverseVertexIndices.Add(nextAvailableIndex, value);
            vertexObjects.Add(value, new GraphVertex<T>(this, value));

            nextAvailableIndex++;
            usedSize++;
        }

        public void AddEdge(T source,T dest)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertexIndices.ContainsKey(source) || !vertexIndices.ContainsKey(dest))
            {
                throw new Exception("Source or Destination vertex does not exist.");
            }
            var sourceIndex = vertexIndices[source];
            var destIndex = vertexIndices[dest];
            if (matrix[sourceIndex].Get(destIndex) && matrix[destIndex].Get(sourceIndex))
            {
                throw new Exception("Edge is already exist.");
            }
            matrix[sourceIndex].Set(destIndex, true);
            matrix[destIndex].Set(sourceIndex, true);
        }

        public void RemoveVertex(T value)
        {
            if (value==null)
            {
                throw new ArgumentNullException();
            }
            if (!vertexIndices.ContainsKey(value))
            {
                throw new Exception("Vertex does not exist");
            }
            if (usedSize<=maxSize/2)
            {
                halfMatrixSize();
            }
            var index = vertexIndices[value];
            for (int i = 0; i < maxSize; i++)
            {
                matrix[i].Set(index, false);
                matrix[index].Set(i, false);
            }
            reverseVertexIndices.Remove(index);
            vertexIndices.Remove(value);
            vertexObjects.Remove(value);
            usedSize--;
        }

        public void RemoveEdge(T source,T dest)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertexIndices.ContainsKey(source) || !vertexIndices.ContainsKey(dest))
            {
                throw new Exception("Source or Destination vertex does not exist.");
            }
            var sourceIndex = vertexIndices[source];
            var destIndex = vertexIndices[dest];
            if (!matrix[sourceIndex].Get(destIndex)|| !matrix[destIndex].Get(sourceIndex))
            {
                throw new Exception("Edge is not exist.");
            }
            matrix[sourceIndex].Set(destIndex, false);
            matrix[destIndex].Set(sourceIndex, false);
        }

        private void halfMatrixSize()
        {
            var newMatrix = new BitArray[maxSize / 2];
            for (int i = 0; i < maxSize / 2; i++)
            {
                newMatrix[i] = new BitArray(maxSize / 2);
            }

            var newVertexIndices = new Dictionary<T, int>();
            var newReverseIndices = new Dictionary<int, T>();

            int k = 0;
            foreach (var vertex in vertexIndices)
            {
                newVertexIndices.Add(vertex.Key, k);
                newReverseIndices.Add(k, vertex.Key);
                k++;
            }

            nextAvailableIndex = k;

            for (int i = 0; i < maxSize; i++)
            {
                for (int j = i; j < maxSize; j++)
                {
                    if (matrix[i].Get(j) && matrix[j].Get(i)
                        && reverseVertexIndices.ContainsKey(i)
                        && reverseVertexIndices.ContainsKey(j))
                    {
                        var newI = newVertexIndices[reverseVertexIndices[i]];
                        var newJ = newVertexIndices[reverseVertexIndices[j]];

                        newMatrix[newI].Set(newJ, true);
                        newMatrix[newJ].Set(newI, true);
                    }
                }
            }

            matrix = newMatrix;
            vertexIndices = newVertexIndices;
            reverseVertexIndices = newReverseIndices;
        }

        private void doubleMatrixSize()
        {
            var newMatrix = new BitArray[maxSize * 2];
            for (int i = 0; i < maxSize * 2; i++)
            {
                newMatrix[i] = new BitArray(maxSize * 2);
            }

            var newVertexIndices = new Dictionary<T, int>();
            var newReverseIndices = new Dictionary<int, T>();

            int k = 0;
            foreach (var vertex in vertexIndices)
            {
                newVertexIndices.Add(vertex.Key, k);
                newReverseIndices.Add(k, vertex.Key);
                k++;
            }

            nextAvailableIndex = k;

            for (int i = 0; i < maxSize; i++)
            {
                for (int j = i; j < maxSize; j++)
                {
                    if (matrix[i].Get(j) && matrix[j].Get(i)
                        && reverseVertexIndices.ContainsKey(i)
                        && reverseVertexIndices.ContainsKey(j))
                    {
                        var newI = newVertexIndices[reverseVertexIndices[i]];
                        var newJ = newVertexIndices[reverseVertexIndices[j]];

                        newMatrix[newI].Set(newJ, true);
                        newMatrix[newJ].Set(newI, true);
                    }
                }
            }

            matrix = newMatrix;
            vertexIndices = newVertexIndices;
            reverseVertexIndices = newReverseIndices;
        }
    }

}
