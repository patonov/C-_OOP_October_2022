// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[SetUp]
		public void Setup()
		{ 		
		}

		[Test]
	    public void Ctor_WorksProperly()
	    {
			Stage stage = new Stage();
			Assert.That(stage, Is.Not.Null);
			Assert.That(stage.Performers.Count, Is.EqualTo(0));
		}

		[Test]
		public void AddPerformer_WorksProperly()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Gosho", "Perfoto", 22);
			stage.AddPerformer(performer);

			Assert.That(stage.Performers.Count, Is.EqualTo(1));
		}

		[Test]
		public void AddPerformer_ThrowsArgumentException_WhenAgeIsLessThanZero()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Gosho", "Perfoto", 15);

			Assert.Throws<ArgumentException>(()=> stage.AddPerformer(performer), "You can only add performers that are at least 18.");
		}

		[Test]
		public void AddPerformer_ThrowsArgumentNullException_WhenPerformerIsNull()
		{
			Stage stage = new Stage();
			
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null), "Can not be null!");
		}

		[Test]
		public void AddSong_ThrowsArgumentException_WhenDurationIsLessThanMinute()
		{
			Stage stage = new Stage();
			TimeSpan interval = new TimeSpan(0, 0, 18);
			Song song = new Song("Ela, ela", interval);
						
			Assert.Throws<ArgumentException>(() => stage.AddSong(song), "You can only add songs that are longer than 1 minute.");
		}

		[Test]
		public void AddSongToPerformer_WorksProperly()
		{
			Stage stage = new Stage();
			TimeSpan interval = new TimeSpan(0, 2, 18);
			Song song = new Song("Ela, ela", interval);
			Performer performer = new Performer("Gosho", "Perfoto", 24);
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.That(stage.AddSongToPerformer("Ela, ela", "Gosho Perfoto"), Is.EqualTo($"{song} will be performed by Gosho Perfoto"));
		}

		[Test]
		public void Play_WorksProperly()
		{
			Stage stage = new Stage();
			TimeSpan interval = new TimeSpan(0, 2, 18);
			Song song = new Song("Ela, ela", interval);
			Performer performer = new Performer("Gosho", "Perfoto", 24);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("Ela, ela", "Gosho Perfoto");

			Assert.That(stage.Play(), Is.EqualTo("1 performers played 1 songs"));
		}

	}
}