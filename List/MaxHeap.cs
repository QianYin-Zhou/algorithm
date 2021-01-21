using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class MaxHeap<T> where T : IComparable
    {
        private Array<T> data;

        public MaxHeap(int capacity)
        {
            data = new Array<T>(capacity);
        }

        public MaxHeap()
        {
            data = new Array<T>();
        }

        //将任意数组整理成堆的形状(heapify)
        //思路：抛弃叶子节点，后向前下沉（On）
        //空堆添加（nLogn）
        public MaxHeap(T[] arr)
        {
            data = new Array<T>(arr);
            for(int i = parent(arr.Length - 1); i >= 0; i--)
            {
                siftDown(i);
            }
        }

        public int getSize()
        {
            return data.getSize();
        }

        public bool isEmpty()
        {
            return data.isEmpty();
        }

        //返回完全二叉树的数组表示中，一个索引所表示的元素的父亲节点的索引（套公式）
        private int parent(int index)
        {
            if(index == 0)
            {
                throw new ArgumentException("index = 0, have no parent");  
            }
            return (index - 1) / 2;
        }

        //返回完全二叉树的数组表示中，一个索引所表示的元素的左孩子节点的索引
        private int leftChild(int index){
            return 2 * index + 1;
        }

        //返回完全二叉树的数组表示中，一个索引所表示的元素的右孩子节点的索引
        private int rightChild(int index)
        {
            return 2 * index + 2;
        }

        public void add(T element)
        {
            data.addAtLast(element);
            siftUp(data.getSize() - 1);
        }

        private void siftUp(int k)
        {
            while(k > 0 && data.get(parent(k)).CompareTo(data.get(k)) < 0)
            {
                data.swap(k, parent(k));
                k = parent(k);
            }
        }

        //查看堆顶元素
        public T findMax()
        {
            if (data.getSize() == 0)
            {
                throw new ArgumentException("cannot find the max when heap is empty.");
            }
            return data.get(0);
        }

        //下沉,取出堆中最大元素,并重新堆
        public T extractMax()
        {
            T ret = findMax();
            int lastIndex = data.getSize() - 1;
            data.swap(0, lastIndex);
            data.removeAtLast();
            siftDown(0);
            return ret;
        }

        private void siftDown(int k)
        {
            while(leftChild(k) < data.getSize())
            {
                int j = leftChild(k);
                if(j + 1 < data.getSize() && data.get(j+1).CompareTo(data.get(j)) > 0)
                {
                    j = rightChild(k);
                    // data[j]是 leftChild 和 rightChild 的最大值
                }
                if(data.get(k).CompareTo(data.get(j)) >= 0)
                {
                    break;
                }
                data.swap(k, j);
                k = j;  //循环继续
            }
        }

        //取出堆中最大元素替换成新的元素
        public T replace(T newElement)
        {
            T ret = findMax();
            data.set(0, newElement);
            siftDown(0);
            return ret;
        }

    }
}
