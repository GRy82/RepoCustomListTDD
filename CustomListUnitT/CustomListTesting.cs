using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CustomList;

namespace CustomListUnitT
{
    [TestClass]
    public class CustomListTesting
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
            for (int i = 0; i < 5; i++)
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
            CustomList<int> customIntList = new CustomList<int> { };
            //act
            customIntList.Add(1);
            customIntList.Add(1);
            bool expectedEqual = customIntList[0] == customIntList[1];
            //assert
            Assert.IsTrue(expectedEqual);
        }

        public void Add_AppendsToCorrectIndex_Unequivalent()
        {

            //arrange
            CustomList<int> customIntList = new CustomList<int> { };
            //act
            customIntList.Add(1);
            customIntList.Add(2);
            bool expectedUnequal = customIntList[0] != customIntList[1];
            //assert
            Assert.IsTrue(expectedUnequal);
        }

        [TestMethod]
        public void Add_AppendsCorrectType_TypeIsPerson()
        {

            //arrange
            Person william = new Person("William", 66);
            var expected = william.GetType();
            CustomList<Person> personList = new CustomList<Person> { };
            //act
            personList.Add(william);
            var actual = personList[0].GetType();
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Add_AccessObjectFieldOfIndex_NamesAgesEqual()
        {

            //arrange
            int expectedAge = 66;
            string expectedName = "William";
            Person william = new Person("William", 66);
            CustomList<Person> personList = new CustomList<Person> { };
            //act
            personList.Add(william);
            string actualName = personList[0].name;
            int actualAge = personList[0].age;
            //assert
            Assert.AreEqual(actualName, expectedName);
            Assert.AreEqual(actualAge, expectedAge);
        }
    }
}
