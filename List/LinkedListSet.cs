using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedListSet<T> : Set<T>
    {
        private LinkedList<T> list;
        public LinkedListSet()
        {
            list = new LinkedList<T>();
        }

        public void add(T element)
        {
            if (!list.contains(element))
            {
                list.addFirst(element);   //链表头添加复杂度低
            }
        }

        public bool contains(T element)
        {
            return list.contains(element);
        }

        public int getSize()
        {
            return list.getSize();
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }

        public void remove(T element)
        {
            list.removeElement(element);
        }
    }
}
