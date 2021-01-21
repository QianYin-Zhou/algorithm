using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class AVLMap<K, V> : Map<K, V> where K : IComparable
    {
        private AVLTree<K, V> avl;

        public AVLMap()
        {
            avl = new AVLTree<K, V>();
        }

        public void add(K key, V value)
        {
            avl.add(key, value);
        }

        public bool contains(K key)
        {
            return avl.contains(key);
        }

        public V get(K key)
        {
            return avl.get(key);
        }

        public int getSize()
        {
            return avl.getSize();
        }

        public bool isEmpty()
        {
            return avl.isEmpty();
        }

        public V remove(K key)
        {
            return avl.remove(key);
        }

        public void set(K key, V newValue)
        {
            avl.set(key, newValue);
        }
    }
}
