namespace StorageMaster.Tests.Structure.Vehicles.Tests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Linq;

    public class VanTests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProductMethodSholdWorkCorrectly()
        {
            Product product = new Ram(2.57);

            this.van.LoadProduct(product);
               
            int expectedCount = 1;

            Product expectedProduct = this.van.Trunk.Last();

            Assert.That(expectedProduct, Is.EqualTo(product));
            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
        }

        [Test]
        public void LoadProductMethodSholdThrowExeption()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }

            int expectedCount = 20;

            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void UnloadProductMethodSholdWorkCorrectly()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.van.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.50);

            this.van.LoadProduct(lastProduct);

            Product unloadProduct = this.van.Unload();

            int expectedCount = 5;

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.That(unloadProduct == lastProduct);
        }

        [Test]
        public void UnloadProductMethodSholdThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            Assert.That(true, Is.EqualTo(this.van.IsEmpty));
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            this.van.LoadProduct(new SolidStateDrive(3));

            Assert.That(false, Is.EqualTo(this.van.IsEmpty));
        }

        [Test]
        public void IsFullMethodReturnsTrue()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }

            Assert.That(true, Is.EqualTo(this.van.IsFull));
        }

        [Test]
        public void IsFullMethodReturnsFalse()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 19; i++)
            {
                this.van.LoadProduct(product);
            }

            Assert.That(false, Is.EqualTo(this.van.IsFull));
        }

        [Test]
        public void CapacityIsSetCorrectly()
        {
            Assert.That(2, Is.EqualTo(this.van.Capacity));
        }
    }
}