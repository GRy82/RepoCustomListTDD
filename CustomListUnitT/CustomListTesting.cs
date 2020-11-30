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

        //------------------------------------------------------------------------------------
        //--------------------------REMOVE TESTS----------------------------------------------

        //At this point, all Add methods have passed UnitTesting.
        [TestMethod]
        public void Remove_CustomListCount_DecreaseByOne()
        {
            //arrange
            CustomList<Person> personList = new CustomList<Person> {  };
            personList.Add(new Person("Tim", 44));
            personList.Add(new Person("Kim", 38));
            int expectedCount = 1;
            //act
            personList.Remove();
            int actualCount = personList.Count;
            //assert
            Assert.AreEqual(actualCount, expectedCount);
        }

        [TestMethod] 
        public void Remove_SpecificItem_RemoveAllOccurrences()
        {
            //arrange
            CustomList<int> numsList = new CustomList<int> { };
            for (int i = 0; i < 5; i++)
            {
                numsList.Add(i);
                numsList.Add(3);
            }
            int expectedCount = 4;
            //act
            numsList.Remove(3);
            int actualCount = numsList.Count;
            //assert
            Assert.AreEqual(actualCount, expectedCount);

        }

        //[TestMethod]
        //public void Remove_EmptyCustomList_IndexOutOfBounds()
        //{
        //    //arrange
        //    CustomList<Person> personList = new CustomList<Person> { };
        //    //act

        //    //assert
        //    Assert.ThrowsException<ArgumentOutOfRangeException>(personList.Remove());
        //}

        //public void Remove_GetRemovedObjectField_IndexOutOfRange()
        //{
        //    //arrange
        //    CustomList<Person> personList = new CustomList<Person> { };
        //    Person john = new Person("John", 41);
        //    Person julie = new Person("Julie", 40);
        //    personList.Add(john);
        //    personList.Add(julie);
        //    int expectedAge = 40;
        //    //act
        //    personList.Remove();
        //    int actualAge = personList[1].age;
        //    //assert
        //    Assert.ThrowsException<ArgumentOutOfRangeException>(Action );
        //}


        [TestMethod]
        public void Remove_CustomListCapacity_TrimInHalf()
        {
            //arrange
            CustomList<int> integerList = new CustomList<int> { };
            integerList.Add(1);
            integerList.Add(1);
            integerList.Add(1);
            integerList.Add(1);
            integerList.Add(1);
            int expectedCap = 4;
            //act
            integerList.Remove();
            int actualCap = integerList.Capacity;
            //assert
            Assert.AreEqual(expectedCap, actualCap);
        }

        [TestMethod]
        public void Remove_OrderOfCollection_RemainsSame()
        {
            //arrange
            CustomList<string> snapCadence = new CustomList<string> { };
            snapCadence.Add("ready");
            snapCadence.Add("set");
            snapCadence.Add("hike");
            string expectedConcat = "readyset";
            //act
            snapCadence.Remove();
            string actualConcat = "";
            for(int i = 0; i < snapCadence.Count; i++)
            {
                actualConcat += snapCadence[i];
            }
            //assert
            Assert.AreEqual(actualConcat, expectedConcat);
        }

        [TestMethod]
        public void Remove_CountAndCapacity_ReturnToInitialIfEmpty()
        {
            //arrange
            CustomList<string> arbitraryWords = new CustomList<string> { };
            for(int i = 0; i < 6; i++)
            {
                arbitraryWords.Add("Shnarff shnarff");
            }
            //act
            for (int i = 5; i >= 0; i--)
            {
                arbitraryWords.Remove();
            }
            bool actualCountZero = arbitraryWords.Count == 0;
            bool actualCapFour = arbitraryWords.Capacity == 4;
            //assert
            Assert.IsTrue(actualCapFour && actualCountZero);
        }

        [TestMethod]
        public void Remove_SumOfIntegerContents_DecreasedByLastValue()
        {
            //arrange
            CustomList<int> addedNums = new CustomList<int> { };
            addedNums.Add(4);
            addedNums.Add(5);
            addedNums.Add(7);
            int actualSum = 0;
            int expectedSum = 9;
            //act
            addedNums.Remove();
            for (int i = 0; i < addedNums.Count; i++)
            {
                actualSum += addedNums[i];
            }
            //assert
            Assert.AreEqual(actualSum, expectedSum);
        }


        //------------------------------------------------------------------------------------
        //-------------------------ToString TESTS---------------------------------------------

        [TestMethod]
        public void ToString_ContentsOfList_PrintAsString()
        {
            //arrange
            CustomList<int> numsList = new CustomList<int> { };
            for (int i = 0; i < 6; i++)
            {
                numsList.Add(i);
            }
            string expected = "012345";
            //act
            string actual = numsList.ToString();
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToString_TwoEqualObjectLists_AreEqualAsStrings()
        {
            //arrange
            CustomList<Person> youngVersions = new CustomList<Person> { };
            CustomList<Person> oldVersions = new CustomList<Person> { };
            for (int i = 0; i < 4; i++)
            {
                youngVersions.Add(new Person("John", i));
                oldVersions.Add(new Person("John", i+60));
            }
            //act
            string youngPeople = youngVersions.ToString();
            string oldPeople = oldVersions.ToString();

            //assert
            Assert.AreEqual(youngPeople, oldPeople);
        }

        [TestMethod]
        public void ToString_StringLengthOfChars_EqualToListCount()
        {
            //arrange
            CustomList<char> customList = new CustomList<char> { };
            for(int i = 65; i < 91; i++) //Capital A-Z.
            {
                customList.Add(Convert.ToChar(i));
            }
            //act
            string alphabetString = customList.ToString();
            //assert
            Assert.AreEqual(customList.Count, alphabetString.Length);
        }

        //------------------------------------------------------------------------------------
        //------------------------- (+) Operator TESTS----------------------------------------

        [TestMethod]
        public void PlusOperatorOverload_FinalListCount_EqualsSumOfOriginalCounts()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            for (int i = 0; i < 5; i++)
            {
                numsList1.Add(i);
                numsList2.Add(i + 5);
            }
            CustomList<int> finalList;
            int expectedCount = 10;
            //act
            finalList = numsList1 + numsList2;
            int actualCount = finalList.Count;
            //assert
            Assert.AreEqual(actualCount, expectedCount);
        }

        [TestMethod]
        public void PlusOperatorOverload_FinalListSequence_OrderedLeftToRight()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            for (int i = 0; i < 5; i++)
            {
                numsList1.Add(i);
                numsList2.Add(i + 5);
            }
            CustomList<int> finalList;
            string expected = numsList1.ToString() + numsList2.ToString();
            //act
            finalList = numsList1 + numsList2;
            string actual = finalList.ToString();
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PlusOperatorOverload_FinalListSummedValues_EqualSumOfOriginalListValues()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            for (int i = 0; i < 5; i++)
            {
                numsList1.Add(i);
                numsList2.Add(i + 5);
            }
            CustomList<int> finalList;
            int expected = 45;
            //act
            finalList = numsList1 + numsList2;
            int actual = 0;
            for (int i = 0; i < finalList.Count; i++)
            {
                actual += finalList[i];
            }
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PlusOperatorOverload_FinalListSummedValues_HandlesObjRefType()
        {
            //arrange
            CustomList<Person> personList1 = new CustomList<Person> { };
            CustomList<Person> personList2 = new CustomList<Person> { };
            for (int i = 0; i < 3; i++)
            {
                personList1.Add(new Person("Bill", 44));
                personList2.Add(new Person("SuperChad", 33));
            }
            CustomList<Person> finalList;
            string expected = "BillBillBillSuperChadSuperChadSuperChad";
            //act
            finalList = personList1 + personList2;
            string actual = null;
            for (int i = 0; i < finalList.Count; i++)
            {
                actual += finalList[i].name;
            }
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PlusOperatorOverload_AddedEmptyLists_CreateEmptyList()
        {
            //arrange
            CustomList<int> numsListOne = new CustomList<int> { };
            CustomList<int> numsListTwo = new CustomList<int> { };
            //act
            CustomList<int> sumList = numsListOne + numsListTwo;
            //assert
            Assert.AreEqual(0, sumList.Count);
        }


        //------------------------------------------------------------------------------------//
        //------------------------- (-) Operator TESTS----------------------------------------//

        [TestMethod]
        public void SubtractionOperatorOverload_ListCount_ReflectsFinalList()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            CustomList<int> finalList;
            for (int i = 0; i < 7; i++)
            {
                if (i < 3) {
                    numsList2.Add(i);
                }
                numsList1.Add(i);
            }
            int expectedCount = 4;
            //act
            finalList = numsList1 - numsList2;
            int actualCount = finalList.Count;
            //assert
            Assert.AreEqual(actualCount, expectedCount);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_ListContent_OddsOnly()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            CustomList<int> finalList;
            for (int i = 0; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    numsList2.Add(i);
                }
                numsList1.Add(i);
            }
            int expectedOddCount = 5;
            //act
            finalList = numsList1 - numsList2;
            int actualOddCount = 0;
            for(int i = 0; i < finalList.Count; i++)
            {
                if(finalList[i] % 2 != 0){
                    actualOddCount++;
                }
            }
            //assert
            Assert.AreEqual(actualOddCount, expectedOddCount);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_ListCapacity_IsCorrectSize()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            CustomList<int> finalList;
            numsList2.Add(4);
            for (int i = 0; i < 5; i++)
            {
                numsList1.Add(i);
            }
            int expectedCapacity = 4;
            //act
            finalList = numsList1 - numsList2;
            int actualCapacity = finalList.Capacity;
            //assert
            Assert.AreEqual(actualCapacity, expectedCapacity);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_RepeatValuesInSubtractedList_AreHandledOnce()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            CustomList<int> finalList;
            for (int i = 0; i < 5; i++)
            {
                numsList2.Add(2);
                numsList1.Add(i);
            }
            string expectedSequence = "0134";
            //act
            finalList = numsList1 - numsList2;
            string actualSequence = finalList.ToString();
            //assert
            Assert.AreEqual(actualSequence, expectedSequence);
        }
        [TestMethod]
        public void SubtractionOperatorOverload_ListSubtractedBySelf_IsLikeEmptyList()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> finalList;
            for (int i = 0; i < 5; i++)
            { 
                numsList1.Add(i);
            }
            CustomList<int> emptyList = new CustomList<int>();
            //act
            finalList = numsList1 - numsList1;
            int actualCount = finalList.Count;
            int actualCap = finalList.Capacity;
            string actualContents = finalList.ToString();
            bool isEmpty = (actualContents == null || actualContents == "");
            //assert
            Assert.AreEqual(actualCap, emptyList.Capacity);
            Assert.AreEqual(actualCount, emptyList.Count);
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_ContentsOfList_UnaffectedByUnsharedElements()
        {
            //arrange
            CustomList<int> numsList1 = new CustomList<int> { };
            CustomList<int> numsList2 = new CustomList<int> { };
            for (int i = 0; i < 5; i++)
            {
                numsList1.Add(i);
            }
            for (int i = 4; i < 8; i++)
            {
                numsList2.Add(i);
            }

            //act
            numsList1 = numsList1 - numsList2;
            string expected = "0123";
            string actual = numsList1.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }

        //------------------------------------------------------------------------------------
        //------------------------------- Zipper TESTS----------------------------------------
        [TestMethod]
        public void Zipper_ReturnedList_HasCorrectCapacity()
        {
            //arrange
            CustomList<int> evenNums = new CustomList<int> { };
            CustomList<int> oddNums = new CustomList<int> { };
            for(int i = 0; i < 12; i++)
            {
                if (i % 2 == 0)
                {
                    evenNums.Add(i);
                }
                else
                {
                    oddNums.Add(i);
                }
            }
            CustomList<int> zippedList;
            int expectedCapacity = 16;
            //act
            zippedList = oddNums.Zipper(evenNums);
            int actualCapacity = zippedList.Capacity;
            //assert
            Assert.AreEqual(actualCapacity, expectedCapacity);
            
        }

        [TestMethod]
        public void Zipper_PassedEmptyList_ReturnPopulatedList()
        {
            //arrange
            CustomList<char> listOne = new CustomList<char> { };
            CustomList<char> listTwo = new CustomList<char> { };
            listOne.Add('A');
            listOne.Add('B');
            //act
            CustomList<char> zipped;
            zipped = listOne.Zipper(listTwo);
            
            //assert
            Assert.AreEqual(listOne, zipped);

        }

        [TestMethod]
        public void Zipper_UnequalOriginalCounts_ReturnWithExcessAtEnd()
        {
            //arrange
            CustomList<int> evenNums = new CustomList<int> { };
            CustomList<int> oddNums = new CustomList<int> { };
            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    evenNums.Add(i);
                }
                else
                {
                    oddNums.Add(i);
                }
            }
            evenNums.Add(10);
            CustomList<int> zippedList;
            int expectedLastNumber = 10;
            //act
            zippedList = evenNums.Zipper(oddNums);
            int actualLastNumber = zippedList[zippedList.Count - 1];
            //assert
            Assert.AreEqual(actualLastNumber, expectedLastNumber);

        }

        [TestMethod]
        public void Zipper_OriginalList_RemainUnchanged()
        {
            //arrange
            CustomList<int> evenNums = new CustomList<int> { };
            CustomList<int> oddNums = new CustomList<int> { };
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    evenNums.Add(i);
                }
                else
                {
                    oddNums.Add(i);
                }
            }
            CustomList<int> zippedList;
            string expectedOddString = "13579";
            string expectedEvenString = "02468";
            //act
            zippedList = evenNums.Zipper(oddNums);
            string actualOddString = oddNums.ToString();
            string actualEvenString = evenNums.ToString();
            //assert
            Assert.AreEqual(actualOddString, expectedOddString);
            Assert.AreEqual(actualEvenString, expectedEvenString);

        }
        [TestMethod]
        public void Zipper_ReturnedList_HasOrderedNumbers()
        {
            //arrange
            CustomList<int> evenNums = new CustomList<int> { };
            CustomList<int> oddNums = new CustomList<int> { };
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    evenNums.Add(i);
                }
                else
                {
                    oddNums.Add(i);
                }
            }
            CustomList<int> zippedList;
            string expectedString = "0123456789";
            //act
            zippedList = evenNums.Zipper(oddNums);
            string actualString = zippedList.ToString();
            //assert
            Assert.AreEqual(actualString, expectedString);

        }
         //------------------------------------------------------------------------------------//
        //-------------------------------Sort(Insertion) TESTS--------------------------------//
        [TestMethod]
        public void Sort_CustomListSequence_AscendingOrderInts()
        {
            //arrange
            CustomList<int> unorderedList = new CustomList<int>();
            unorderedList.Add(4);
            unorderedList.Add(3);
            unorderedList.Add(1);
            unorderedList.Add(5);
            unorderedList.Add(2);
            string expectedOrder = "41235";
            //act
            unorderedList.Sort(1, 4);
            string actualOrder = unorderedList.ToString();
            //assert
            Assert.AreEqual(actualOrder, expectedOrder);
        }

        [TestMethod]
        public void Sort_CustomListSequence_AlphabetizedChars()
        {
            //arrange
            CustomList<char> unorderedList = new CustomList<char>();
            unorderedList.Add('B');
            unorderedList.Add('F');
            unorderedList.Add('G');
            unorderedList.Add('A');
            string expectedOrder = "ABFG";
            //act
            unorderedList.Sort();
            string actualOrder = unorderedList.ToString();
            //assert
            Assert.AreEqual(actualOrder, expectedOrder);
        }

        [TestMethod]
        public void Sort_CustomListChars_IgnoreCase()
        {
            //arrange
            CustomList<char> unorderedList = new CustomList<char>();
            unorderedList.Add('B');
            unorderedList.Add('f');
            unorderedList.Add('g');
            unorderedList.Add('A');
            string expectedOrder = "ABfg";
            //act
            unorderedList.Sort();
            string actualOrder = unorderedList.ToString();
            //assert
            Assert.AreEqual(actualOrder, expectedOrder);
        }

        [TestMethod]
        public void Sort_CustomListSequence_AlphabetizedStrings()
        {
            //arrange
            CustomList<string> unorderedList = new CustomList<string>();
            unorderedList.Add("Puppy");
            unorderedList.Add("Dog");
            unorderedList.Add("Dorm");
            unorderedList.Add("Poopy");
            string expectedOrder = "DogDormPoopyPuppy";
            //act
            unorderedList.Sort();
            string actualOrder = unorderedList.ToString();
            //assert
            Assert.AreEqual(actualOrder, expectedOrder);
        }

        [TestMethod]
        public void Sort_EmptyCustomList_ListUnaltered()
        {
            //arrange
            CustomList<string> unorderedList = new CustomList<string>();
            //act
            unorderedList.Sort();
            //assert
            Assert.AreEqual(0, unorderedList.Count);
            //Also does not crash.
        }

        [TestMethod]
        public void Sort_ListOfRefObjects_ListUnaltered()
        {
            //arrange
            CustomList<Person> unorderedList = new CustomList<Person>();
            unorderedList.Add(new Person("Todd", 4));
            unorderedList.Add(new Person("Rundgren", 14));
            unorderedList.Add(new Person("Jack", 47));
            unorderedList.Add(new Person("Kerouac", 47));
            CustomList<string> namesList = new CustomList<string> { };
            string expected = "ToddRundgrenJackKerouac";
            //act
            unorderedList.Sort();
            foreach (Person person in unorderedList)
            {
                namesList.Add(person.name);
            }
            string actual = namesList.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }

         //------------------------------------------------------------------------//
        //--------------------------Enumerator Tests------------------------------//

        [TestMethod]
        public void Enumerator_Enumerate_PrintAllStringsContained()
        {
            //arrange
            CustomList<string> randomStrings = new CustomList<string>();
            randomStrings.Add("Hi ");
            randomStrings.Add("There ");
            randomStrings.Add("Everyone");
            string actual = "";
            string expected = "Hi There Everyone";
            //act
            foreach (string stringThing in randomStrings)
            {
                actual += stringThing;
            }
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
