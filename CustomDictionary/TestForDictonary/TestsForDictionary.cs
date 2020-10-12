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
        CustomDictionary<int, string> CustomDictionary;
        [SetUp]
        public void Setup ()
        {
            CustomDictionary = new CustomDictionary<int, string>();
        }

        [Test]
        public void TestUsingOfIndexatorForReceivingValue()
        {
            CustomDictionary.Add(1, "one");
            CustomDictionary.Add(2, "two");
            CustomDictionary.Add(3, "tree");
            Assert.AreEqual(CustomDictionary[2], "two");
           
        }

        [Test]
        public void TestUsingOfIndexatorForChangesValue()
        {
            CustomDictionary.Add(1, "one");
            CustomDictionary.Add(2, "two");
            CustomDictionary[1] = "ten";
            Assert.AreEqual(CustomDictionary[1], "ten");
        }

      
    }
}
