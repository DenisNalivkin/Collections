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





                [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Test is done");

        }
    }
}
