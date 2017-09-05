using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    [TestFixture]
    public class MockingPropertiesBasics
    {
        [Test]
        public void MockingPropertiesBasics_01() {

            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.Name)
                .Returns("bar");

            mock.Object.Name = "will not be assigned";

            Assert.That(mock.Object.Name, Is.EqualTo("bar"));

            mock.Setup(foo => foo.SomeBaz.Name).Returns("hello");
            Assert.That(mock.Object.SomeBaz.Name, Is.EqualTo("hello"));

            bool setterCalled = false;
            mock.SetupSet(foo =>
            {
                foo.Name = It.IsAny<string>();
            })//Set setter!!!
            .Callback<string>(value => {
                setterCalled = true;
            });

            mock.Object.Name = "def"; //Now it is set.

            mock.VerifySet(foo => {
                foo.Name = "def";
            }, Times.AtLeastOnce); //Check a prop - Name !!!
            
        }
    }
}
