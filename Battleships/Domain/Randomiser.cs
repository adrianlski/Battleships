using System;
using Battleships.Interfaces;

namespace Battleships.Domain
{
    public class Randomiser : IRandomiser
    {
        private readonly Random _random;

        public Randomiser()
        {
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        public int GetRandomValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}