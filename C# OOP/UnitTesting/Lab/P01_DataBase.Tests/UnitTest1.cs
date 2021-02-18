using NUnit.Framework;
using P01_DataBase;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void SeTup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodShouldThrowExeptionWithInvalidParameter()
        {
            for (int i = 0; i < 10; i++)
            {
                this.database.Add(45);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(45));
        }
        
        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Add(45);
            }

            Assert.That(11, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void RemoveMethodShouldThrowExeptionIfThereIsNoElementsInDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            this.database.Remove();

            Assert.That(5, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShouldInitializedCorrectly()
        {
            this.database = new Database(1, 2, 3, 5);

            Assert.That(4, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShouldThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[17]));
            Assert.Throws<InvalidOperationException>(() => new Database(new int[0]));
        }

        [Test]
        public void PropertyDatabaseShouldSetCorrectly()
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(collection, this.database.DatabaseElements);
        }

        [Test]
        public void PropertyDatabaseShouldGetCorrectly()
        {
            int expectedCount = 6;

            Assert.That(expectedCount, Is.EqualTo(this.database.DatabaseElements.Length));
        }
    }
}