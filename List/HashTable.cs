using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    // 链地址法
    // 自定义哈希表
    public class HashTable<K, V>
    {
        private readonly int[] Capacity = { 53, 97, 193, 389, 769, 1543,
            3079, 6151, 12289, 24593, 49157, 98317, 196613, 393241, 786433,
            1572869, 3145739, 6291469, 12582917, 25165843, 50331653, 100663319,
            201326611, 402653189, 805306457, 1610612741};
        private const int upperTol = 10;
        private const int lowerTol = 2;
        private int capacityIndex = 0;
        private Dictionary<K, V>[] hashTable;   // 我也不知道Dictionary的底层是不是红黑树写的
        private int M;    // 一个素数
        private int size;

        public HashTable()
        {
            this.M = Capacity[capacityIndex];
            size = 0;
            hashTable = new Dictionary<K, V>[M];
            for (int i = 0; i < M; i++)
            {
                hashTable[i] = new Dictionary<K, V>();
            }
        }


        public int hash(K key)
        {
            return (key.GetHashCode() & 0x7FFFFFFF) % M;
        }

        public int getSize()
        {
            return size;
        }

        public void add(K key, V value)
        {
            if (hashTable[hash(key)].ContainsKey(key))
            {
                hashTable[hash(key)][key] = value;
            }
            else
            {
                hashTable[hash(key)].Add(key, value);
                size++;

                if(size >= upperTol * M && capacityIndex + 1 < Capacity.Length)
                {
                    capacityIndex++;
                    resize(Capacity[capacityIndex]);
                }
            }
        }

        public V remove(K key)
        {
            Dictionary<K, V> dic = hashTable[hash(key)];
            V ret = default(V);
            if (dic.ContainsKey(key))
            {
                ret = dic[key];
                dic.Remove(key);
                size--;

                if (size < lowerTol * M && capacityIndex - 1 >= 0)
                {
                    capacityIndex--;
                    resize(Capacity[capacityIndex]);
                }
            }
            return ret;
        }

        public void set(K key, V value)
        {
            Dictionary<K, V> dic = hashTable[hash(key)];
            if (!dic.ContainsKey(key))
            {
                throw new ArgumentException(key + "doesn,t exist");
            }
            dic[key]= value;
        }

        public bool contains(K key)
        {
            return hashTable[hash(key)].ContainsKey(key);
        }

        public V get(K key)
        {
            return hashTable[hash(key)][key];
        }

        private void resize(int newM)
        {
            Dictionary<K, V>[] newHashTable = new Dictionary<K, V>[newM];
            for (int i = 0; i < newM; i++)
            {
                newHashTable[i] = new Dictionary<K, V>();
            }
            int oldM = M;
            this.M = newM;
            for (int i = 0; i < oldM; i++)
            {
                Dictionary<K, V> dic = hashTable[i];
                foreach(K key in dic.Keys)
                {
                    newHashTable[hash(key)].Add(key, dic[key]);
                }
            }
            this.hashTable = newHashTable;
        }
    }
}

