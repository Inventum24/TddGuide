using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.UnitTest
{
    public delegate void AlienAbductionEventHandler(int galaxy, bool returned);
    public interface IAnimal {
        event EventHandler FallsIll;
        void Stuble();

        event AlienAbductionEventHandler AbductionByAliens;
    }
    public class Doctor
    {
        public int TimesCured;
        public int AbductionsObserved;
        public Doctor(IAnimal animal)
        {
            animal.FallsIll += (s, e) => {
                Console.WriteLine("cure you!");
                TimesCured++;
            };
        }

    }
    [TestFixture]
    public class Mock
    {
        [Test]
        public void MockingEvents()
        {
            var mock = new Mock<IAnimal>();
            var doctor = new Doctor(mock.Object);

            mock.Raise(
                a => a.FallsIll += null,
                new EventArgs());

            Assert.That(doctor.TimesCured, Is.EqualTo(1));

            mock.Setup(a => a.Stuble())
                .Raises(
                 a => a.FallsIll += null,
                 new EventArgs());

            mock.Object.Stuble();

            Assert.That(doctor.TimesCured, Is.EqualTo(2));

            mock.Raise(a => a.AbductionByAliens += null, 42, true);
            Assert.That(doctor.AbductionsObserved, Is.EqualTo(1));

        }
    }
}
