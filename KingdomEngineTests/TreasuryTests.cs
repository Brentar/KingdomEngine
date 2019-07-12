using System;
using KingdomEngine;
using KingdomEngine.Interfaces;
using KingdomEngine.Logic;
using KingdomEngine.Utility;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class TreasuryTests
    {
        private ITreasury treasury;
        private const int InitialGold = 100;

        [SetUp]
        public void SetUp()
        {
            treasury = new Treasury(InitialGold);
        }

        [TestCase(100, 200)]
        [TestCase(0, 100)]
        public void Deposit(int amount, int expectedGold)
        {
            treasury.Deposit(amount);
            Assert.That(treasury.Gold, Is.EqualTo(expectedGold));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Deposit_Throws_OutOfRange(int gold)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => treasury.Deposit(gold));
        }

        [TestCase(80, 20)]
        [TestCase(0, 100)]
        public void Withdraw(int amount, int expectedGold)
        {
            treasury.Withdraw(amount);
            Assert.That(treasury.Gold, Is.EqualTo(expectedGold));
        }

        [TestCase(500)]
        [TestCase(101)]
        public void Withdraw_Throws_NotEnoughGold(int amount)
        {
            Assert.Throws<NotEnoughGoldException>(() => treasury.Withdraw(amount));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Withdraw_Throws_OutOfRange(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => treasury.Withdraw(amount));
        }
    }
}
