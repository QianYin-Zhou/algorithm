using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface Queue<T>
    {
        int getSize();   //获取队的大小 
        bool isEmpty();   //判断队是否为空
        void enqueue(T element);   //入队
        T dequeue();  //出队
        T getFront();  //获取队头元素 
          
    }
}
