namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            Book book = new Book("Az biah tam", "Bash zatvornik");

            Assert.That(book.BookName, Is.EqualTo("Az biah tam"));
            Assert.That(book.Author, Is.EqualTo("Bash zatvornik"));
            Assert.That(book.FootnoteCount, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Ivan Vazov"), "Invalid BookName!");
            Assert.Throws<ArgumentException>(() => new Book(null, "Ivan Vazov"), "Invalid BookName!");
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenAuthorIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("Az, Boyko", ""), "Invalid Author");
            Assert.Throws<ArgumentException>(() => new Book("Az, Boyko", null), "Invalid Author");
        }

        [Test]
        public void AddFootnote_WorksProperly()
        {
            Book book = new Book("Az, Boyko", "Ivan Vazov");
            book.AddFootnote(1, "Tralala");
            Assert.That(book.FootnoteCount, Is.EqualTo(1));
        }

        [Test]
        public void AddFootnote_ThrowsArgumentException_WhenFootnoteExists()
        {
            Book book = new Book("Az, Boyko", "Ivan Vazov");
            book.AddFootnote(1, "Tralala");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "Tralala"), "Footnote already exists!");
        }

        [Test]
        public void FindFootnote_WorksProperly()
        {
            Book book = new Book("Az, Boyko", "Ivan Vazov");
            book.AddFootnote(1, "Tralala");
            book.AddFootnote(2, "Ehaha");
            book.AddFootnote(3, "Mashala");
            
            string result = $"Footnote #2: Ehaha";

            Assert.That(book.FindFootnote(2), Is.EqualTo(result));
        }

        [Test]
        public void FindFootnote_ThrowsInvalidOperationException_WhenFootnoteDoesNotExist()
        {
            Book book = new Book("Az, Boyko", "Ivan Vazov");
            book.AddFootnote(1, "Tralala");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2), "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootnote_WorksProperly()
        {
            Book book = new Book("Az, Boyko", "Ivan Vazov");
            book.AddFootnote(1, "Tralala");
            string result = $"Footnote #1: Ehaha";
            book.AlterFootnote(1, "Ehaha");

            Assert.That(book.FindFootnote(1), Is.EqualTo(result));
        }

        [Test]
        public void AlterFootnote_ThrowsInvalidOperationException_WhenFootnoteDoesNotExist()
        {
            Book book = new Book("Az, Boyko", "Ivan Vazov");
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "Ne staa"), "Footnote does not exists!");
        }

    }
}