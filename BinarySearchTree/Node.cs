using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node<T>
    {
        public T Item;
        public Node<T> Left;
        public Node<T> Right;
        public Node()
        {

        }
        public void Display() => Console.Write($"{Item}  ");
    }
}
