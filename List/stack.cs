using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface Stack<T>
    {
        int getSize();  //栈长
        bool isEmpty();  //判断栈是否为空
        void push(T element);  //入栈
        T pop();   //出栈
        T peek();  //读取栈顶元素
    }
}
