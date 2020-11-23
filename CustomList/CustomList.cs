using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T>
    {
        private T[] _array = new T[4];
        private int count;
        private int capacity;

        public int Count { get { return count;  }  }
        public int Capacity { get { return capacity; } }

        public void Add()
        {

        }
    }
}
