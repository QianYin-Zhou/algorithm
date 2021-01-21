using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedListMap<K, V>: Map<K, V>
    {
        private class Node
        {
            public K key;
            public V value;
            public Node next; //指针

            public Node(K key, V value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
            public Node(K key)
            {
                this.key = key;
                this.value = default;
                this.next = null;
            }
            public Node()
            {
                this.key = default;
                this.value = default;
                this.next = null;
            }

            public override string ToString()
            {
                return key.ToString() + ":"+ value.ToString();
            }

        }

        private Node dummyHead;
        private int size;

        public LinkedListMap()
        {
            dummyHead = new Node();
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

        private Node getNode(K key)
        {
            Node cur = dummyHead.next;
            while(cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return cur;
                }
                cur = cur.next;
            }
            return null;
        }


        public V get(K key)
        {
            Node node = getNode(key);
            return node == null ? default : node.value;
        }

        public bool contains(K key)
        {
            return getNode(key) != null;
        }

        public void add(K key, V value)
        {
            if(!contains(key))
            {
                dummyHead.next = new Node(key, value, dummyHead.next);
                size++;
            }
            else
            {
                throw new ArgumentException("argument error! The key exists. ");  //并没有重新赋值
            }
        }

        public V remove(K key)
        {
            Node prev = dummyHead;
            while(prev.next != null)
            {
                if (prev.next.key.Equals(key))
                    break;
                prev = prev.next;
            }

            if(prev.next != null)
            {
                Node delNode = prev.next;
                prev.next = delNode.next;
                delNode.next = null;
                size--;
                return delNode.value;
            }
            return default;
        }

        public void set(K key, V newValue)
        {
            Node node = getNode(key);
            if(node == null)
            {
                throw new ArgumentException("key doesn't exist!");
            }
            else
            {
                node.value = newValue;
            }
        }
    }
}
