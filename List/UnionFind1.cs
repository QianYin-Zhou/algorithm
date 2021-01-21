using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class UnionFind1: UF
    {
        private int[] id;
        public UnionFind1(int size)
        {
            id = new int[size];
            for(int i = 0; i < id.Length; i++)
            {
                id[i] = i;  //每一个元素表示不同集合
            }
        }

        public int getSize()
        {
            return id.Length;
        }

        // 查找元素p对应的集合编号
        private int find(int p)
        {
            if(p < 0 && p >= id.Length)
            {
                throw new IndexOutOfRangeException("p is out of bound");
            }
            return id[p];
        }

        // 查看p和q是否同一集合
        public bool isConnected(int p, int q)
        {
            return find(p) == find(q);
        }

        // 合并p和q所属集合
        public void unionElements(int p, int q)
        {
            int pID = find(p);
            int qID = find(q);
            if (pID == qID) return;
            for(int i = 0; i < id.Length; i++)
            {
                if(id[i] == pID)
                {
                    id[i] = qID;
                }
            }
        }
    }
}
