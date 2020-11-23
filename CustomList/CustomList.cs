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

        public int Count { get { return count;  }  }

        private int capacity;
        public int Capacity { get { return capacity; } }

        public CustomList()
        {
            this.count = 0;
            this.capacity = 4;
        }
        public T this[int i]
        {
            get { return _array[i]; }
            set { _array[i] = value; }
        }


        public void Add(T item)
        {
            CheckCapacity("Add");
            T[] oldArray = _array;
            CreateNewArray(oldArray);
            _array[Count] = item;
            count++;
        }

        private void CreateNewArray(T[] oldArray)
        {
            _array = new T[Capacity];
            for (int i = 0; i < Count; i++)
            {
                _array[i] = oldArray[i];
            }
        }

        private void CheckCapacity(string action)
        {
            if (Count == Capacity && action == "Add")
            {
                capacity = count * 2;
            }
        }
    }

    
}
