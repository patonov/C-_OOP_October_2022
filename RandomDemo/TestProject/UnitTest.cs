using RandomDemo;

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
            CustomStack stack = new CustomStack();

            Assert.That(stack, Is.Not.Null);
        }

        [Test]
        public void Ctor_CreatesStackWithZeroCount() 
        {
            CustomStack stack = new CustomStack();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_ThrowsInvalidOperationException_WhenTheStackIsEmpty()
        {
            CustomStack stack = new CustomStack();

            Assert.Throws<InvalidOperationException>(() => stack.Pop(), "The stack is empty.");
        }

        [Test]
        public void Push_WorksProperly()
        {
            CustomStack stack = new CustomStack();
            stack.Push(1);

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_ThrowsInvalidOperationException_WhenTheStackIsEmpty()
        {
            CustomStack stack = new CustomStack();

            Assert.Throws<InvalidOperationException>(() => stack.Peek(), "The stack is empty.");
        }

        [Test]
        public void ForEach_WorksProperly()
        {
            CustomStack stack = new CustomStack();
            stack.Push(111);
            
            Assert.Throws<NullReferenceException>(() => stack.ForEach(null));
        }
    }
}