using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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

        [Test]
        public void ParsesInput()
        {
            // Arrange
            var input = "A1";

            // Act
            var result = _sut.ParseInput(input);

            // Assert
            Assert.AreEqual(result.Column,0);
            Assert.AreEqual(result.Row,0);
        }

        [Test]
        public void ParsesInputLowerCase()
        {
            // Arrange
            var input = "j10";

            // Act
            var result = _sut.ParseInput(input);

            // Assert
            Assert.AreEqual(result.Column, 9);
            Assert.AreEqual(result.Row, 9);
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
