using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    // 两层，递归时间会慢
    public class UnionFind6: UF
    {
        private int[] parent;
        private int[] rank;
        public UnionFind6(int size)
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
            if (p != parent[p])
            {
                parent[p] = find(parent[p]);  //直接变两层
            }
            return parent[p];
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
