using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSets
{
    public class DisJointSetNode<T>
    {
        public T Data { get; set; }
        public int Rank { get; set; }
        public DisJointSetNode<T> Parent { get; set; }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
