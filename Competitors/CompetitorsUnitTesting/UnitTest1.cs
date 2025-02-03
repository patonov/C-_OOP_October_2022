using Competitors;

namespace CompetitorsUnitTesting
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 19);

            Assert.That(baiAtanas, Is.Not.Null);
        }

        [Test]
        public void Ctor_DoesItInicializeAnEmptyCollection() 
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 19);
            Assert.That(baiAtanas.Scores.Count, Is.Zero);
        }

        [Test]
        public void Name_SetsTheValueOfTheProperty()
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 18);

            Assert.That(baiAtanas.Name, Is.EqualTo("Atanas"));
        }

        [Test]
        public void Age_SetsTheValueOfTheProperty() 
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 18);

            Assert.That(baiAtanas.Age, Is.EqualTo(18));
        }

        [Test]
        public void Age_ThrowsException_WhenValueWeWantToSetIsLowerThan10()
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 18);

            Assert.Throws<ArgumentException>(() => baiAtanas.Age = 9, "Age cannot be less than 10.");
        }

        [Test]
        public void Add_WorksProperly()
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 18);

            baiAtanas.Add(1001);

            Assert.That(baiAtanas.Scores.Count, Is.EqualTo(1));

            baiAtanas.Add(2002);

            Assert.That(baiAtanas.Scores.Count, Is.EqualTo(2));
        }

        [Test]
        public void ChangeLastScore_DoesItReallyChangeTheLastElementOfTheListOfScores()
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 18);
            baiAtanas.Add(6);
            baiAtanas.Add(4);
            baiAtanas.Add(5);

            baiAtanas.ChangeLastScore(9);

            int lastElement = baiAtanas.Scores[baiAtanas.Scores.Count - 1];

            Assert.That(lastElement, Is.EqualTo(9));
        }

        [Test]
        public void CompareTo_WorksProperly()
        {
            Competitor<int> baiAtanas = new Competitor<int>("Atanas", 18);
            Competitor<int> baiAtanasTwo = new Competitor<int>("Atanas", 19);

            int result = baiAtanas.Age.CompareTo(baiAtanasTwo.Age);

            Assert.IsTrue(result == -1);
        }


    }
}