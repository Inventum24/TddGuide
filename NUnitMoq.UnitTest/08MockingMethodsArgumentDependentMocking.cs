using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class MockingMethodsArgumentDependentMocking
    {
        [Test]
        public void ArgumentDependentMatching()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(false);

            mock.Setup(foo => foo.Add(It.Is<int>(x => x % 2 == 0))).Returns(true);

            mock.Setup(foo => foo.Add(It.IsInRange<int>(1, 10, Range.Inclusive))).Returns(false);

            mock.Setup(foo => foo.DoSomething(It.IsRegex("[a-z]+")));

            mock.Object.DoSomething("123");
        }

    }
}
