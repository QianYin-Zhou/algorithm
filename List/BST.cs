using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class BST<T> where T: IComparable   //泛型参数的上限，此类型参数必须实现iComparable接口。
    {
        private class Node
        {
            public T element;
            public Node left, right;
            public Node(T element)
            {
                this.element = element;
                this.left = null;
                this.right = null;
            }
        }
        private Node root;
        private int size;
        
        public BST()
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
        
        //向二分搜索树添加新的元素
        public void add(T element)
        {
            root = add(root, element);
        }

        //以node为根节点的二分搜索树添加元素element(递归算法)
        private Node add(Node node, T element)
        {
            if(node == null)
            {
                size++;
                return new Node(element);
            }

            if (element.CompareTo(node.element) < 0)
                node.left = add(node.left, element);
            else if(element.CompareTo(node.element) > 0)
                node.right = add(node.right, element);

            return node;
        }

        public bool contains(T element)
        {
            return contains(root, element);
        }

        private bool contains(Node node, T element)
        {
            if(node == null)
            {
                return false;
            }

            if(element.CompareTo(node.element) == 0)
            {
                return true;
            }
            else if(element.CompareTo(node.element) < 0)
            {
                return contains(node.left, element);
            }
            else
            {
                return contains(node.right, element);
            }
        }

        //二分搜索树的前序遍历
        public void preOrder()
        {
            preOrder(root);
        }

        private void preOrder(Node node)
        {
            if(node == null)
            {
                return;
            }
            Console.WriteLine(node.element);
            preOrder(node.left);
            preOrder(node.right);
        }

        //二分搜索树的前序遍历(非递归实现)
        public void preOrderNR()
        {
            //我随便用个栈好了，反正差不多
            LinkedListStack<Node> stack = new LinkedListStack<Node>();
            stack.push(root);
            while (!stack.isEmpty())
            {
                Node cur = stack.pop();
                Console.WriteLine(cur.element);
                if (cur.right != null)
                    stack.push(cur.right);
                if (cur.left != null)
                    stack.push(cur.left);
            }

        }

        //二分搜索树的中序遍历，其实就是排序
        public void inOrder()
        {
            inOrder(root);
        }

        private void inOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            inOrder(node.left);
            Console.WriteLine(node.element);
            inOrder(node.right);
        }


        //二分搜索树的后序遍历,(释放内存)
        public void postOrder()
        {
            postOrder(root);
        }
        private void postOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            postOrder(node.left);
            postOrder(node.right);
            Console.WriteLine(node.element);
        }

        //二分搜索树的层序遍历（广度优先）,用于搜索
        public void levelOrder()
        {
            LinkedListQueue<Node> queue = new LinkedListQueue<Node>();
            queue.enqueue(root);
            while (!queue.isEmpty())
            {
                Node cur = queue.dequeue();
                Console.WriteLine(cur.element);
                if (cur.left != null)
                    queue.enqueue(cur.left);
                if (cur.right != null)
                    queue.enqueue(cur.right);
            }
        }

        //寻找二分搜索树的最小值,最大值我就不写了
        public T minimum()
        {
            if(size == 0)
            {
                throw new IndexOutOfRangeException("BST is empty!");
            }
            return minimum(root).element;
        }

        private Node minimum(Node node)
        {
            if (node.left == null)
                return node;
            return minimum(node.left);
        }

        //寻找二分搜索树的最小值(非递归实现)
        public T minimumNR()
        {

            if (size == 0)
            {
                throw new IndexOutOfRangeException("BST is empty!");
            }
            Node cur = root;
            while(cur.left != null)
            {
                cur = cur.left;
            }
            return cur.element;
        }

        //删除最小值所在节点
        public T removeMin()
        {
            T ret = minimum();
            root = removeMin(root);
            return ret;
        }

        //删除以node为根节点的二分搜索树中的最小孩子
        //返回删除节点后新的二分搜索树的根
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

        public void remove(T element)
        {
            remove(root, element);
        }

        private Node remove(Node node, T element)
        {
            if(node == null)
            {
                return null;
            }

            if(element.CompareTo(node.element) < 0)
            {
                node.left = remove(node.left, element);
                return node;
            }
            else if (element.CompareTo(node.element) > 0)
            {
                node.right = remove(node.right, element);
                return node;
            }
            else  // e == node.element
            {
                //待删除节点的左孩子为空
                if(node.left == null)
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
        

        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
