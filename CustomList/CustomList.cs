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

        public int Count { get { return count; } }

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
            CheckCapacity("Add", 1);
            T[] oldArray = _array;
            CreateNewArray(oldArray, Count);
            _array[Count] = item;
            count++;
        }

        public bool Remove()
        {
            if (this.Count < 1) {
                return false;
            }
            CheckCapacity("Remove", 1);
            T[] oldArray = _array;
            CreateNewArray(oldArray, (Count - 1));
            count--;
            return true;
        }

        public bool Remove(T item)
        {
            int occurrences = CheckItemPresence(item);
            if (occurrences > 0)
            {
                CheckCapacity("Remove", occurrences);
                T[] oldArray = _array;
                CreateNewArray(oldArray, (Count - occurrences), item);
                count -= occurrences;
                return true;
            }
            return false;
        }

        private int CheckItemPresence(T item)
        {
            int occurrences = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (item.ToString() == this[i].ToString())
                {
                    occurrences++;
                }
            }
            return occurrences;
        }

        private void CreateNewArray(T[] oldArray, int limit)
        {
            _array = new T[Capacity];
            for (int i = 0; i < limit; i++)
            {
                _array[i] = oldArray[i];
            }
        }

        private void CreateNewArray(T[] oldArray, int limit, T removal)
        {
            _array = new T[Capacity];
            int counter = 0;
            for (int i = 0; i < limit; i++)
            {
                while (oldArray[counter].ToString() == removal.ToString())
                {
                    counter++;
                }
                _array[i] = oldArray[counter];
                counter++;
            }
        }

        private void CheckCapacity(string action, int prospectiveRemoval)
        {
            if (Count == Capacity && action == "Add")
            {
                capacity = count * 2;
            }
            if (Capacity > 4 && (Count - prospectiveRemoval) * 2 <= Capacity && action == "Remove")
            {
                capacity = Math.Max((int)(Count - prospectiveRemoval), 4);
            }
        }



        public override string ToString()
        {
            string segmentalString = "";
            for (int i = 0; i < this.Count; i++)
            {
                segmentalString += Convert.ToString(this[i]);
            }
            return segmentalString;
        }


        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> summedList = new CustomList<T> { };
            summedList = listOne;
            for (int i = 0; i < listTwo.Count; i++)
            {
                summedList.Add(listTwo[i]);
            }
            return summedList;
        }

        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> itemsToRemove = new CustomList<T> { };
            for(int i = 0; i < listOne.Count; i++)
            { 
                for (int j = 0; j < listTwo.Count; j++)
                {
                    if (listOne[i].ToString() == listTwo[j].ToString() && itemsToRemove.CheckItemPresence(listTwo[j]) < 1 )
                    {
                        itemsToRemove.Add(listTwo[j]);
                    }
                }  
            }

            for(int i = 0; i < itemsToRemove.Count; i++)
            {
                listOne.Remove(itemsToRemove[i]);
            }
            return listOne;
        }
    }

    
}
