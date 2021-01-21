using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    /*在编译语言*/
    public class Array<T>
    {
        private T[] data;
        private int size; //数组元素个数

        //构造函数，传入数组容量capacity构造Array
        public Array(int capacity)
        {
            data = new T[capacity];
            size = 0;
        }

        //无参的构造函数
        public Array()
        {
            data = new T[10];
        }

        //
        public Array(T[] arr)
        {
            data = new T[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                data[i] = arr[i];
            }
            size = arr.Length;
        }

        //获取数组大小
        public int getSize()
        {
            return size;
        }
        //获取数组容量
        public int getCapacity()
        {
            return data.Length;
        }

        //判断数组是否为空
        public bool isEmpty()
        {
            return size == 0;
        }

        //向数组末尾加入元素
        public void addAtLast(T element)
        {
            add(size, element);
        }

        //向数组开头加入元素
        public void addAtFirst(T element)
        {
            add(0, element);
        }

        //在指定位置添加元素
        public void add(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("add failed, Require index >=0&index <=size");
            }
            if (size == data.Length)
            {
                resize(data.Length * 2);//数组扩容
            }
            for (int i = size - 1; i >= index; i--)
            {
                data[i + 1] = data[i];//向右留空
            }
            data[index] = element;
            size++;
        }

        internal void insert<K>(K key) where K : IComparable
        {
            throw new NotImplementedException();
        }

        //删除数组中第一个元素，并返回第一个元素值
        public T removeAtFirst()
        {
            return remove(0);
        }

        //删除数组中第一个元素，并返回第一个元素值
        public T removeAtLast()
        {
            return remove(size - 1);
        }

        //删除数组中的索引为index元素,并返回这个元素
        public T remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("remove failed, index is illegal!");
            }
            T removedElement = data[index];
            for (int i = index + 1; i < size; i++)
            {
                data[i - 1] = data[i];//向左覆盖
            }
            size--;  //这个存在垃圾回收机制

            if (size == data.Length / 4 && data.Length / 2 != 0)
            {
                resize(data.Length / 2); //懒缩容
            }
            return removedElement;
        }

        //删除数组中的索引为index元素,并返回这个元素
        public void removeElement(T element)
        {
            int index = find(element);
            if (index != -1)
                remove(index);
        }

        //修改索引为index的元素
        public void set(int index, T element)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("set failed, index is illegal!");
            }
            data[index] = element;
        }

        //获取索引为index元素的值
        public T get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("get failed, index is illegal!");
            }

            return data[index];
        }

        //获取数组尾元素
        public T getLast()
        {
            return get(size - 1);
        }

        //获取数组头元素
        public T getFirst()
        {
            return get(0);
        }

        //查找数组是否包含element元素
        public bool contains(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        //查找数组element元素的索引
        public int find(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;  //找不到返回-1
        }

        //交换给出两个索引对应的两个元素的位置
        public void swap(int i, int j)
        {
            if (i < 0 || i >= size || j < 0 || j >= size)
            {
                throw new IndexOutOfRangeException("index is illegal.");
            }

            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        private void resize(int newCapacity)   //实现动态数组
        {
            T[] newData = new T[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Array: size= {0}, capacity= {1}\n", size, data.Length));
            result.Append('[');
            for(int i = 0; i < size; i++)
            {
                result.Append(data[i]);
                if(i != size-1)
                {
                    result.Append(", ");
                }
            }
            result.Append(']');
            return result.ToString();
        }

        
    }
}
