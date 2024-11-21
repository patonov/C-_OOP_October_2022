using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class LinkedList
    {
        private class Node
        {
            private object element;
            private Node? next;

            public Node(object element)
            {
                this.Element = element;
                this.Next = null;
            }

            public Node(object element, Node prevNode) 
            { 
                this.Element= element;
                prevNode.Next = this;
                this.Next = null;
            }

            public object Element 
            { 
                get { return this.element; } 
                set { this.element = value; }
            }

            public Node? Next
            { 
                get => this.next;
                set { this.next = value; }
            }
        }

        private Node? head;
        private Node? tail;
        private int count;

        public LinkedList() 
        {
            this.head = null;
            this.tail = null;
            this.count = 0;        
        }
               
        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public void Add(object item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
                this.tail = this.head;
            }
            else
            {
                Node newNode = new Node(item, this.tail);
                this.tail = newNode;
            }
            this.Count++;
        }

        public object Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentException("nema da stane. Trai agein leiter!");
            }

            Node currentNode = this.head;
            int currentIndex = 0;
            Node previousNode = null;

            while (currentIndex < index)
            { 
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }
            
            this.Count--;

            if (this.Count == 0)
            {
                this.head = null;
                this.tail = null;
            }
            else if (previousNode == null)
            {
                this.head = currentNode.Next;
            }
            else
            {
                previousNode.Next = currentNode.Next;
            }
            
            return currentNode.Element;
        }

        public int Remove(object item)
        {
            int currentIndex = 0;
            Node currentNode = this.head;
            Node previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Element.Equals(item))
                { 
                    break;
                }
                
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                this.Count--;

                if (this.Count == 0)
                { 
                    this.head = null;
                    this.tail = null;
                }
                else if (previousNode == null)
                {
                    this.head = currentNode.Next;
                }
                else
                {
                    previousNode.Next = currentNode.Next;
                }
                return currentIndex;
            }
            else 
            {
                return -1;
            }

        }

        public int IndexOf(object item)
        {
            int index = 0;
            Node currentNode = this.head;

            while (currentNode != null) 
            {
                if (currentNode.Element.Equals(item))
                { 
                    return index;
                }
                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(object item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object this[int index]
        {
            get 
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentException("Ebi si maikata");
                }

                Node currentNode = this.head;

                for (int i = 0; i < index; i++) 
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Element;
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentException("Ebi si maikata again and again");
                }

                Node currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Element = value;
            }
        }


    }
}
