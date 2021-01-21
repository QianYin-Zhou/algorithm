using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Trie
    {
        private class Node
        {
            public bool isWord;
            public Dictionary<char, Node> next;  //26个字母
            public Node(bool isWord)
            {
                this.isWord = isWord;
                this.next = new Dictionary<char, Node>();
            }

            public Node()
            {
                this.next = new Dictionary<char, Node>();
                this.isWord = false;
            }
        }
        private Node root;
        private int size;

        public Trie()
        {
            root = new Node();
            size = 0;
        }

        // 获得Trie中存储的单词数量
        public int getSize()
        {
            return size;
        }

        // 像trie添加一个新的单词word
        public void add(string word)
        {
            Node cur = root;
            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if(!cur.next.ContainsKey(c))
                {
                    cur.next.Add(c, new Node());
                }
                cur = cur.next[c];
            }
            if (!cur.isWord)
            {
                cur.isWord = true;
                size++;
            }
        }

        // 查看单词word是否在trie中
        public bool contains(string word)
        {
            Node cur = root;
            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!cur.next.ContainsKey(c))
                {
                    return false;
                }
                cur = cur.next[c];
            }
            return cur.isWord;
        }

        // 查询是否在trie中有单词prefix为前缀
        public bool isPrefix(string prefix)
        {
            Node cur = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (!cur.next.ContainsKey(c))
                {
                    return false;
                }
                cur = cur.next[c];
            }
            return true;
        }

    }
}
