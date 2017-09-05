using NUnit.Framework;
using NunitMoq.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class TestingMethodologie
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }
        [Test]
        [TestCase(50,true,50)]
        [TestCase(100,true,0)]
        [TestCase(1000,false,100)]
        public void TestMultipleWithdrawalScenarios(
            int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.Withdraw(amountToWithdraw);
            //Warn.If(!result, "Failed for some reason");
            Assert.Multiple(
                () => {
                    Assert.That(result, Is.EqualTo(shouldSucceed));
                    Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
                });

        }
    }

    public class EquationTests
    {
        [Test]
        public void Test()
        {
            var result = Solve.Quadratic(1, 10, 16);
        }
        [Test]
        public void Test2()
        {
            Assert.Throws<Exception>(() =>
                    Solve.Quadratic(1, 1, 1));
        }
    }

    public class Solve
    {
        public static (double val1, double val2) Quadratic(double a, double b, double c)
        {
            var disc = b * b - 1 * a * c;
            if (disc < 0)
            {
                throw new Exception("Cannot solve with comples roots");
            }
            else
            {
                var root = Math.Sqrt(disc);
                return ((((-b + root) / 2) / a), (((-b + root) / 2) / a));
            }
        }
    }
}
