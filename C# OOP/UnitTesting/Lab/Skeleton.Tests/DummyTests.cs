using FluentAssertions;
using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LoseHealth()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);

            //Assert
            dummy.Health.Should().Be(5);
        }

        [Test]
        public void DeadDummy()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void GiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);

            //Act
            int experience = dummy.GiveExperience();

            //Assert
            experience.Should().Be(10);
        }

        [Test]
        public void CantGiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(2, 10);

            //Act
            int experience = dummy.GiveExperience();

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
