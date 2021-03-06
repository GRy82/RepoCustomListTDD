﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable
    {

        List<Person> person = new List<Person>();
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

         //-----------PUBLIC METHODS-----------//
        //------------------------------------//

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        public void Add(T item)
        {
            UpdateCapacity("Add", 1);
            CreateNewArray(Count);
            _array[Count] = item;
            count++;
        }

        public bool Remove()
        {
            if (this.Count < 1) {
                return false;
            }
            UpdateCapacity("Remove", 1);
            CreateNewArray(Count - 1);
            count--;
            return true;
        }
     
        public bool Remove(T item)
        {
            int occurrences = GetItemFrequency(item);
            if (occurrences == 0) {
                return false;
            }
            UpdateCapacity("Remove", occurrences);
            CreateNewArray((Count - occurrences), item);
            count -= occurrences;
            return true;
        }

        public override string ToString()
        {
            string segmentalString = "";
            for (int i = 0; i < Count; i++)
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
            for (int i = 0; i < listOne.Count; i++)
            {
                for (int j = 0; j < listTwo.Count; j++)
                {
                    if (listOne[i].ToString() == listTwo[j].ToString() && itemsToRemove.GetItemFrequency(listTwo[j]) < 1)
                    {
                        itemsToRemove.Add(listTwo[j]);
                    }
                }
            }
            for (int i = 0; i < itemsToRemove.Count; i++)
            {
                listOne.Remove(itemsToRemove[i]);
            }
            return listOne;
        }

        public CustomList<T> Zipper(CustomList<T> otherList)
        {
            if (otherList.Count == 0 && this.Count != 0)
            {
                return this;
            }
            else if (otherList.Count != 0 && this.Count == 0)
            {
                return otherList;
            }
            else
            {
                CustomList<T> zippedList = new CustomList<T>();
                int smallerCount = this.Count;   //Default assignments.
                int largerCount = otherList.Count;
                CustomList<T> largerList = otherList;
                if (this.Count > otherList.Count)
                { //Flip the assignments, if statement is true.
                    smallerCount = otherList.Count;
                    largerCount = this.Count;
                    largerList = this;
                }
                for (int i = 0; i < smallerCount; i++)
                { //Zip together matching indeces.
                    zippedList.Add(this[i]);
                    zippedList.Add(otherList[i]);
                }
                for (int i = smallerCount; i < largerCount; i++)
                { //Zip together matching indeces.
                    zippedList.Add(largerList[i]);
                }
                return zippedList;
            }
        }


        public void Sort()
        {
            bool isEligibleToSort = this._array is int[] || this._array is char[] ||
                this._array is double[] || this._array is float[] || this._array is string[];
            if (isEligibleToSort) {
                IterateMarker(0, Count);
            }
            return;
        }

        public void Sort(int startIndex, int Length)
        {
            bool isEligibleToSort = this._array is int[] || this._array is char[] ||
                this._array is double[] || this._array is float[] || this._array is string[];
            if (isEligibleToSort)
            {
                IterateMarker(startIndex, Length);
            }
            return;
        }

         //-------------------------------------------------------------------------//
        //-----------------------Sort Support Methods------------------------------//

        void IterateMarker(int startIndex, int Length)
        {
            int lastIndex = startIndex + Length - 1;
            int marker = startIndex + 1;
            //is value M at marker less than the value to left of it? If so, insert and shift, then increment. If not, only increment.
            while (marker <= lastIndex)
            {
                //Element at index marker is out of order. Initiate shift.
                if (MakeComparison(_array[marker], _array[marker-1]))
                {
                    InsertAndShift(startIndex, marker);
                    marker++;
                }
                else
                { //element at index marker is in order; move marker to right to check next index.
                    marker++;
                }
            }
        }


        bool MakeComparison(T elementOne, T elementTwo)
        {
            if (elementOne is char){
                int asciiElementOne = Convert.ToInt32(elementOne);
                int asciiElementTwo = Convert.ToInt32(elementTwo);
                if (asciiElementOne <= 90) {
                    asciiElementOne += 32;
                }
                if (asciiElementTwo <= 90) {
                    asciiElementTwo += 32;
                }
                if (asciiElementOne < asciiElementTwo) {
                    return true;
                }
            }
            else if (!(elementOne is string)){//if float, double or int.
                if (Convert.ToDouble(elementOne) < Convert.ToDouble(elementTwo))
                {
                    return true;
                }
            }
            else if (elementOne is string)
            {
                string stringElementOne = elementOne.ToString();
                string stringElementTwo = elementTwo.ToString();
                if (stringElementOne.CompareTo(stringElementTwo) < 0)
                {
                    return true;
                }
            }
            return false;
        }


        void InsertAndShift(int searchIndex, int marker)
        {
            while (MakeComparison(_array[searchIndex], _array[marker]) && searchIndex < marker)
            {
                searchIndex++;
            }
            T insertHolder = _array[marker];//insertHolder will go into searchIndex
            T[] tempArray = new T[marker - searchIndex];
            //load a temp array.
            for (int i = searchIndex, j = 0; i < marker; i++, j++)
            {
                tempArray[j] = _array[i];
            }
            _array[searchIndex] = insertHolder;
            for (int i = searchIndex + 1, j = 0; i <= marker; i++, j++)
            {
                _array[i] = tempArray[j];
            }
        }


        //A would-be Quick Sort Algorithm. Inheriting IComparable made CompareTo() method function, but it broke other parts of the code.  

        //public void Sort()
        //{
        //    QuickSort(0, Count - 1);
        //}

        //void QuickSort(int lowIndex, int highIndex)
        //{
        //    if (lowIndex < highIndex)
        //    {
        //        int partitionIndex = Partition(_array[lowIndex], highIndex);
        //        QuickSort(lowIndex, partitionIndex);
        //        QuickSort(partitionIndex + 1, highIndex);
        //    }

        //}


        //public int Partition(T low, int highIndex)
        //{
        //    int forwardCounter = 0;
        //    int backwardCounter = highIndex;
        //    T pivotPlace = low;
        //    while (_array[forwardCounter].CompareTo(_array[backwardCounter]) <= 0)
        //    {
        //        do
        //        {
        //            forwardCounter++;
        //        } while (_array[forwardCounter].CompareTo(pivotPlace) <= 0);
        //        do
        //        {
        //            backwardCounter--;
        //        } while (_array[backwardCounter].CompareTo(pivotPlace) >= 0);
        //        Swap(_array[forwardCounter], _array[backwardCounter], forwardCounter, backwardCounter);
        //    }

        //    Swap(pivotPlace, _array[backwardCounter], 0, backwardCounter);
        //    return backwardCounter;//This index becomes the place of the new partition for sub array to left and subarray to right.
        //}

        //void Swap(T higher, T lower, int forwardCounter, int backwardCounter)
        //{
        //    _array[forwardCounter] = lower;
        //    _array[backwardCounter] = higher;
        //}


         //------------Add/Remove Support Methods-------------//
        //---------------------------------------------------//
        private int GetItemFrequency(T item)
        {
            int occurrences = 0;
            for (int i = 0; i < this.Count; i++) {
                if (item.ToString() == this[i].ToString()) {
                    occurrences++;
                }
            }
            return occurrences;
        }

        private void CreateNewArray(int size)
        {
            T[] oldArray = _array;
            _array = new T[Capacity];
            for (int i = 0; i < size; i++) {
                _array[i] = oldArray[i];
            }
        }

        private void CreateNewArray(int size, T removal)
        {
            T[] oldArray = _array;
            _array = new T[Capacity];
            int counter = 0;
            for (int i = 0; i < size; i++) {
                while (oldArray[counter].ToString() == removal.ToString()) {
                    counter++;
                }
                _array[i] = oldArray[counter];
                counter++;
            }
        }

        private void UpdateCapacity(string action, int prospectiveRemoval)
        {
            if (Count == Capacity && action == "Add"){//in this case, increase capactiy.
                capacity = Count * 2;
            }
            if (Capacity > 4 && (Count - prospectiveRemoval) * 2 <= Capacity && action == "Remove") {//in this case, decrease capactiy.
                capacity = Capacity / 2;
            }
        } 
    }
}
