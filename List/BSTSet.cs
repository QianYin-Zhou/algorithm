using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class BSTSet<T> : Set<T> where T : IComparable
    {
        private BST<T> bst;
        public BSTSet()
        {
            bst = new BST<T>();
        } 
        
        public void add(T element)  //原本就是不处理相同元素
        {
            bst.add(element);
        }

        public bool contains(T element)
        {
            return bst.contains(element);
        }

        public int getSize()
        {
            return bst.getSize();
        }

        public bool isEmpty()
        {
            return bst.isEmpty();
        }

        public void remove(T element)
        {
            bst.remove(element);
        }
    }
}
