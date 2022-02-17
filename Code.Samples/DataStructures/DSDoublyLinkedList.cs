using Code.Samples.Helpers.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures
{
    public class DSDoublyLinkedList : IRunner
    {
        public Node head;
        public Node tail;
        private int length;

        public DSDoublyLinkedList(int value)
        {
            this.head = new Node(value);
            this.tail = this.head;
            this.length = 1;
        }

        public void append(int value)
        {
            Node newNode = new Node(value);
            newNode.Prev = this.tail;
            this.tail.Next = newNode;
            this.tail = newNode;
            this.length++;
        }

        public void prepend(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = this.head;
            this.head.Prev = newNode;
            this.head = newNode;
            this.length++;
        }

        public void insert(int index, int value)
        {
            if(index == 0)
            {
                prepend(value);
                return;
            }

            if(index == length -1)
            {
                append(value);
                return;
            }

            Node newNode = new Node(value);

            Node leader = traverseToIndex(index - 1);
            Node follower = leader.Next;

            leader.Next = newNode;
            newNode.Prev = leader;
            newNode.Next = follower;
            follower.Prev = newNode;

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
            nodeToRemove.Next.Prev = leader;
            this.length--;
        }

        public void printList()
        {
            if(this.head == null)
            {
                return;
            }
            Node current = this.head;
            while(current != null)
            {
                Console.WriteLine("--->" + current.Value);
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
            this.append(7);
            this.append(16);
            this.prepend(5);
            this.insert(1, 99);
            this.remove(1);

            this.printList();
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
