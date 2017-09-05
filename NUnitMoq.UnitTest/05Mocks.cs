using NUnit.Framework;
using NunitMoq.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    public class LogMock : NunitMoq.Lib.ILog
    {

        private bool expectedResult;
        public Dictionary<string, int> MethodCallCount;

        public LogMock(bool expectedResult)
        {
            this.expectedResult = expectedResult;
            MethodCallCount = new Dictionary<string, int>();
        }
        private void AddOrIncrement(string methodName)
        {
            if (MethodCallCount.ContainsKey(methodName)) MethodCallCount[methodName]++;
            else MethodCallCount.Add(methodName, 1);
        }
        public bool Write(string msg)
        {
            AddOrIncrement(nameof(Write));
            Console.WriteLine(msg);

            return expectedResult;

        }
    }

    [TestFixture]
    public class BankAccountTestWithMock
    {
        private BankAccount2 bawm;

        [Test]
        public void DepositTestWithMock()
        {
            var log = new LogMock(true);
            bawm = new BankAccount2(log) { Balance = 100 };
            bawm.Deposit(100);

            Assert.Multiple(() =>
            {
                Assert.That(bawm.Balance, Is.EqualTo(200));
                Assert.That(log.MethodCallCount[nameof(LogMock.Write)], Is.EqualTo(1));
            });

        }
    }
}
