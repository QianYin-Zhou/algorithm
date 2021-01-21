using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface UF
    {
        int getSize();
        bool isConnected(int p, int q);
        void unionElements(int p, int q);
        
    }
}
