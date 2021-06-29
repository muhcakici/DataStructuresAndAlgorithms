using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_DoubleList
{
    public class DoublyLinkedList<T>
    {
        private int count;
        private DbNode<T> head;
        public int Count => this.count;
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
        private DbNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "Index of out range");
            }

            DbNode<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }
        public DoublyLinkedList()
        {
            this.count = 0;
            this.head = null;
        }
        public void AddAfter(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (this.head==null)
            {
                this.head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            count++;
        }
        public void AddBefore(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
                DbNode<T> prevNode = lastNode.Prev;
                
                prevNode.Next = newNode;
                newNode.Prev = prevNode;

                lastNode.Prev = newNode;
                newNode.Next = lastNode;
            }
            this.count++;
        }
        public void InsertAfter(int index, T value)
        {
            DbNode<T> tempNode;
            if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new DbNode<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new DbNode<T>(value);
                    tempNode.Next = this.head;
                    this.head.Prev = tempNode;
                    this.head = tempNode;
                }
            }
            else
            {
                DbNode<T> prevNode = this.GetNodeByIndex(index); 
                DbNode<T> nextNode = prevNode.Next; 
                tempNode = new DbNode<T>(value); 

                prevNode.Next = tempNode;
                tempNode.Prev = prevNode;

                if (nextNode != null)
                {
                    tempNode.Next = nextNode;
                    nextNode.Prev = tempNode;
                }
            }
            this.count++;
        }
        public void InsertBefore(int index, T value)
        {
            DbNode<T> tempNode;
            if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new DbNode<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new DbNode<T>(value);
                    tempNode.Next = this.head;
                    this.head.Prev = tempNode;
                    this.head = tempNode;
                }
            }
            else
            {
                DbNode<T> nextNode = this.GetNodeByIndex(index); 
                DbNode<T> prevNode = nextNode.Prev;  
                tempNode = new DbNode<T>(value);
                
                prevNode.Next = tempNode;
                tempNode.Prev = prevNode;

                tempNode.Next = nextNode;
                nextNode.Prev = tempNode;
            }
            this.count++;
        }
        public void DisplayItems()
        {
            Console.WriteLine();
            var currentNode = this.head;
            while (currentNode!=null)
            {
                Console.WriteLine(currentNode.Item);
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }
        public void RemoveAt(int index)
        {
            if (index==0)
            {
                this.head = this.head.Next;
            }
            else
            {
                DbNode<T> prevNode = this.GetNodeByIndex(index - 1);
                if (prevNode.Next==null)
                {
                    throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }
                DbNode<T> deleteNode = prevNode.Next;
                DbNode<T> nextNode = deleteNode.Next;
                prevNode.Next = nextNode;
                if (nextNode!=null)
                {
                    nextNode.Prev = prevNode;
                }
                deleteNode = null;
            }
            this.count--;
        }
    }
}
