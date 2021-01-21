using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class UnionFind5: UF
    {
        private int[] parent;
        private int[] rank; 
        public UnionFind5(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
                rank[i] = 1;
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
                parent[p] = parent[parent[p]];  // 添加路径压缩的过程
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
            if (rank[pRoot] < rank[qRoot])
            {
                parent[pRoot] = qRoot;
            }
            else if (rank[qRoot] < rank[pRoot])
            {
                parent[qRoot] = pRoot;
            }
            else
            {
                parent[qRoot] = pRoot;
                rank[pRoot]++;
            }
        }
    }
}
