using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedListStack<T> : Stack<T>
    {
        private LinkedList<T> list;
        public LinkedListStack()
        {
            list = new LinkedList<T>();
        }

        public int getSize()
        {
            return list.getSize();
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }


        public T peek()
        {
            return list.getFirst();
        }

        public T pop()
        {
            return list.removeFirst();
        }

        public void push(T element)
        {
            list.addFirst(element);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LinkedListStack:  !top! ");
            result.Append(list);
            return result.ToString();
        }
    }
}
