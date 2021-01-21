using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface Map<K, V>  //即字典
    {
        void add(K key, V value);
        V remove(K key);
        bool contains(K key);
        V get(K key);
        void set(K key, V newValue);
        int getSize();
        bool isEmpty();
    }
}
