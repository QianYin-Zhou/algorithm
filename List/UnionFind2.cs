using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    // 森林结构
    public class UnionFind2 : UF
    {

        private int[] parent;
        public UnionFind2(int size)
        {
            parent = new int[size];
            for(int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
        }

        public int getSize()
        {
            return parent.Length;
        }

        // 与QF1差别的在这
        private int find(int p)
        {
            if (p < 0 && p >= parent.Length)
            {
                throw new IndexOutOfRangeException("p is out of bound");
            }
            while(p != parent[p])
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
            parent[pRoot] = qRoot;
        }
    }
}
