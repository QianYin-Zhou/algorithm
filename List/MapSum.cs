using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class MapSum
    {
        private class Node
        {
            public int value;
            public Dictionary<char, Node> next;  
            public Node(int value)
            {
                this.value = value;
                this.next = new Dictionary<char, Node>();
            }

            public Node()
            {
                this.value = 0;
                this.next = new Dictionary<char, Node>();
            }
        }
        private Node root;

        public MapSum()
        {
            root = new Node();
        }

        public void insert(string key, int val)
        {
            Node cur = root;
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                if (!cur.next.ContainsKey(c))
                {
                    cur.next.Add(c, new Node());
                }
                cur = cur.next[c];
            }
            cur.value = val;
        }

        public int sum(string prefix)
        {
            Node cur = root;
            for(int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (!cur.next.ContainsKey(c))
                {
                    return 0;
                }
                cur = cur.next[c];
            }
            return sum(cur);
        }

        private int sum(Node node)
        {
            int res = node.value;
            foreach(char c in node.next.Keys)
            {
                res += sum(node.next[c]);
            }
            return res;
        }
    }
}
