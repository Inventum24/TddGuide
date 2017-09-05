using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    public class Consumer
    {
        private IFoo foo;

        public Consumer(IFoo foo)
        {
            this.foo = foo;
        }

        public void Hello()
        {
            foo.DoSomething("ping");
            var name = foo.Name;
            foo.SomeOtherProperty = 123;
        }
    }

    [TestFixture]
    public class VerificationTest
    {
        [Test]
        public void Verification()
        {
            var mock = new Mock<IFoo>();
            var consumer = new Consumer(mock.Object);

            consumer.Hello(); // When that is commented we have a error.
            mock.Verify(foo => foo.DoSomething("ping"), Times.AtLeastOnce);
            mock.Verify(foo => foo.DoSomething("ping"), Times.Never);
            mock.VerifyGet(foo => foo.Name);
            mock.VerifySet(foo => foo.SomeOtherProperty = It.IsInRange(100, 200, Range.Exclusive));

        }
    }
}
