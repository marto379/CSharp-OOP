using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CtorShouldMakeEmtyListOgHero()
    {
        HeroRepository heroes = new HeroRepository();

        Assert.That(heroes.Heroes.Count, Is.EqualTo(0));
    }
    [Test]
    public void CreateMethodShouldAddHeroToTheList()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);

        heroes.Create(hero);

        Assert.AreEqual(1, heroes.Heroes.Count);
    }
    [Test]
    public void CreateMethodShouldThrowsExceptionWhenHeroIsNull()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Create(null);
        });

    }
    [Test]
    public void CreateMethodShouldThrowsExceptionWhenHeroINTheList()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);
        heroes.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroes.Create(hero);
        });

    }
    [Test]
    public void RemoveMethodShouldRemoveHero()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);
        heroes.Create(hero);
        heroes.Remove("gosho");

       Assert.That(heroes.Heroes.Count, Is.EqualTo(0));
    }
    [Test]
    public void RemoveMethodShouldThrowsExceptionWhenNameIsNullOrWhitespace()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);
        heroes.Create(hero);
       
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Remove(null);
        });
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Remove("");
        });
    }

    [Test]
    public void GetHeroWithHighestLevelMethodShouldReturnHighestHeroLevel()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);
        Hero hero2 = new Hero("pesho", 15);
        Hero hero3 = new Hero("saho", 20);
        Hero hero4 = new Hero("stavri", 2);

        heroes.Create(hero);
        heroes.Create(hero2);
        heroes.Create(hero3);
        heroes.Create(hero4);

       var heroLevel = heroes.GetHeroWithHighestLevel();

        Assert.AreEqual(hero3, heroLevel);
    }
    [Test]
    public void GetHeroShouldReturnHeroByName()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("gosho", 1);
        Hero hero2 = new Hero("pesho", 15);
        Hero hero3 = new Hero("saho", 20);
        Hero hero4 = new Hero("stavri", 2);

        heroes.Create(hero);
        heroes.Create(hero2);
        heroes.Create(hero3);
        heroes.Create(hero4);

        var getHero = heroes.GetHero("gosho");

        Assert.AreEqual(hero, getHero);
    }
    [Test]
    public void HeroCtorShouldCreateHero()
    {
        Hero hero = new Hero("stavri", 5);
        Assert.AreEqual("stavri", hero.Name);
        Assert.AreEqual(5,hero.Level);
    }
}