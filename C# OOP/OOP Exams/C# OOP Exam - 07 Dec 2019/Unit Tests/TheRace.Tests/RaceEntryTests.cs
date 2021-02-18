using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddRider_Should_AddSuccessfully()
        {
            //Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Kawasaki", 50, 300);
            UnitRider unitRider = new UnitRider("Ivan", unitMotorcycle);

            //Act
            string actualMessage = raceEntry.AddRider(unitRider);

            //Assert
            string expectedMessage = "Rider Ivan added in race.";
            Assert.That(actualMessage == expectedMessage);
            Assert.That(raceEntry.Counter == 1);
        }

        [Test]
        public void AddRider_Should_Throw_Exception_If_Rider_Is_Null()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitRider unitRider = null;

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider));

            //Assert.That(exception.Message == "Rider cannot be null.");
        }

        [Test]
        public void AddRider_Should_Throw_Exception_If_Rider_Is_AlreadyAdded()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Kawasaki", 50, 300);
            UnitRider unitRider = new UnitRider("Ivan", unitMotorcycle);

            raceEntry.AddRider(unitRider);

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider));

            //Assert.That(exception.Message == "Rider Ivan is already added.");
        }

        [Test]
        public void CalculateAverageHorsePower_Should_Return_Average_HorsePower_Of_All_Participants()
        {
            //Dictionary<string, UnitRider> participants = new Dictionary<string, UnitRider>();

            RaceEntry raceEntry = new RaceEntry();

            UnitRider unitRider1 = new UnitRider("Ivan", new UnitMotorcycle("Kawasaki", 60, 300));
            UnitRider unitRider2 = new UnitRider("Mitko", new UnitMotorcycle("Honda", 24, 300));

            raceEntry.AddRider(unitRider1);
            raceEntry.AddRider(unitRider2);
            
            var result = raceEntry.CalculateAverageHorsePower();
            var expectedResult = 42;

            Assert.That(result == expectedResult);
        }

        [Test]
        public void CalculateAverageHorsePower_Should_Throw_Exception()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitRider unitRider1 = new UnitRider("Ivan", new UnitMotorcycle("Kawasaki", 60, 300));

            raceEntry.AddRider(unitRider1);

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

            //Assert.That(exception.Message == "The race cannot start with less than 2 participants.");
        }
    }
}