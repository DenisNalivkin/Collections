using System;
using NUnit.Framework;
using System.Collections.Generic;
using ListTests;
using List;


namespace ListTests
{
    [TestFixture]
    public class UnitTest1
    {
        CustomList<int> list;
        [SetUp]
        public void  Setup ()
        {
            list = new CustomList<int>();
        }

        [Test]
        public void TestGetOfValueHead ()
        {
            list.Add(10);
            list.Add(20);
            Assert.AreEqual(list[0], 10);    
        }

        [Test]
        public void TestGetOfValueCounter ()
        {
            list.Add(10);
            Assert.AreEqual(list.count, 1);
        }



        [Test]
        public void TestGetIndexOfNode ()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            Assert.AreEqual(list[0], 10);
            Assert.AreEqual(list[1], 20);
            Assert.AreEqual(list[2], 78);
        }

        [Test]
        public void TestGetExceptionCallNonExistentElement ()
        {
            list.Add(10);
            list.Add(20);
            Assert.Throws <IndexOutOfRangeException> (() => Console.WriteLine(list[2]));            
        }
      
        [Test]
        public void TestGetValueOfNodeAfterChangedValue ()
        {
            list.Add(10);
            list.Add(20);
            list[0] = 5;
            Assert.AreEqual(list[0], 5);
        }



        [Test]
        public void TestGetValueAfterUsedInsert()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Insert(2, 500);
            Assert.AreEqual(list[2], 500);
            Assert.AreEqual(list[3], 78);         
        }

        [Test]
        public void TestGetExceptionAfterInsertInNonExistentNode()
        {
            list.Add(10);
            list.Add(20);
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(2,500));
        }

        [Test]
        public void TestGetValueCounterAfterUsedInsert()
        {
            list.Add(10);
            list.Add(20);
            list.Add(400);
            Assert.AreEqual(list.count, 3);
        }



        [Test]
        public void TestGetValueOfNodeWhichWasRemoved()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            bool valueFoundAndRemoved = list.Remove(20);
            Assert.AreEqual(list[1], 78);
            Assert.AreEqual(valueFoundAndRemoved, true);
        }

        [Test]
        public void TestGetNonExistentValue ()
        {
            list.Add(10);
            list.Add(20);
            bool valueFoundAndRemoved = list.Remove(200);
            Assert.AreEqual(list[0], 10);
            Assert.AreEqual(list[1], 20);
            Assert.AreEqual(valueFoundAndRemoved, false);
        }

        [Test]
        public void TestGetValueCounterAfterUsedRemove()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Remove(20);
            Assert.AreEqual(list.count, 2);          
        }



        [Test]
        public void TestGetValueCounterAfterUsedClear()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Clear();
            Assert.AreEqual(list.count, 0);
        }

        [Test]
        public void TestGetExceptionsAfterCallNonExistenValue()
        {
            list.Add(10);
            list.Add(20);
            list.Clear();
            Assert.Throws<IndexOutOfRangeException>(() => Console.WriteLine(list[0]));
        }

      



        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Test is done");

        }
    }
}
