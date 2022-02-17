using Code.Samples.Helpers.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures.Samples
{
    public class DSSinglyLinkedList : IRunner
    {
        private Node head;
        private Node tail;
        private int length;

        public DSSinglyLinkedList(int value)
        {
            this.head = new Node(value);
            this.tail = this.head;
            this.length = 1;
        }

        public void append(int value)
        {
            var newNode = new Node(value);
            this.tail.Next = newNode;
            this.tail = newNode;
            this.length++;
        }

        public void prepend(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = this.head;
            this.head = newNode;
            this.length++;
        }

        public void insert(int index, int value)
        {
            index = wrapIndex(index);
            if(index == 0)
            {
                prepend(value);
            }

            if(index == length -1)
            {
                append(value);
                return;
            }

            Node newNode = new Node(value);

            Node leader = traverseToIndex(index - 1);
            Node holdingPointer = leader.Next;

            leader.Next = newNode;
            newNode.Next = holdingPointer;
            this.length++;
        }

        public void remove(int index)
        {
            index = wrapIndex(index);
            if(index == 0)
            {
                head = head.Next;
                return;
            }

            Node leader = traverseToIndex(index - 1);
            Node nodeToRemove = leader.Next;
            leader.Next = nodeToRemove.Next;
            this.length--;
        }

        public void reverse()
        {
            Node first = head;
            tail = head;
            Node second = first.Next;

            for(int i = 0; i < length-1; i++)
            {
                Node temp = second.Next;
                second.Next = first;
                first = second;
                second = temp;
            }

            head.Next = null;
            head = first;
        }

        public void printList()
        {
            if (this.head == null)
            {
                return;
            }
            Node current = this.head;
            while (current != null)
            {
                Console.WriteLine("-->" + current.Value);
                current = current.Next;
            }

            Console.WriteLine();
        }

        public int getLength()
        {
            return this.length;
        }

        public Node getHead()
        {
            return this.head;
        }

        public Node getTail()
        {
            return this.tail;
        }

        public int wrapIndex(int index)
        {
            return Math.Max(Math.Min(index, this.length - 1), 0);
        }

        public Node traverseToIndex(int index)
        {
            int counter = 0;
            index = wrapIndex(index);
            Node currentNode = head;
            while(counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }
            return currentNode;
        }

        public void Run()
        {
            this.append(5);
            this.append(6);
            this.prepend(1);
            this.insert(2, 99);
            this.insert(20, 7);
            this.remove(2);
            this.reverse();
            this.printList();
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
}
