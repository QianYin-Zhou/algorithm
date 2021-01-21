using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{

    // 引用平衡因子是因为怕二分搜索树退化成一个链表
    public class AVLTree<K, V> : Map<K, V> where K : IComparable
    {
        private class Node
        {
            public K key;
            public V value;
            public Node left, right;
            public int height;
            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;
                this.height = 1;
            }
        }
        private Node root;
        private int size;

        public AVLTree()
        {
            root = null;
            size = 0;
        }

        public int getSize()
        {
            return size;
        }

        // 计算节点的高度
        private int getHeight(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            return node.height;
        }

        // 计算节点的平衡因子
        private int getBalanceFactor(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            return getHeight(node.left) - getHeight(node.right);
        }

        // 对节点y进行向右旋转操作，返回旋转后新的根节点x
        //            y                               x
        //          /   \                           /   \
        //         x    T4                         z     y
        //        / \        向右旋转(y)         /   \  /  \
        //       z  T3        - - - - - >       T1  T2 T3  T4
        //      / \
        //     T1  T2
        // 
        private Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T3 = x.right;

            // 向右旋转
            x.right = y;
            y.left = T3;

            //更新height
            y.height = 1 + Math.Max(getHeight(y.left), getHeight(y.right));
            x.height = 1 + Math.Max(getHeight(x.left), getHeight(x.right));

            return x;
        }

        private Node leftRotate(Node y)
        {
            Node x = y.right;
            Node T2 = x.left;

            x.left = y;
            y.right = T2;

            y.height = 1 + Math.Max(getHeight(y.left), getHeight(y.right));
            x.height = 1 + Math.Max(getHeight(x.left), getHeight(x.right));

            return x;
        }


        public bool isEmpty()
        {
            return size == 0;
        }

        // 判断是否为二分搜索树
        public bool isBST()
        {
            List<K> keys = new List<K>();
            inOrder(root, keys);
            for(int i = 1; i < keys.Count; i++)
            {
                if(keys[i-1].CompareTo(keys[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void inOrder(Node node, List<K> keys)
        {
            if (node == null) return;
            inOrder(node.left, keys);
            keys.Add(node.key);
            inOrder(node.right, keys);
        }

        // 判断是否为平衡二叉树
        public bool isBalanced()
        {
            return isBalanced(root);
        }

        private bool isBalanced(Node node)
        {
            if (node == null) return true;
            int balaneeFactor = getBalanceFactor(node);
            if(Math.Abs(balaneeFactor) > 1)
            {
                return false;
            }
            return isBalanced(node.left) && isBalanced(node.right);
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

            if (key.CompareTo(node.key) < 0)
                node.left = add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = add(node.right, key, value);
            else
                throw new ArgumentException("argument error! The key exists. "); 

            // 1. 计算高度
            node.height = 1 + Math.Max(getHeight(node.left), getHeight(node.right));

            // 2. 计算平衡因子
            int balanceFactor = getBalanceFactor(node);

            // 3. 维护树的平衡性（左旋转和右旋转）
            if(balanceFactor > 1 && getBalanceFactor(node.left) >= 0) // LL
            {
                return rightRotate(node);
            }
            if(balanceFactor < -1 && getBalanceFactor(node.right) <= 0)  // RR
            {
                return leftRotate(node); 
            }
            if(balanceFactor > 1 && getBalanceFactor(node.left) < 0) //LR
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }
            if(balanceFactor < -1 && getBalanceFactor(node.right) > 0)  // RL
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
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

            Node retNode;   //维护平衡性
            if (key.CompareTo(node.key) < 0)
            {
                node.left = remove(node.left, key);
                retNode = node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.right = remove(node.right, key);
                retNode = node;
            }
            else  // e == node.element
            {
                //待删除节点的左孩子为空
                if (node.left == null)
                {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    retNode = rightNode;
                }

                //待删除节点的右孩子为空
                else if (node.right == null)
                {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    retNode = leftNode;
                }

                // 待删除节点没孩子
                else
                {
                    Node successor = minimum(node.right);
                    successor.right = remove(node.right, successor.key);
                    successor.left = node.left;

                    node.left = node.right = null;
                    retNode = successor;
                }
                
            }

            if (retNode == null) return null; //
            retNode.height = 1 + Math.Max(getHeight(retNode.left), getHeight(retNode.right));
            int balanceFactor = getBalanceFactor(retNode);
            if (balanceFactor > 1 && getBalanceFactor(retNode.left) >= 0)
            {
                return rightRotate(retNode);
            }
            if (balanceFactor < -1 && getBalanceFactor(retNode.right) <= 0) 
            {
                return leftRotate(retNode);
            }
            if (balanceFactor > 1 && getBalanceFactor(retNode.left) < 0) 
            {
                retNode.left = leftRotate(retNode.left);
                return rightRotate(retNode);
            }
            if (balanceFactor < -1 && getBalanceFactor(retNode.right) > 0) 
            {
                retNode.right = rightRotate(retNode.right);
                return leftRotate(retNode);
            }

            return retNode;
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
