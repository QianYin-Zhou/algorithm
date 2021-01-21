using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayStack<T> : Stack<T>  //实现栈接口
    {
        private Array<T> array;

        public ArrayStack(int capacity)
        {
            array = new Array<T>(capacity);
        }

        public ArrayStack()
        {
            array = new Array<T>();
        }

        public bool isEmpty()
        {
            return array.isEmpty();
        }

        public int getSize()
        {
            return array.getSize();
        }


        public int getCapacity()  //栈容量
        {
            return array.getCapacity();
        }

        public void push(T element)  //出栈“后进”
        {
            array.addAtLast(element);
        }

        public T pop()   //出栈“先出”
        {
            return array.removeAtLast();
        }

        public T peek()  //栈顶元素
        {
            return array.getLast();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Stack: ");
            result.Append("【");
            for (int i = 0; i < array.getSize(); i++)
            {
                result.Append(array.get(i));
                if (i != array.getSize()-1)
                {
                    result.Append(",");
                }
            }
            result.Append("】top");
            return result.ToString();
        }

    }
}
