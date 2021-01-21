using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayQueue<T> : Queue<T>
    {
        private Array<T> array;

        public ArrayQueue(int capacity)
        {
            array = new Array<T>(capacity);
        }

        public ArrayQueue()
        {
            array = new Array<T>();
        }

        public bool isEmpty()
        {
            return array.isEmpty();
        }

        public int getSize()   //队列长
        {
            return array.getSize();
        }

        public int getCapacity()  //队列容量
        {
            return array.getCapacity();
        }

        public T dequeue()   //出队
        {
            return array.removeAtFirst();
        }

        public void enqueue(T element)   //入队
        {
            array.addAtLast(element);
        }

        public T getFront()
        {
            return array.getFirst();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Queue: ");
            result.Append("<--  ");
            for (int i = 0; i < array.getSize(); i++)
            {
                result.Append(array.get(i));
                if (i != array.getSize() - 1)
                {
                    result.Append(",");
                }
            }
            result.Append(" --");
            return result.ToString();
        }
    }
}
