using System;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Ctor_WorksProperly()
    {
        HeroRepository repository = new HeroRepository();
        Assert.That(repository.Heroes.Count, Is.EqualTo(0));
    }

    [Test]
    public void Create_WorksProperly()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho Heroto", 2);

        string result = "Successfully added hero Pesho Heroto with level 2";
                
        Assert.That(repository.Create(hero), Is.EqualTo(result));
        Assert.That(repository.Heroes.Count, Is.EqualTo(1));
    }

    [Test]
    public void Create_ThrowsArgumentNullException_WhenHeroIsNull()
    {
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => repository.Create(null), "Hero is null");
    }

    [Test]
    public void Create_ThrowsInvalidOperationException_WhenHeroAlreadyExists()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho Heroto", 2);
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repository.Create(hero), "Hero with name Pesho Heroto already exists");
    }

    [Test]
    public void Remove_WorksProperly()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho Heroto", 2);
        Hero hero2 = new Hero("Mara Tuhlata", 2);

        repository.Create(hero);
        repository.Create(hero2);
        Assert.That(repository.Remove("Pesho Heroto"), Is.True);
    }

    [Test]
    public void Remove_ThrowsArgumentNullException_WhenNameIsNullOrWhiteSpace()
    {
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => repository.Remove(null), "Name cannot be null");
        Assert.Throws<ArgumentNullException>(() => repository.Remove(" "), "Name cannot be null");
    }

    [Test]
    public void GetHeroWithHighestLevel_WorksProperly()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho Heroto", 1);
        Hero hero2 = new Hero("Mara Tuhlata", 2);
        Hero hero3 = new Hero("Joro Paveto", 3);

        repository.Create(hero);
        repository.Create(hero2);
        repository.Create(hero3);

        Assert.That(repository.GetHeroWithHighestLevel(), Is.EqualTo(hero3));
    }

    public void GetHero_WorksProperly()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho Heroto", 1);
        Hero hero2 = new Hero("Mara Tuhlata", 2);
        Hero hero3 = new Hero("Joro Paveto", 3);

        repository.Create(hero);
        repository.Create(hero2);
        repository.Create(hero3);

        Assert.That(repository.GetHero("Joro Paveto"), Is.EqualTo(hero3));
    }

    [Test]
    public void Heroes_WasSetProperly()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho Heroto", 1);
        Hero hero2 = new Hero("Mara Tuhlata", 2);
        Hero hero3 = new Hero("Joro Paveto", 3);

        repository.Create(hero);
        repository.Create(hero2);
        repository.Create(hero3);

        Assert.That(repository.Heroes.Count, Is.EqualTo(3));
        Assert.That(repository.Heroes.Contains(hero), Is.True);
        Assert.That(repository.Heroes.Contains(hero2), Is.True);
        Assert.That(repository.Heroes.Contains(hero3), Is.True);
    }

}