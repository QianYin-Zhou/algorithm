using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    //优先队列,太简单了吧

    public class PriorityQueue<T>: Queue<T> where T : IComparable
    {
        private MaxHeap<T> maxHeap;
        public PriorityQueue()
        {
            maxHeap = new MaxHeap<T>();
        }

        public T dequeue()
        {
            return maxHeap.extractMax();
        }

        public void enqueue(T element)
        {
            maxHeap.add(element);
        }

        public T getFront()
        {
            return maxHeap.findMax();
        }

        public int getSize()
        {
            return maxHeap.getSize();
        }

        public bool isEmpty()
        {
            return maxHeap.isEmpty();
        }
    }
}
