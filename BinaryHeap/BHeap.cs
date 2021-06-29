﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public abstract class BHeap<T> : IEnumerable<T> where T : IComparable
    {
        protected T[] Array;
        protected int position;

        public BHeap()
        {
            Array = new T[2];
            position = 0;
        }
        public BHeap(int _size)
        {
            Array = new T[_size];
            position = 0;
        }
        public BHeap(IEnumerable<T> collection)
        {
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        protected int GetLeftChildIndex(int i) => 2 * i + 1;
        protected int GetRightChildIndex(int i) => 2 * i + 2;
        protected int GetParentIndex(int i) => (i - 1) / 2;

        protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        protected bool IsRoot(int i) => i == 0;

        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];

        public bool IsEmpty() => position == 0;
        public T Peek()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("The heap is empty.");
            return Array[0];
        }

        public void Swap(int first,int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected abstract void HeapifyUp();
        protected abstract void HeapifyDown();

        public void Add(T item)
        {
            if (position==Array.Length)
                throw new IndexOutOfRangeException("Heap is full.");
            Array[position] = item;
            position++;

            HeapifyUp();
        }

        public T DeleteMinMax()
        {
            if (position == 0)
                throw new IndexOutOfRangeException("The heap is empty.");

            var result = Array[0];
            Array[0] = Array[position - 1];
            position--;
            HeapifyDown();
            return result;
        }

    }
}