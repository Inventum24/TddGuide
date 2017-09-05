
using NUnit.Framework;
using NunitMoq.Lib;
using System;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }
        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            //AAA
            //arange
            //var ba = new BankAccount(100); // ==> SetUp();


            //act
            ba.Deposit(100);
            //assert
            Assert.That(ba.Balance, Is.EqualTo(200));

        }

        [Test]
        public void Multiple()
        {
            ba.Withdraw(100);

            //Assert.That(ba.Balance, Is.EqualTo(0));
            //Assert.That(ba.Balance, Is.EqualTo(1));

           Assert.Multiple(() =>
           {
               Assert.That(ba.Balance, Is.EqualTo(10));
               Assert.That(ba.Balance, Is.EqualTo(11));
           });
        }

        [Test]
        public void BankAccountShouldThrowOnNonPositiveAmount()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => ba.Deposit(-1)
                );

            StringAssert.StartsWith("Deposite amount must be positive", ex.Message );
        }

        /*
         *
         */

        [Test]
        public void Asserts()
        {
            //Assert.Inconclusive("Inconclusive");//Throw InconclusiveException
            Assert.That(2 + 2, Is.EqualTo(4));
            Assert.Warn("This is not good");
        }
        [Test]
        public void Warnings()
        {
            // Use Warn with reversed condition
            Warn.If(2 + 2 != 5);
            Warn.If(2 + 2, Is.Not.EqualTo(5));
            Warn.If(() =>  2 + 2, Is.Not.EqualTo(5).After(20000));

            // Use Warn with original condition
            Warn.Unless(2 + 2 == 5);
            Warn.Unless(2+2, Is.EqualTo(5).After(20000));
            Warn.Unless(() => 2 + 2, Is.EqualTo(5).After(20000));
        }
    }

}
