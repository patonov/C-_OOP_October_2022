using BasicArrayList;
using System.Collections;

using ArrayList = BasicArrayList.ArrayList;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            ArrayList arrayList = new ArrayList();
            Assert.IsNotNull(arrayList);
            Assert.That(arrayList.Count, Is.EqualTo(0));
            Assert.That(arrayList.CountFreePositions, Is.EqualTo(2));
        }

        [Test]
        public void Add_WorksProperly()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(1);
            Assert.That(arrayList.Count, Is.EqualTo(1));

            arrayList.Add(2);
            arrayList.Add(3);

            Assert.That(arrayList.CountFreePositions(), Is.EqualTo(1));
        }

        [Test]
        public void Add_ResizesInternalArraySuccessfully()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);

            Assert.That(arrayList.CountFreePositions(), Is.EqualTo(3));
        }

        [Test]
        public void CountFreePositions_WorksProperly() 
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);

            Assert.That(arrayList.CountFreePositions(), Is.EqualTo(1));
        }

        [Test]
        public void Cut_WorksProperly() 
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            
            arrayList.Cut(2);
            Assert.That(arrayList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Cut_ThrowsArgumentOutOfRangeException_WhenCountIsBiggerThanCountOrLowerThanZero()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Cut(3));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Cut(-3));
        }

        [Test]
        public void Change_WorksProperly()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);

            Assert.That(arrayList.Change(5, 1991), Is.LessThan(0));
            Assert.That(arrayList.Change(2, 1888), Is.EqualTo(1));
        }

    }
}