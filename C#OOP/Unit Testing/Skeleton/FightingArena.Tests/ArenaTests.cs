namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CotrValidData()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Warriors.Count,arena.Count);
            Assert.AreEqual(0, arena.Count);
        }
        [Test]
        public void EnrrolAddWarriorValidData()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("gosho", 100, 100);
            arena.Enroll(warrior);
            Assert.AreEqual(1,arena.Count);
            Assert.True(arena.Warriors.Any(x => x.Name == "gosho"));
        }
        [Test]
        public void EnrrolAddWarriorInvalidData()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("gosho", 100, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
        [Test]
        public void FightReduceHpWalidData()
        {
            Arena arena = new Arena();
            Warrior attaker = new Warrior("gosho", 101, 100);
            Warrior deffender = new Warrior("pesho", 60, 100);
            arena.Enroll(attaker);
            arena.Enroll(deffender);
            arena.Fight("gosho", "pesho");
            Assert.AreEqual(40, attaker.HP);
            Assert.AreEqual(0, deffender.HP);
        }
        [Test]
        public void FightThrowException()
        {
            Arena arena = new Arena();            
            Assert.Throws<InvalidOperationException>(() => arena.Fight("gosho", "pesho"));
            arena.Enroll(new Warrior("gosho",100,100));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("gosho", "pesho"));
        }
    }
}
