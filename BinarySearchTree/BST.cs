using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BST<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T> Root;
        public BST() => Root = null;
        public BST(Node<T> node) => Root = node;
        public void Add(T item)
        {
            var newNode = new Node<T>() { Item = item };
            if (Root==null)
                Root = newNode;
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    if (item.CompareTo(current.Item)<0)
                    {
                        current = current.Left;
                        if (current==null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current==null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public static void InOrder(Node<T> root)
        {
            if (!(root==null))
            {
                InOrder(root.Left);
                root.Display();
                InOrder(root.Right);
            }
        }

        public static List<T> InOrderTraversal(Node<T> root)
        {
            List<T> res = new List<T>();
            var s = new Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    s.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (s.Count==0)
                        done = true;
                    else
                    {
                        currentNode = s.Pop();
                        res.Add(currentNode.Item);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return res;
        }

        public static void PreOrder(Node<T> root)
        {
            if (!(root==null))
            {
                root.Display();
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public static List<T> PreOrderTraversal(Node<T> root)
        {
            var result = new List<T>();
            if (root == null)
                return result;
            var stack = new Stack<Node<T>>();
            stack.Push(root);
            while (!(stack.Count==0))
            {
                Node<T> temp = stack.Pop();
                result.Add(temp.Item);
                if (temp.Right!=null)
                    stack.Push(temp.Right);
                if (temp.Left != null)
                    stack.Push(temp.Left);
            }
            return result;

        }

        public static void PostOrder(Node<T> root)
        {
            if (!(root==null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                root.Display();
            }
        }

        public static void LevelOrder(Node<T> root)
        {
            var queue = new Queue<Node<T>>();
            Node<T> temp;
            if (root!=null)
                queue.Enqueue(root);
            while (queue.Count>0)
            {
                temp = queue.Dequeue();
                if (temp.Left != null) 
                    queue.Enqueue(temp.Left);
                if (temp.Right != null) 
                    queue.Enqueue(temp.Right);
                temp.Display();
            }    
        }

        public static List<Node<T>> LevelOrderTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            if (root != null)
            {
                var queue = new Queue<Node<T>>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    Node<T> temp = queue.Dequeue();
                    list.Add(temp);
                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);

                }
            }
            return list;
        }

        public T FindMin()
        {
            Node<T> current = Root;
            while (!(current.Left==null))
                current = current.Left;
            return current.Item;
        }

        public T FindMin(Node<T> root)
        {
            T minValue = root.Item;
            while (root.Left!=null)
            {
                minValue = root.Left.Item;
                root = root.Left;
            }
            return minValue;
        }

        public T FindMax()
        {
            Node<T> current = Root;
            while (!(current.Right==null))
            {
                current = current.Right;
            }
            return current.Item;
        }

        public T FindMax(Node<T> root)
        {
            if(root==null)
                return default(T);
            T max = default(T);
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                var temp = queue.Dequeue();
                if (temp.Item.CompareTo(max)>0)
                    max = temp.Item;
                if (temp.Item!=null)
                {
                    if (temp.Left!=null)
                        queue.Enqueue(temp.Left);
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                }
            }
            return max;

        }

        public Node<T> Find(T key)
        {
            Node<T> current = Root;
            while (current.Item.CompareTo(key)!=0)
            {
                if (key.CompareTo(current.Item)<0)
                    current = current.Left;
                else
                    current = current.Right;
                if (current==null)
                    return null;          
            }
            return current;
        }

        public Node<T> Remove(Node<T> root, T item)
        {
            if (root == null) 
                return root;
            if (item.CompareTo(root.Item)<0)
                root.Left = Remove(root.Left, item);
            else if (item.CompareTo(root.Item)>0)
                root.Right = Remove(root.Right, item);
            else
            {
                if (root.Left==null)
                    return root.Right;
                else if (root.Right==null)
                    return root.Left;
                root.Item = FindMin(root.Right);
                root.Right = Remove(root.Right, root.Item);
            }
            return root;
        }

        public static int MaxDepth(Node<T> root)
        {
            if (root==null)
                return 0;
            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);
            return (leftDepth > rightDepth) ? leftDepth + 1 : rightDepth + 1;
        }

        public Node<T> DeepestNodeInTree(Node<T> root)
        {
            Node<T> temp = null;
            if (root==null)
                return null;
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                temp = queue.Dequeue();
                if (temp.Left!=null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
            return temp;
        }

        public int NumberOfLeavesInBTS(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return 0;
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node<T> temp = queue.Dequeue();
                if (temp.Left==null && temp.Right==null)
                    count++;
                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
            return count;
        }

        public int NumberOfFullNodes(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return count;
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                Node<T> temp = queue.Dequeue();
                if (temp.Left != null && temp.Right != null)
                    count++;
                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
            return count;
        }

        public int NumberOfHalfNodes(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return count;
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node<T> temp = queue.Dequeue();
                if ((temp.Left != null && temp.Right == null)||(temp.Left==null&&temp.Right!=null))
                    count++;
                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
            return count;
        }

        public int WidthOfTree(Node<T> root)
        {
            int max = 0;
            int height = MaxDepth(root);
            for (int k = 0; k <= height; k++)
            {
                int temp = WidthOfTree(root, k);
                if (temp > max)
                    max = temp;
            }
            return max;
        }

        private int WidthOfTree(Node<T> root, int depth)
        {
            if (root==null)
                return 0;
            else
                if (depth == 0)
                    return 1;
                else
                    return WidthOfTree(root.Left, depth - 1) + WidthOfTree(root.Right, depth - 1);
            }

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        public static bool PrintAncestors(Node<T> root, T node)
        {
            if (root == null)
            {
                return false;
            }
            if (root.Item.CompareTo(node) == 0) 
            {
                return true;
            }
            bool left = PrintAncestors(root.Left, node);
            bool right = false;
            if (!left)
            {
                right = PrintAncestors(root.Right, node);
            }
            if (left || right)
            {
                Console.WriteLine($"{root.Item}");
            }
            return left || right;
        }

        public void PrintAncestor(Node<T> root, T node)
        {
            PrintAncestors(root, node);
        }

        private void PrintPaths(Node<T> root,T[] path,int pathLen)
        {
            if (root == null) return;
            path[pathLen] = root.Item;
            pathLen++;
            if (root.Left==null && root.Right==null)
                PrintArray(path, pathLen);
            else
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }
        }

        private void PrintArray(T[] path,int len)
        {
            for (int i = 0; i < len; i++)
                Console.Write($"{path[i]} ");
            Console.WriteLine();
        }

        public static Node<T> MirrorOfBinaryTree(Node<T> root)
        {
            Node<T> temp;
            if (root!=null)
            {
                MirrorOfBinaryTree(root.Left);
                MirrorOfBinaryTree(root.Right);
                temp = root.Left;
                root.Left = root.Right;
                root.Right = temp;
            }
            return root;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerate<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
