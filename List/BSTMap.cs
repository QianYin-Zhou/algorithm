using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class BSTMap<K, V> : Map<K, V> where K : IComparable
    {
        private class Node
        {
            public K key;
            public V value;
            public Node left, right;
            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }
        private Node root;
        private int size;

        public BSTMap()
        {
            root = null;
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

        public void add(K key, V value)
        {
            root = add(root, key, value);
        }

        private Node add(Node node, K key, V value)
        {
            if (node == null)
            {
                size++;
                return new Node(key, value);
            }

            if(key.CompareTo(node.key) < 0)
                node.left = add(node.left, key , value);
            else if (key.CompareTo(node.key) > 0)
                node.right = add(node.right, key, value);
            else
                throw new ArgumentException("argument error! The key exists. ");  //并没有重新赋值

            return node;
        }


        //返回以node为根节点的二分搜索树，key所在的节点
        private Node getNode(Node node, K key)
        {
            if(node == null)
            {
                return null;
            }

            if (key.CompareTo(node.key) == 0)
                return node;
            else if (key.CompareTo(node.key) < 0)
                return getNode(node.left, key);
            else
                return getNode(node.right, key);
        }

        public bool contains(K key)
        {
            return getNode(root, key) != null;
        }

        public V get(K key)
        {
            Node node = getNode(root, key);
            return node == null ? default : node.value;
        }

        private Node minimum(Node node)
        {
            if (node.left == null)
                return node;
            return minimum(node.left);
        }

        private Node removeMin(Node node)
        {
            if (node.left == null)
            {
                Node rightNode = node.right;
                node.right = null;  //断掉node它自己，右孩子接替它
                size--;
                return rightNode;
            }
            node.left = removeMin(node.left);  //断掉node的左孩子，node还是它node
            return node;
        }

        public V remove(K key)
        {
            Node node = getNode(root, key);
            if(node != null)
            {
                root = remove(root, key);
                return node.value;
            }
            return default;
        }

        private Node remove(Node node, K key)
        {
            if (node == null)
            {
                return null;
            }

            if (key.CompareTo(node.key) < 0)
            {
                node.left = remove(node.left, key);
                return node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.right = remove(node.right, key);
                return node;
            }
            else  // e == node.element
            {
                //待删除节点的左孩子为空
                if (node.left == null)
                {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    return rightNode;
                }

                //待删除节点的右孩子为空
                if (node.right == null)
                {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    return leftNode;
                }

                //待删除节点含有左右子树
                //找到比待删节点大的最小节点，即待删节点的右子树的最小节点
                //用这个节点替代待删节点的位置(hibbard deletion)
                Node successor = minimum(node.right);
                successor.right = removeMin(node.right);
                successor.left = node.left;

                node.left = node.right = null;
                return successor;
            }
        }

        public void set(K key, V newValue)
        {
            Node node = getNode(root, key);
            if (node == null)
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
