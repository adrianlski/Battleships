using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Domain;

namespace Battleships.Test.Unit
{
    [TestFixture]
    class CoordinateParserTests
    {
        private CoordinateParser _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CoordinateParser();
        }

        [TestCase("A1", 0, 0)]
        [TestCase("j10", 9, 9)]
        public void ParsesInput(string input, int expectedColumn, int expectedRow)
        {
            // Act
            var result = _sut.ParseInput(input);

            // Assert
            Assert.AreEqual(result.Column, expectedColumn);
            Assert.AreEqual(result.Row, expectedRow);
        }

        [Test]
        public void ThrowsExceptionWhenInputInvalid()
        {
            // Arrange
            var input = "sdfdsf";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.ParseInput(input));

        }

        [Test]
        public void ThrowsExceptionWhenCoordinatesOutOfBound()
        {
            // Arrange
            var input = "K20";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.ParseInput(input));

        }
    }
}
