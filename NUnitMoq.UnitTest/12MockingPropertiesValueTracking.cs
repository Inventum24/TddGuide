using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class MockingPropertiesValueTrackingTest
    {
        [Test]
        public void MockingPropertiesValueTracking()
        {
            var mock = new Mock<IFoo>();

            //mock.SetupAllProperties();
            mock.SetupProperty(f => f.Name);

            IFoo foo = mock.Object;
            foo.Name = "abc";
            Assert.That(mock.Object.Name, Is.EqualTo("abc"));

            foo.SomeOtherProperty = 123;
            Assert.That(mock.Object.SomeOtherProperty, Is.EqualTo(123));
        }
    }
}
