using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    // 红节点代表融合的意思（2-3树）
    // 不实现删除操作
    public class RBTree<K, V> : Map<K, V> where K : IComparable
    {
        private const bool RED = true;
        private const bool BLACK = false;
        private class Node
        {
            public K key;
            public V value;
            public Node left, right;
            public bool color;
            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;
                this.color = RED;   // 新节点默认红色
            }
        }
        private Node root;
        private int size;

        public RBTree()
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

        // 判断节点是否为红节点
        private bool isRed(Node node)
        {
            if(node == null)
            {
                return BLACK;
            }
            return node.color;
        }

        // 红黑树的左旋转,返回新根
        //     node                       x
        //    /   \                     /   \ 
        //   T1    x   - - - - >      node  T3
        //        / \                /  \
        //       T2  T3            T1   T2
        private Node leftRotate(Node node)
        {
            Node x = node.right;

            node.right = x.left;
            x.left = node;
            x.color = node.color;
            node.color = RED;  
            return x;
        }

        // 颜色翻转
        private void flipColors(Node node)
        {
            node.color = RED;
            node.left.color = BLACK;
            node.right.color = BLACK;
        }

        // 红黑树右旋转
        private Node rightRotate(Node node)
        {
            Node x = node.left;

            node.left = x.right;
            x.right = node;
            x.color = node.color;
            node.color = RED;
            return x;
        }

        // 向红黑树中插入新的元素
        public void add(K key, V value)
        {
            root = add(root, key, value);
            root.color = BLACK;
        }

        private Node add(Node node, K key, V value)
        {
            if (node == null)
            {
                size++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) < 0)
                node.left = add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = add(node.right, key, value);
            else
                throw new ArgumentException("argument error! The key exists. ");  

            if(isRed(node.right) && !isRed(node.left))
            {
                node = leftRotate(node);
            }
            if(isRed(node.left) && isRed(node.left.left))
            {
                node = rightRotate(node);
            }
            if(isRed(node.left) && isRed(node.right))
            {
                flipColors(node);
            }

            return node;
        }


        private Node getNode(Node node, K key)
        {
            if (node == null)
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
                node.right = null; 
                size--;
                return rightNode;
            }
            node.left = removeMin(node.left);  
            return node;
        }

        public V remove(K key)
        {
            Node node = getNode(root, key);
            if (node != null)
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
                
                if (node.left == null)
                {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    return rightNode;
                }

                if (node.right == null)
                {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    return leftNode;
                }

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
