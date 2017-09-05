using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    public abstract class Person
    {
        protected int SSN { get; set; }
        protected abstract void Exectute(string msg);
    }
    [TestFixture]
    public class ExpectationsForProtectedMembers
    {
        [Test]
        public void MyMethod()
        {
            var mock = new Mock<Person>();
            mock.Protected().SetupGet<int>("SSN").Returns(42);
            mock.Protected().Setup<string>("Execute", ItExpr.IsAny<string>()).Returns("A");
        }
    }
}
