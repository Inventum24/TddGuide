using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class MockingMethodsExceptionsAndReturnValues
    {
        [Test]
        public void MockingMethodsExceptionsAndReturnValues1()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.ProcessString(It.IsAny<string>()))
                .Returns((string s) => s.ToLower());

            Assert.Multiple(() =>
            {
                Assert.That(mock.Object.ProcessString("ABC"), Is.EqualTo("abc"));
            });
        }

        [Test]
        public void MockingMethodsExceptionsAndReturnValues2()
        {
            var mock = new Mock<IFoo>();
            var calls = 0;
            mock.Setup(foo => foo.GetCount())
                .Returns(() => calls)
                .Callback(() => ++calls);

            mock.Object.GetCount();
            mock.Object.GetCount();


            Assert.Multiple(() =>
            {
                Assert.That(mock.Object.GetCount(), Is.EqualTo(2));
            });
        }

        [Test]
        public void MockingMethodsExceptionsAndReturnValues3()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("Kill"))
                .Throws<InvalidOperationException>();

            Assert.Throws<InvalidOperationException>(()=> mock.Object.DoSomething("Kill"));
        }

        [Test]
        public void MockingMethodsExceptionsAndReturnValues4()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething(null))
                .Throws(new ArgumentException("cmd"));

            Assert.Throws<ArgumentException>(() => { mock.Object.DoSomething(null); },"cmd");
        }
    }
}
