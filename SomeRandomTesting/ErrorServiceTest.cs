using NUnit.Framework;
using SomeRandomService;
using System;

namespace SomeRandomTesting
{
    public class ErrorServiceTests
    {
        private ErrorService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new ErrorService();
        }

        [Test]
        public void GetDayOfTheWeekByIndexWhenTheIndexDoesNotExistsThenShouldReturnEmptyString()
        {
            //Arrange 
            string expected = "";

            //Act
            string result = _sut.GetDayOfTheWeekByIndex(10);

            //Asert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DivisionWhenDivideByZeroThenThrowAnException()
        {
            //Arrange 
            int expected = 0;

            //Act
            double result = _sut.Division(10, 0);

            //Asert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetIntWhenTheIndexDoesNotExistThenThrowAnException()
        {
            //Arrange 
            int[] mock = { 1, 2, 3, 4, 5 };

            //Asert
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.GetInt(mock, 5));
        }
    }
}