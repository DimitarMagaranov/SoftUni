namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class PresentsTests
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestIfPresentCtorWorksCorrectly()
        {
            string expectedName = "Stick";
            double expectedMagic = 100;

            Present present = new Present(expectedName, expectedMagic);

            Assert.AreEqual(expectedName, present.Name);
            Assert.AreEqual(expectedMagic, present.Magic);
        }

        [Test]
        public void TestBagCtorWorksCorrectly()
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag.GetPresents());
        }

        [Test]
        public void CreateShouldThrowArgumentNullException()
        {
            Present present = null;

            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CreateShouldThrowExceptionWithLikeExistingPresent()
        {
            Bag bag = new Bag();

            Present present = new Present("Stick", 100);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateShouldCreateSuccessfully()
        {
            Bag bag = new Bag();

            Present expectedPresent = new Present("Stick", 100);

            bag.Create(expectedPresent);

            Present present = bag.GetPresent(expectedPresent.Name);

            Assert.That(expectedPresent == present);
        }

        [Test]
        public void GetPresentWithLeastMagicWorksCorrectly()
        {
            Bag bag = new Bag();

            bag.Create(new Present("Stick", 100));
            bag.Create(new Present("Ball", 99));

            Present expPresent = new Present("Ball", 99);

            Present presentWithLeastMagic = bag.GetPresentWithLeastMagic();

            Assert.That(expPresent.Name == presentWithLeastMagic.Name
                        && expPresent.Magic == presentWithLeastMagic.Magic);
        }

        [Test]
        public void RemovePresentWorksCorrectly()
        {
            Bag bag = new Bag();

            Present expPresent = new Present("Ball", 99);

            bag.Create(expPresent);

            Assert.That(bag.Remove(expPresent) == true);
        }
    }
}
