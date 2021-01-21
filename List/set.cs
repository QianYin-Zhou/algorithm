using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface Set<T>
    {
        void add(T element);
        void remove(T element);
        bool contains(T element);
        int getSize();
        bool isEmpty();

    }
}
