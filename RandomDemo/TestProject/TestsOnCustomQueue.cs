using RandomDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class TestsOnCustomQueue
    {
        [Test]
        public void Enqueue_EmptyQueue_ShouldAddElement()
        {
            var queue = new CustomQueue();

            queue.Enqueue(5);

            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void EnqueueDeque_ShouldWorkCorrectly()
        {
   
            var queue = new CustomQueue();
            var element = 15;

            queue.Enqueue(element);
            var elementFromQueue = queue.Dequeue();

            Assert.That(queue.Count, Is.EqualTo(0));
            Assert.That(elementFromQueue, Is.EqualTo(element));
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            var queue = new CustomQueue();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void EnqueueDequeue100Elements_ShouldWorkCorrectly()
        {
            var queue = new CustomQueue();
            int numberOfElements = 1000;

            for (int i = 0; i < numberOfElements; i++)
            {
                queue.Enqueue(i);
            }
                        
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.That(queue.Count, Is.EqualTo(numberOfElements - i));
                var element = queue.Dequeue();
                Assert.That(element, Is.EqualTo(i));
                Assert.That(queue.Count, Is.EqualTo(numberOfElements - i - 1));
            }
        }

        [Test]
        public void CircularQueue_EnqueueDequeue_ShouldWorkCorrectly()
        {
            var queue = new CustomQueue();

            queue.Enqueue(1);

            queue.Enqueue(queue.Dequeue());
            
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enqueue500Elements_ToArray_ShouldWorkCorrectly()
        {
            var array = Enumerable.Range(1, 500).ToArray();
            var queue = new CustomQueue();

            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }
            var arrayFromQueue = queue.ToArray();

            CollectionAssert.AreEqual(array, arrayFromQueue);
        }

        [Test]
        public void InitialCapacity_EnqueueDequeueFourElements_ShouldWorkCorrectly()
        {            
            var queue = new CustomQueue();
            
            Assert.That(queue.Capacity, Is.EqualTo(4));            
        }

        [Test]
        public void Capacity_ResizingShouldWorkCorrectly()
        {
            var queue = new CustomQueue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
                
            Assert.That(queue.Capacity, Is.EqualTo(8));
        }
    }
}
