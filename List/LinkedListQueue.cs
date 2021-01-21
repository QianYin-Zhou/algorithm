using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedListQueue<T> : Queue<T>
    {
        private class Node
        {
            public T element;
            public Node next; //指针

            public Node(T element, Node next)
            {
                this.element = element;
                this.next = next;
            }
            public Node(T element)
            {
                this.element = element;
                this.next = null;
            }
            public Node()
            {
                this.element = default;
                this.next = null;
            }

            public override string ToString()
            {
                return element.ToString();
            }
        }

        private Node head, tail;
        private int size;

        public LinkedListQueue()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public T dequeue()
        {
            if (isEmpty())
            {
                throw new IndexOutOfRangeException("LinkedListQueue is empty!!! cannot dequeue");
            }
            Node delNode = head;
            head = head.next;
            delNode.next = null;
            if(head == null)
            {
                tail = null;
            }
            size--;
            return delNode.element;
        }

        public void enqueue(T element)
        {
            if(tail == null)  //头也为空
            {
                tail = new Node(element);
                head = tail;
            }
            else
            {
                tail.next = new Node(element);
                tail = tail.next;
            }
            size++;
        }

        public T getFront()
        {
            if (isEmpty())
            {
                throw new IndexOutOfRangeException("LinkedListQueue is empty!!! cannot getFront");
            }
            return head.element;
        }

        public int getSize()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LinkedListQueue: !head! ");
            for (Node cur = head; cur != null; cur = cur.next)  //没有了dummyhead
                result.Append(cur + " ->");
            result.Append("null !tail! ");
            return result.ToString();
        }
    }
}
