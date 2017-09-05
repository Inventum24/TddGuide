using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class MockingMethods
    {
        [Test]
        public void TestMockingMethods()
        {
            var mock = new Mock<IFoo>();
            //mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            mock.Setup(foo => foo.DoSomething(It.IsIn("pong","foo"))).Returns(true);

            var a = mock.Object.DoSomething("foo");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.DoSomething("pong"));
                Assert.IsTrue(mock.Object.DoSomething("foofake"));
            });
        }
    }
}
