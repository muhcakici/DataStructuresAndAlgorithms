using System;

namespace LinkedList_DoubleList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();

            singlyLinkedList.Add(6);
            singlyLinkedList.Add(23);
            singlyLinkedList.Add(35);
            singlyLinkedList.Add(44);
            singlyLinkedList.Add(55);

            singlyLinkedList.Insert(4, 55);
            singlyLinkedList.DisplayItems();

            //DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

            //doublyLinkedList.AddAfter(1);
            //doublyLinkedList.AddAfter(2);
            //doublyLinkedList.AddAfter(3);
            //doublyLinkedList.AddAfter(5);


            Console.ReadLine();
        }
    }
}
