using RandomDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestsOnTree
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_TreeIsSuccessfullyInitialized()
        {
            Tree<int> trialTree = new Tree<int>(1,
                        new Tree<int>(3,
                                new Tree<int>(7),
                                new Tree<int>(9),
                                new Tree<int>(12)),
                        new Tree<int>(15),
                        new Tree<int>(6,
                                new Tree<int>(8),
                                new Tree<int>(10)));

            Assert.NotNull(trialTree);
        }

        [Test]
        public void Ctor_WorksProperlyWithOneValue()
        {
            Tree<string> textTree = new Tree<string>("Root");

            Assert.NotNull(textTree);

            Assert.That(textTree.OrderTreeViaDfs().Any(x => x == "Root"), Is.True);
        }
    }
}
