using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class CallbacksTest
    {
        [Test]
        public void Callbacks()
        {
            var mock = new Mock<IFoo>();
            int x = 0;
            mock.Setup(f => f.DoSomething("pin"))
                .Returns(true)
                .Callback(() => x++);
            mock.Object.DoSomething("ping");

            Assert.That(x, Is.EqualTo(1));

            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(true)
                .Callback<string>((s) => x += s.Length);
            //.Callback((string s) => x += s.Length);

            mock.Setup(foo => foo.DoSomething("pong"))
                .Callback(() => Console.WriteLine("before return"))
                .Returns(false)
                .Callback(() => Console.WriteLine("after return"));

            mock.Object.DoSomething("pong");


        }

    }
}
