using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class BehaviorCustomizationTest
    {
        [Test]
        public void BehaviorCustomization()
        {
            //Causes the mock to always throw an exception for invocations that don't have a corresponding setup.
            var mock = new Mock<IFoo>(MockBehavior.Strict);

            mock.Setup(f => f.DoSomething("abch")).Returns(true);
            mock.Object.DoSomething("abc");
        }

        [Test]
        public void BehaviorCustomization2()
        {
            //Causes the mock to always throw an exception for invocations that don't have a corresponding setup.
            var mock = new Mock<IFoo> { DefaultValue = DefaultValue.Mock };

            var baz = mock.Object.SomeBaz;
            var bazMock = Moq.Mock.Get(baz); //Recurs!!!
            bazMock.SetupGet(f => f.Name).Returns("abc");

            var mockRepository = new MockRepository(MockBehavior.Strict)
            {
                DefaultValue = DefaultValue.Mock
            };

            var fooMock = mockRepository.Create<IFoo>();
            var otherMock = mockRepository.Create<IBaz>();

            //mockRepository.Verify() //Verify diffrent mocks!!!
        }
    }
}
