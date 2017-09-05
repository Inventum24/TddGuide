using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class MockingMethodsOutAndRefParameters
    {
        [Test]
        public void OutAndRefArguments()
        {
            var mock = new Mock<IFoo>();
            var requiredOutput = "ok";
            mock.Setup(foo => foo.TryParse("ping", out requiredOutput)).Returns(true);
            string result;
            Assert.Multiple(() => {
                Assert.IsTrue(mock.Object.TryParse("ping", out result));
                Assert.That(result, Is.EqualTo(requiredOutput));

                var thisShouldBeFalse = mock.Object.TryParse("pong", out result);
                Console.WriteLine(thisShouldBeFalse); ;
                Console.WriteLine(result);
            });

            var bar = new Bar() { Name = "abc"};
            mock.Setup(foo => foo.Submit(ref bar)).Returns(true);

            Assert.That(mock.Object.Submit(ref bar), Is.EqualTo(true));

            var someOtherBar = new Bar() { Name = "abc" };
            Assert.IsFalse(mock.Object.Submit(ref someOtherBar)); //False Here is other ref to Bar!!!
        }

        
    }
}
