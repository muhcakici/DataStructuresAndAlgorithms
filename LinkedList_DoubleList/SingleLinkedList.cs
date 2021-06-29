using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_DoubleList
{
    public class SinglyLinkedList<T>
    {
        private int count;

        private Node<T> head;

        public int Count => count;

        public T this[int index]
        {
            get
            {
                return this.GetNodeByIndex(index).Item;
            }
            set
            {
                this.GetNodeByIndex(index).Item = value;
            }
        }

        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentException("index", "Index out of range");
            }

            Node<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        public SinglyLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node<T> prevNode = this.GetNodeByIndex(this.count - 1);
                prevNode.Next = newNode;
            }

            this.count++;
        }

        public void Insert(int index, T value)
        {
            Node<T> tempNode = null;
            tempNode = new Node<T>(value);
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("Index", "Index out of range.");
            }
            else if (index == 0)
            {
                if (this.head == null)
                {
                    this.head = tempNode;
                }
                else
                {
                    tempNode.Next = this.head;
                    this.head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                tempNode.Next = prevNode.Next;
                prevNode.Next = tempNode;
            }

            this.count++;
        }

        public void DisplayItems()
        {
            Node<T> currentNode = head;
            Console.WriteLine();
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Item);
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }

                Node<T> deleteNode = prevNode.Next;
                prevNode.Next = deleteNode.Next;
                deleteNode = null;
            }
            this.count--;
        }
    }
}
