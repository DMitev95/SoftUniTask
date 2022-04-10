namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void CotrDataProperly()
        {
            Warrior warrior = new Warrior("gosho", 100, 100);
            Assert.AreEqual(warrior.Name,"gosho");
            Assert.AreEqual(warrior.HP, 100);
            Assert.AreEqual(warrior.Damage, 100);
            warrior = new Warrior("gosho", 1, 0);
            Assert.AreEqual(warrior.Name, "gosho");
            Assert.AreEqual(warrior.HP, 0);
            Assert.AreEqual(warrior.Damage, 1);
        }
        [Test]
        public void CotrInvalidProperly()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 100, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 100, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("", 100, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("gosho", 0, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("gosho", -1, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("gosho", 50, -1));
        }
        [Test]
        public void FightInvalidData()
        {
            Warrior attaker = new Warrior("gosho", 50, 5);
            Warrior deffender = new Warrior("pesho",50,50);
            Assert.Throws<InvalidOperationException>(() => attaker.Attack(deffender));
            attaker = new Warrior("gosho", 50, 100);
            deffender = new Warrior("pesho", 50, 5);
            Assert.Throws<InvalidOperationException>(() => attaker.Attack(deffender));
            attaker = new Warrior("gosho", 50, 50);
            deffender = new Warrior("pesho", 100, 100);
            Assert.Throws<InvalidOperationException>(() => attaker.Attack(deffender));
        }
        [Test]
        public void FightValidData()
        {
            Warrior attaker = new Warrior("gosho", 101, 100);
            Warrior deffender = new Warrior("pesho", 60, 100);
            attaker.Attack(deffender);
            Assert.AreEqual(40, attaker.HP);
            Assert.AreEqual(0, deffender.HP);
            attaker = new Warrior("gosho", 50, 100);
            deffender = new Warrior("pesho", 50, 100);
            attaker.Attack(deffender);
            Assert.AreEqual(50, attaker.HP);
            Assert.AreEqual(50, deffender.HP);
        }
    }
}