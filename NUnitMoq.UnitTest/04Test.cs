
using NUnit.Framework;
using NunitMoq.Lib;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
//using ImpromptuInterface;

namespace NunitMoq.UnitTest
{
    //FAKE!!!
    public class NullLog : NunitMoq.Lib.ILog
    {
        public bool Write(string msg)
        {
            return true;
        }
    }

    //Stube!!! It is configureable
    public class NullLogStube : NunitMoq.Lib.ILog
    {
        private bool expectedResult;
        public NullLogStube(bool expectedResult)
        {
            this.expectedResult = expectedResult;
        }
        public bool Write(string msg)
        {
            return expectedResult;
        }
    }

    //No Work
    //public class Null<T> : DynamicObject where T : class
    //{
    //    public static T Instance => new Null<T>().ActLike<T>();
    //    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {

    //        result = Activator.CreateInstance(typeof(T).GetMethod(binder.Name).ReturnType);
    //        return true;

    //        //return base.TryInvokeMember(binder, args, out result);
    //    }
    //}

    [TestFixture]
    public class BankAccount2Test
    {
        private BankAccount2 ba;
        [Test]
        public void DepositIntegrationTest()
        {
            ba = new BankAccount2(new ConsoleLog()) { Balance = 100 };
            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));
        }

        [Test]
        public void DepositUnitTestWithFake()
        {
            var log = new NullLog();
            ba = new BankAccount2(new NullLog()) { Balance = 100 };
            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));

        }

        //[Test]
        //public void DepositUnitTestWithDynamicFake()
        //{
        //    var log =  Null<ILog>.Instance;
        //    ba = new BankAccount2(new NullLog()) { Balance = 100 };
        //    ba.Deposit(100);
        //    Assert.That(ba.Balance, Is.EqualTo(200));
        //}

        [Test]
        public void DepositUnitTestWithStub()
        {
            var log = new NullLogStube(true);
            ba = new BankAccount2(log) { Balance = 100 };
            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));
        }
    }
}
