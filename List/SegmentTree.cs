using List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 线段树
// 声明委托
public delegate T Merger<T>(T a, T b);

namespace List
{
    public class SegmentTree<T> 
    {
        private T[] tree;
        private T[] data;
        private Merger<T> merger;

        public SegmentTree(T[] arr, Merger<T> merger)
        {
            this.merger = merger;
            data = new T[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                data[i] = arr[i];
            }
            tree = new T[4 * arr.Length];  //开4n空间
            buildSegmentTree(0, 0, data.Length - 1);
        }
        
        // 表示在treeIndex位置创建一个[l, r]区间的线段树
        private void buildSegmentTree(int treeIndex, int l, int r)
        {
            if(l == r)
            {
                tree[treeIndex] = data[l];
                return;
            }
            int leftTreeIndex = leftChild(treeIndex);
            int rightTreeIndex = rightChild(treeIndex);
            int mid = l + (r - l) / 2;
            buildSegmentTree(leftTreeIndex, l, mid);
            buildSegmentTree(leftTreeIndex, mid + 1, r);
            tree[treeIndex] = merger(tree[leftTreeIndex],tree[rightTreeIndex]);
        }


        public int getSize()
        {
            return data.Length;
        }

        public T get(int index)
        {
            if (index < 0 || index >= data.Length)
            {
                throw new IndexOutOfRangeException("get failed, Require index >=0&&index < data.Length");
            }
            return data[index];
        }

        private int leftChild(int index)
        {
            return 2 * index + 1;
        }

        private int rightChild(int index)
        {
            return 2 * index + 2;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append('[');
            for(int i = 0; i < tree.Length; i++)
            {
                if(tree[i] != null)
                {
                    res.Append(tree[i]);
                }
                else
                {
                    res.Append("null");
                }
                if(i != tree.Length-1)
                {
                    res.Append(",");
                }
            }
            res.Append("]");
            return res.ToString();
        }
    }
}
