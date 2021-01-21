using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LoopQueue<T>: Queue<T>
    {
        private T[] data;
        private int front, tail;
        private int size;

        public LoopQueue(int capacity)
        {
            data = new T[capacity + 1]; //为了实现判空条件，浪费一个空间
            //队列为空front == tail
            front = 0;  //指向队头
            tail = 0;   //指向队尾的后一个位置 
            size = 0;
        }

        public LoopQueue()
        {
            data = new T[10];
        }

        public int getCapacity()
        {
            return data.Length - 1;
        }

        public int getSize()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public T dequeue()
        {
            if (isEmpty())
            {
                throw new IndexOutOfRangeException("cannot dequeue from an empty queue.");
            }
            T ret = data[front];
            front = (front+1) % data.Length;
            size--;
            if (size == getCapacity() / 4 && getCapacity() / 2 != 0)
                resize(getCapacity() / 2);
            return ret;
        }

        public void enqueue(T element)  //入队
        {
            if((tail+1)%data.Length == front)   //判断相对的队满
            {
                resize(getCapacity() * 2);
            }
            data[tail] = element;
            tail = (tail+1) % data.Length;
            size++;
        }

       
        public T getFront()
        {
            if (isEmpty())
            {
                throw new IndexOutOfRangeException("dequeue is empty.");
            }
            return data[front];
        }

        private void resize(int newCapacity)   //实现动态数组
        {
            T[] newData = new T[newCapacity + 1];
            for (int i = 0; i < size; i++)   //循环队列遍历1
            {
                newData[i] = data[(i+front)%data.Length];  //重新排好
            }
            data = newData;
            front = 0;
            tail = size;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LoopQueue: <-- ");
            for (int i = front; i != tail; i = (i+1) % data.Length) //循环队列遍历2
            {
                result.Append(data[i]);
                if ((i+1)%data.Length != tail)
                {
                    result.Append(",");
                }
            }
            result.Append(" -->");
            return result.ToString();
        }
    }
}
