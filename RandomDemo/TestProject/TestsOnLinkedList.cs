using RandomDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class TestsOnLinkedList
    {
        [SetUp]
        public void SetUp() 
        {         
        }

        [Test]
        public void Ctor_WorksProperly() 
        {
            LinkedList linkedList = new LinkedList();
            Assert.IsNotNull(linkedList);
            Assert.That(linkedList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_WorksProperly() 
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add("Bear");
            linkedList.Add("Tiger");
            
            Assert.That(linkedList.Count, Is.EqualTo(2));

            linkedList.Remove(0);

            Assert.That(linkedList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_WorksProperly()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add("Bear");
            linkedList.Add("Tiger");

            Assert.That(linkedList.Count, Is.EqualTo(2));
            Assert.That(linkedList[0], Is.EqualTo("Bear"));
            Assert.That(linkedList[1], Is.EqualTo("Tiger"));
        }

        [Test]
        public void Remove_ReturnsObject_WhenParameterIsIndex()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add("Bear");
            linkedList.Add("Tiger");

            Assert.That(linkedList.Remove(0), Is.EqualTo("Bear"));
            Assert.That(linkedList.Count, Is.EqualTo(1));            
        }

        [Test]
        public void Remove_ReturnsIndex_WhenParameterIsObject()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add("Bear");
            linkedList.Add("Tiger");

            Assert.That(linkedList.Remove("Bear"), Is.EqualTo(0));
            Assert.That(linkedList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ThrowsArgumentException_WhenTheLinkedListIsEmpty()
        {
            LinkedList linkedList = new LinkedList();
            Assert.Throws<ArgumentException>(() => linkedList.Remove(0));
        }

        [Test]
        public void Contains_WorksProperly()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add("Bear");
            linkedList.Add("Tiger");

            Assert.IsTrue(linkedList.Contains("Bear"));
            Assert.IsFalse(linkedList.Contains("Elephant"));
        }

        [Test]
        public void IndexOf_WorksProperly()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add("Bear");
            linkedList.Add("Tiger");

            int interim = linkedList.IndexOf("Elephant");

            Assert.That(linkedList.IndexOf("Bear"), Is.EqualTo(0));
            Assert.That(interim, Is.LessThanOrEqualTo(0));
        }
    }
}
