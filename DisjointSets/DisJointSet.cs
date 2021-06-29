using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSets
{
    public class DisJointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisJointSetNode<T>> set = new Dictionary<T, DisJointSetNode<T>>();
        public int Count { get; private set; }
        public void MakeSet(T mamber)
        {
            if (set.ContainsKey(mamber))
                throw new Exception("The mamber has already defined.");
            var newSet = new DisJointSetNode<T>() { Data = mamber, Rank = 0, };
            newSet.Parent = newSet;
            set.Add(mamber, newSet);
            Count++;
        }
        public T FindSet(T mamber)
        {
            if (!set.ContainsKey(mamber))
                throw new Exception("Member not found!");
            return FindSet(set[mamber]).Data;
        }
        private DisJointSetNode<T> FindSet(DisJointSetNode<T> node)
        {
            var parent = node.Parent;
            if (node!=parent)
            {
                node.Parent = FindSet(node.Parent);
                return node.Parent;
            }
            return parent;
        }
        public T PathFind(T mamber)
        {
            if (!set.ContainsKey(mamber))
            {
                throw new Exception("Member not found!");
            }
            return PathFind(set[mamber]).Data;
        }
        private DisJointSetNode<T> PathFind(DisJointSetNode<T> node)
        {
            var parent = node.Parent;
            while (node!=parent)
            {
                node = node.Parent;
            }
            return node;
        }
        public void Union(T mamberA, T mamberB)
        {
            var rootA = FindSet(mamberA);
            var rootB = FindSet(mamberB);
            if (rootA.Equals(rootB))
                return;
            var nodeA = set[rootA];
            var nodeB = set[rootB];

            if (nodeA.Rank == nodeB.Rank)
            {
                nodeB.Parent = nodeA;
                nodeA.Rank++;
            }
            else
            {
                if (nodeA.Rank < nodeB.Rank)
                    nodeA.Parent = nodeB;
                else
                    nodeB.Parent = nodeA;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.Values.Select(n => n.Data).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
