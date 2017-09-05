using Moq;
using NUnit.Framework;
using NunitMoq.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    public interface ILog
    {
        bool Write(string msg);
    }
    public class BankAccountWithMock
    {
        public int Balance { get; set; }

        private ILog log;

        public BankAccountWithMock(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            log.Write($"User has withdrawn {amount}");
            Balance += amount;
        }
    }

    [TestFixture]
    public class BankAccountMoqTests
    {
        private BankAccountWithMock ba;

        [Test]
        public void DepositIntegrationTest()
        {
            var log = new Mock<ILog>();
            ba = new BankAccountWithMock(log.Object) { Balance = 100 };

            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));


        }
    }



}
