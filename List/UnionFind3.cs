using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    // 基于size优化UF2
    public class UnionFind3: UF
    {
        private int[] parent;
        private int[] sz; // sz[i]表示以i为根的集合中元素的个数
        public UnionFind3(int size)
        {
            parent = new int[size];
            sz = new int[size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
                sz[i] = 1;
            }
        }

        public int getSize()
        {
            return parent.Length;
        }

        private int find(int p)
        {
            if (p < 0 && p >= parent.Length)
            {
                throw new IndexOutOfRangeException("p is out of bound");
            }
            while (p != parent[p])
            {
                p = parent[p];
            }
            return p;
        }

        public bool isConnected(int p, int q)
        {
            return find(p) == find(q);
        }

        public void unionElements(int p, int q)
        {
            int pRoot = find(p);
            int qRoot = find(q);
            if (pRoot == qRoot) return;
            if(sz[pRoot] < sz[qRoot])
            {
                parent[pRoot] = qRoot;
                sz[qRoot] += sz[pRoot];
            }
            else
            {
                parent[qRoot] = pRoot;
                sz[pRoot] += sz[qRoot];
            }
        }

    }
}
