namespace StorageMaster.Tests.Structure.Vehicles.Tests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Linq;

    public class TruckTests
    {
        private Vehicle truck;

        [SetUp]
        public void Setup()
        {
            this.truck = new Truck();
        }

        [Test]
        public void LoadProductMethodSholdWorkCorrectly()
        {
            Product product = new Ram(2.57);

            this.truck.LoadProduct(product);

            int expectedCount = 1;

            Product expectedProduct = this.truck.Trunk.Last();

            Assert.That(expectedProduct, Is.EqualTo(product));
            Assert.That(expectedCount, Is.EqualTo(this.truck.Trunk.Count));
        }

        [Test]
        public void LoadProductMethodSholdThrowExeption()
        {
            Product product = new Ram(2.57);

            int expectedCount = 50;

            Assert.That(expectedCount, Is.EqualTo(this.truck.Trunk.Count));
            Assert.Throws<InvalidOperationException>(() => this.truck.LoadProduct(product));
        }

        [Test]
        public void UnloadProductMethodSholdWorkCorrectly()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.50);

            this.truck.LoadProduct(lastProduct);

            Product unloadProduct = this.truck.Unload();

            int expectedCount = 5;

            Assert.That(expectedCount == this.truck.Trunk.Count);
            Assert.That(unloadProduct == lastProduct);
        }

        [Test]
        public void UnloadProductMethodSholdThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => this.truck.Unload());
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            Assert.That(true, Is.EqualTo(this.truck.IsEmpty));
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            this.truck.LoadProduct(new SolidStateDrive(3));

            Assert.That(false, Is.EqualTo(this.truck.IsEmpty));
        }

        [Test]
        public void IsFullMethodReturnsTrue()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 50; i++)
            {
                this.truck.LoadProduct(product);
            }

            Assert.That(true, Is.EqualTo(this.truck.IsFull));
        }

        [Test]
        public void IsFullMethodReturnsFalse()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 49; i++)
            {
                this.truck.LoadProduct(product);
            }

            Assert.That(false, Is.EqualTo(this.truck.IsFull));
        }

        [Test]
        public void CapacityIsSetCorrectly()
        {
            Assert.That(5, Is.EqualTo(this.truck.Capacity));
        }
    }
}
