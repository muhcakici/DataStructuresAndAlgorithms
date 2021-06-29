using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_DoubleList
{
    public class DbNode<T>
    {
        public T Item { get; set; } // data
        public DbNode<T> Prev { get; set; }
        public DbNode<T> Next { get; set; }
        public DbNode()
        {

        }
        public DbNode(T item)
        {
            Item = item;
        }
    }


}
