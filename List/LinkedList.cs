using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
     public class LinkedList<T>
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

        private Node dummyHead;  //虚拟头结点
        private int size;

        public LinkedList()
        {
            dummyHead = new Node(default, null);  //初始next为null
            size = 0;
        }

        public int getSize()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }


       //在索引Index的位置后插入元素
        public void add(int index,T element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("add failed, Require index >=0&index <=size");
            }
            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }
            Node node = new Node(element);
            node.next = prev.next;
            prev.next = node;
            // prev.next = new Node(element, prev.next);
            size++;
        }

        public void addFirst(T element)  //插入链表头部
        {
            add(0, element);
        }

        public void addLast(T element)
        {
            add(size, element);
        }

        public T get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("get failed, Require index >0&index <size");
            }
            Node cur = dummyHead.next;
            for(int i = 0; i < index; i++)
            {
                cur = cur.next;
            }
            return cur.element;
        }

        public T getFirst()
        {
            return get(0);
        }

        public T getLast()
        {
            return get(size-1);
        }

        public void set(int index, T element)  //更新节点元素
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("set failed, Require index >0&index <size");
            }
            Node cur = dummyHead.next;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }
            cur.element = element;
        }

        public bool contains(T element)
        {
            Node cur = dummyHead.next;
            while(cur != null)
            {
                if (cur.element.Equals(element))
                    return true;
                cur = cur.next;
            }
            return false;
        }

        public T remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("remove failed, Require index >0&index <size");
            }
            Node prev = dummyHead;
            for(int i = 0; i < index; i++)
            {
                prev = prev.next;
            }
            Node delNode = prev.next;
            prev.next = delNode.next;
            delNode.next = null;
            size--;

            return delNode.element;  //返回被删除元素
        }

        //从链表删除元素
        public void removeElement(T element)
        {
            Node prev = dummyHead;
            while(prev.next != null)
            {
                if (prev.next.element.Equals(element))
                    break;
                prev = prev.next;
            }

            if(prev.next != null)
            {
                Node delNode = prev.next;
                prev.next = delNode.next;
                delNode.next = null;
            }
        }

        public T removeFirst()
        {
            return remove(0);
        }

        public T removeLast()
        {
            return remove(size - 1);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for(Node cur = dummyHead.next; cur != null; cur = cur.next)
                result.Append(cur+" ->");
            return result.ToString();
        }
    }
}
