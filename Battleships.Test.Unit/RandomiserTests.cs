using Battleships.Domain;
using Battleships.Interfaces;
using NUnit.Framework;

namespace Battleships.Test.Unit
{
    [TestFixture]
    public class RandomiserTests
    {
        private IRandomiser _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Randomiser();
        }

        [TestCase(0, 9)]
        [TestCase(1,2)]
        public void GetRandomValueReturnValueWithinRange(int min, int max)
        {
            // Act
            var number = _sut.GetRandomValue(min, max);

            // Assert
            Assert.IsTrue(number >= min && number <= max);
        }
    }
}