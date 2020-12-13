using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomLinkedList;
using NUnit;

namespace TestsForCustomLinkedList
{
    public class NunitTests
    {
        [TestFixture]
        public class NunitTests1
        {
            CustomLinkedList<int> linkedList;
            [SetUp]
            public void Setup()
            {
                linkedList = new CustomLinkedList<int>();
            }


            [Test]
            public void TestGetValueAfterUsedAdd()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                Assert.AreEqual(linkedList[0], 1);
                Assert.AreEqual(linkedList[1], 2);
            }
            [Test]
            public void TestCountValueAfterUsedAdd()
            {
                Assert.AreEqual(linkedList.Count, 0);
                linkedList.Add(1);
                Assert.AreEqual(linkedList.Count, 1);
                linkedList.Add(2);
                Assert.AreEqual(linkedList.Count, 2);              
            }
        

            [Test]
            public void TestGetValueAfterUsedIndexator()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                Assert.AreEqual(linkedList[0],1);
            }
            [Test]
            public void TestGetExceptionAfterUsedIndexator()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                Assert.Throws<System.ArgumentOutOfRangeException>(() => Console.WriteLine(linkedList[2]));
            }
            [Test]
            public void TestGetValueAfterChangedValueByIndexator()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                Assert.AreEqual(linkedList[1], 2);
                linkedList[1] = 100;
                Assert.AreEqual(linkedList[1], 100);
            }


            [Test]
            public void TestGetValueAfterUsedInsert()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                linkedList.Insert(100, 1);
                Assert.AreEqual(linkedList[1], 100);
                Assert.AreEqual(linkedList[2], 2);
                Assert.AreEqual(linkedList[3], 3);          
            }
            [Test]
            public void TestGetValueAfterUsedInsertToZeroNode()
            {     
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                linkedList.Insert(200, 0);
                Assert.AreEqual(linkedList[0], 200);
                Assert.AreEqual(linkedList[1], 1);
                Assert.AreEqual(linkedList[2], 2);
                Assert.AreEqual(linkedList[3], 3);
            }
            [Test]
            public void TestGetExceptionAfterUsedInsert()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);              
                Assert.Throws<System.ArgumentOutOfRangeException>(() => linkedList.Insert(100, 3));
            }
            [Test]
            public void TestCountValueAfterUsedInsert()
            {
                Assert.AreEqual(linkedList.Count, 0);
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                Assert.AreEqual(linkedList.Count, 3);
                linkedList.Insert(100, 0);
                Assert.AreEqual(linkedList.Count, 4);
            }


            [Test]
            public void TestGetValueAfterUsedRemove()
            {             
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                Assert.AreEqual(linkedList[1], 2);
                linkedList.Remove(2);
                Assert.AreEqual(linkedList[1], 3);             
            }
            [Test]
            public void TestGetBoolValueAfterUsedRemove()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);           
                bool valueWasRemoved = linkedList.Remove(3);
                Assert.AreEqual(valueWasRemoved, true);


            }
            [Test]
            public void TestCountValueAfterUsedRemove()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                Assert.AreEqual(linkedList.Count, 3);
                linkedList.Remove(3);
                Assert.AreEqual(linkedList.Count, 2);              
            }


            [Test]
            public void TestGetValueAfterUsedClear()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                linkedList.Clear();
                Assert.Throws<System.ArgumentOutOfRangeException>(() => Console.WriteLine(linkedList[0]));
            }
            [Test]
            public void TestCountValueAfterUsedClear()
            {
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.Add(3);
                linkedList.Clear();
                Assert.AreEqual(linkedList.Count, 0);
            }






        }




    }
}
