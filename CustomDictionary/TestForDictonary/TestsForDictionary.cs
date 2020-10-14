using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomDictionary;



namespace TestForDictionary
{
    [TestFixture]
    public class TestsForDictionary
    {
        CustomDictionary<string, int> CustomDictionary;
        [SetUp]
        public void Setup()
        {
            CustomDictionary = new CustomDictionary<string, int>();
        }


        [Test]
        public void TestUsingOfIndexatorForReceivingValue()
        {
            CustomDictionary.Add("one",1);
            CustomDictionary.Add("two",2);
            CustomDictionary.Add("three",3);
            Assert.AreEqual(CustomDictionary["two"], 2);
        }

        [Test]
        public void TestUsingOfIndexatorForChangesValue()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary["one"] = 10;
            Assert.AreEqual(CustomDictionary["one"], 10);
        }


        [Test]
        public void TestGetValueUsingAdd()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            Assert.AreEqual(CustomDictionary["two"], 2);           
        }

        [Test]
        public void TestDictionaryCountUsingAdd()
        {
            Assert.AreEqual(CustomDictionary.count, 0);
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            Assert.AreEqual(CustomDictionary.count, 3);
        }



        [Test]
        public void TestKeyFindUsingContainsKey()
        {         
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            Assert.AreEqual(CustomDictionary.ContainsKey("three"), true);
            Assert.AreEqual(CustomDictionary.ContainsKey("ten"), false);
        }

     
        [Test]
        public void TestKeyFindUsingTryGetValue()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            CustomDictionary.Add("ten", 10);
            int value;
            Assert.AreEqual(CustomDictionary.TryGetValue("ten", out value), true);
            Assert.AreEqual(CustomDictionary.TryGetValue("twenty", out value),false);
        }

     
        [Test]
        public void TestKeyRemove ()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            CustomDictionary.Add("ten", 10);
            CustomDictionary.Remove("two");
            int value;
            Assert.AreEqual(CustomDictionary.TryGetValue("two", out value), false);
        }

        [Test]
        public void TestDictionaryCountUsingRemove()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            CustomDictionary.Add("ten", 10);
            Assert.AreEqual(CustomDictionary.count, 4);
            CustomDictionary.Remove("two");
            Assert.AreEqual(CustomDictionary.count, 3);
            CustomDictionary.Remove("twenty");
            Assert.AreEqual(CustomDictionary.count, 3);
        }


        [Test]
        public void TestGetExceptionUsingClear()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            CustomDictionary.Add("ten", 10);
            CustomDictionary.Clear();
            Assert.Throws<KeyNotFoundException>(() => Assert.AreEqual(CustomDictionary["two"],2));
        }

        [Test]
        public void TestDictionaryCountUsingClear()
        {
            CustomDictionary.Add("one", 1);
            CustomDictionary.Add("two", 2);
            CustomDictionary.Add("three", 3);
            CustomDictionary.Add("ten", 10);
            CustomDictionary.Clear();
            Assert.AreEqual(CustomDictionary.count, 0);            
        }


    }
}
