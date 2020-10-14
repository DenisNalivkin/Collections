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
            CustomDictionary.Add("tree",3);
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


    }
}
