using NUnit.Framework;
using SomeRandomService;
using SomeRandomService.Extension;
using SomeRandomService.Models;
using System;

namespace SomeRandomTesting
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [TestCase(4, 2, true)]
        [TestCase(10, 100, false)]
        public void IsGreaterThanShouldTest(int value, int secondValue, bool expected)
        {
            //Act
            var result = value.IsGreaterThan(secondValue);

            //Asert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateToStringTest()
        {
            //Arrange
            DateTime mockDate = DateTime.UtcNow;

            //Act
            var result = mockDate.DateToString();

            //Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void ChunkByTest()
        {
            //Arrange
            var bigList = ImStaticClass.GenerateRandomlists(1000);
            var expected = 10;
            //Act
            var result = bigList.ChunkBy(100);

            //Assert
            Assert.AreEqual(expected, result.Count);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetFullNameTest()
        {
            //Arrange
            var mockPerson = new Person
            {
                Curp = Guid.NewGuid(),
                Name = "Jesus",
                LastName = "Ortega",
                BirthDay = DateTime.Parse("05-08-1989")
            };

            //Act
            var result = mockPerson.GetFullName();

            //Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void CalculateAgeTest()
        {
            //Arrange
            var mockPerson = new Person
            {
                Curp = Guid.NewGuid(),
                Name = "Jesus",
                LastName = "Ortega",
                BirthDay = DateTime.Parse("05-08-1989")
            };
            var expected = 32;

            //Act
            var result = mockPerson.CalculateAge();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
