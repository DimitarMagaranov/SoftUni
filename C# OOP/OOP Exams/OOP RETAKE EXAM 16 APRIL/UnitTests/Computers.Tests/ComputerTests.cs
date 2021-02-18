namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfPartCtorWorksCorrectly()
        {
            string partName = "Part1";
            decimal price = 100;

            Part part = new Part(partName, price);

            Assert.That(partName == part.Name);
            Assert.That(price == part.Price);
        }

        [Test]
        public void TestIfComputerCtorWorksCorrectly()
        {
            string expName = "Pesho";
            Computer computer = new Computer(expName);

            Assert.That(expName == computer.Name);
            Assert.IsNotNull(computer.Parts);
        }

        [Test]
        public void TestIfPartsWorkCorrectly()
        {
            Computer computer = new Computer("Pesho");

            Assert.IsNotNull(computer.Parts);
        }

        [Test]
        public void NameSetterThrowsException()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() => new Computer(name));

        }

        [Test]
        public void NameGetterWorksCorrectly()
        {
            Computer computer = new Computer("Pesho");

            string expName = "Pesho";

            Assert.That(expName == computer.Name);
        }

        [Test]
        public void TestIfTotalPriceWorksCorrectly()
        {
            Computer computer = new Computer("Pesho");

            Part part1 = new Part("Part1", 100);
            Part part2 = new Part("Part1", 69);

            decimal expPrice = computer.TotalPrice;

            Assert.That(expPrice == computer.TotalPrice);
        }

        [Test]
        public void TestIfAddPartWorksCorrectly()
        {
            Computer computer = new Computer("Pesho");

            Part part1 = new Part("Part1", 100);

            computer.AddPart(part1);

            Part expPart = computer.GetPart(part1.Name);

            Assert.That(part1 == expPart);
        }

        [Test]
        public void TEstIfAddPartThrowsException()
        {
            Computer computer = new Computer("Pesho");

            Part part1 = null;

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(part1));
        }

        [Test]
        public void TestIfRemovePartWorksCorrectly()
        {
            Computer computer = new Computer("Pesho");

            Part part1 = new Part("Part1", 100);

            computer.AddPart(part1);

            Assert.That(computer.RemovePart(part1) == true);
        }

        [Test]
        public void TestIfRemoveReturnsFalse()
        {
            Computer computer = new Computer("Pesho");

            Part part1 = new Part("Part1", 100);

            Assert.That(computer.RemovePart(part1) == false);
        }

        [Test]
        public void test()
        {
            Computer computer = new Computer("Pesho");

            Assert.That(computer.GetPart("asdas") == null);
        }
    }
}