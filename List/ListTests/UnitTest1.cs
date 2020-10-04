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
        public void TestOfHeadOfMethodUnderUsedAdd()
        {
            list.Add(10);
            list.Remove(10);
            Assert.AreEqual(list[0], 10);

        }





        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Test is done");

        }
    }
}
