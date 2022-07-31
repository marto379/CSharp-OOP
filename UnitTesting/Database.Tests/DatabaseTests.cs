namespace Database.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]

        public void SetUp()
        {
            this.db = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void CtorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Arrange
            Database testDb = new Database(elementsToAdd);
            //Act
            int[] actualdData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualdData,
                "Database ctor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount,
                "Ctor should set initial value for count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]

        public void CtorMustNotAllowToExceedMaximumCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);

            }, "Array's capacity must be exacly 16 integers!");
        }

        [Test]

        public void CountMustsReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the added elements!");
        }

        [Test] 

        public void CountMustReturnZeroWhenNoElements()
        {
            int actualCount = db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when no elements in the Database!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void AddShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            foreach (var el in elementsToAdd)
            {
                this.db.Add(el);
            }

            int[] actualdData = this.db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualdData,
                "Add should physicaly add the elements to the field!");

            Assert.AreEqual(expectedCount, actualCount,
                "Add should change the elements count when adding!");
        }

        [Test]

        public void AddShouldThrowExeptionWhenAddingMoreThan16Elements()


        {
            for (int i = 0; i < 16; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array's capacity must be exacly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 2, 4, 5})]
        [TestCase(new int[] { 1 })]
        
        public void RemoveShouldRemoveOnlyTheLastElementSuccessfully(int[] startElements)
        {
            foreach (var el in startElements)
            {
                db.Add(el);
            }

            this.db.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualdData = this.db.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualdData);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };
            foreach (var item in initData)
            {
                db.Add(item);
            }

            for (int i = 0; i < initData.Count; i++)
            {
                db.Remove();
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData);
            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]

        public void RemoveShouldThrowExeptionWhenNoElements()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty!");
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void FetchShouldReturnCopyArray(int[] initData)
        {
            foreach (var item in initData)
            {
                this.db.Add(item);
            }
            int[] actualData = this.db.Fetch();
            int[] expecytedData = initData;

            CollectionAssert.AreEqual(expecytedData, actualData);

        }
    }
}
