using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CustomList;

namespace UnitTestCustomList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_IncrementCount_CountOfFour()
        {
            //arrange
            CustomList<int> customIntList = new CustomList<int> { };
            int expected = 4;
            int actual;
            //act
            for (int i = 0; i < 4; i++)
            {
                customIntList.Add(1);
            }
            actual = customIntList.Count;
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Add_ExpandCapacity_DoubleCapToEightWhenFull()
        {
            //arrange
            CustomList<int> customIntList = new CustomList<int> { };
            int expected = 8;
            int actual;
            //act
            for(int i = 0; i < 5; i++)
            {
                customIntList.Add(1);
            }
            actual = customIntList.Capacity;
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Add_AppendsToCorrectIndex_Equivalence()
        {

            //arrange
            bool expectedEqual = false;
            CustomList<int> customIntList = new CustomList<int> { };
            //act
            customIntList.Add(1);
            customIntList.Add(1);

            if (customIntList[0] == customIntList[1]) {
                expectedEqual = true;
            }
            //assert
            Assert.IsTrue(expectedEqual);
        }

        public void Add_AppendsToCorrectIndex_Unequivalent()
        {

            //arrange
            bool expectedUnequal = false;
            CustomList<int> customIntList = new CustomList<int> { };
            //act
            customIntList.Add(1);
            customIntList.Add(2);
            if (customIntList[0] != customIntList[1])
            {
                expectedUnequal = true;
            }
            //assert
            Assert.IsTrue(expectedUnequal);
        }

        [TestMethod]
        public void Add_AccessObjectPropertyOfIndex_GetNameOfObject()
        {

            //arrange

            //act

            //assert
        }
    }
}
