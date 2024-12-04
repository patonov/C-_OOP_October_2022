using RandomDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class TestsOnCustomArrayList
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly() 
        {
            CustomArrayList arrayList = new CustomArrayList();
            Assert.NotNull(arrayList);            
        }

        [Test]
        public void Ctor_InitializesObjectWithZeroCountOfElements()
        {
            CustomArrayList arrayList = new CustomArrayList();
            Assert.Zero(arrayList.Count);
        }

        [Test]
        public void Add_WorksProperly()
        {
            CustomArrayList arrayList = new CustomArrayList();
            arrayList.Add(1);
            arrayList.Add("Hero");

            Assert.NotZero(arrayList.Count);
            Assert.That(arrayList.Count, Is.EqualTo(2));
            Assert.That(arrayList[0], Is.Not.EqualTo(arrayList[2]));
        }

        [Test]
        public void Insert_WorksProperly()
        {
            CustomArrayList arrayList = new CustomArrayList();
            arrayList.Add(1);
            arrayList.Add("Hero");
            arrayList.Insert(0, "Duck");
            
            Assert.That(arrayList[0], Is.EqualTo("Duck"));
            Assert.That(arrayList.Count, Is.EqualTo(3));
        }

        [Test]
        public void IndexOf_WorksProperly()
        {
            CustomArrayList arrayList = new CustomArrayList();
            
            arrayList.Add("Hero");
            arrayList.Add("Duck");

            Assert.That(arrayList.IndexOf("Duck"), Is.EqualTo(1));
        }


    }
}
