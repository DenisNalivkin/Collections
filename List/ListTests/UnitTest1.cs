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
        public void TestOfHeadOfMethodUnderUsedAdd ()
        {
            list.Add(10);
            Assert.AreEqual(list[0], 10);    
        }

        [Test]
        public void TestForCheckOfCountOfList ()
        {
            list.Add(10);
            Assert.AreEqual(list.count, 0);
        }



        [Test]
        public void TestForCheckIndexatorOfNode ()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            Assert.AreEqual(list[2],78);
        }

        [Test]
        public void TestForCheckImplementExceptionsInIndexator ()
        {
            list.Add(10);
            list.Add(20);
            Assert.Throws <IndexOutOfRangeException> (() => Console.WriteLine(list[2]));            
        }
      
        [Test]
        public void TestForCheckRealizingTheAbilityToChangeValueInNode ()
        {
            list.Add(10);
            list.Add(20);
            list[0] = 5;
            Assert.AreEqual(list[0], 5);

        }



        [Test]
        public void TestForCheckMethodInsert()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Insert(2, 500);
            Assert.AreEqual(list[2], 500);
            Assert.AreEqual(list[3], 78);
            
        }

        [Test]
        public void TestForCheckImplementExceptionsInWorkMethodInsert()
        {
            list.Add(10);
            list.Add(20);
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(2,500));
        }

        [Test]
        public void TestForCheckOfCountOflistUnderUsedOfMethodInsert()
        {
            list.Add(10);
            list.Add(20);
            list.Add(400);
            Assert.AreEqual(list.count, 3);

        }




        [Test]
        public void TestForCheckMethodRemove()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Remove(20);
            Assert.AreEqual(list[1], 78);
        }

        [Test]
        public void TestForCheckMethodRemoveWhenTryingRemoveAbsentValue ()
        {
            list.Add(10);
            list.Add(20);
            list.Remove(200);
            Assert.AreEqual(list[0], 10);
            Assert.AreEqual(list[1], 20);


        }

        [Test]
        public void TestForCheckOfCountOflistUnderUsedOfMethodRemove()
        {
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Remove(20);
            Assert.AreEqual(list.count, 2);
           
        }






        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Test is done");

        }
    }
}
