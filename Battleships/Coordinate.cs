using System;

namespace Battleships
{
    internal class Coordinate
    {
        public readonly int row;
        public readonly int col;

        internal Coordinate(string coord)
        {
            var coords = coord.Split(':');
            if (coords.Length != 2)
                throw new ArgumentException($"Coordinate {coord} badly formatted");

            row = int.Parse(coords[0]);
            col = int.Parse(coords[1]);
        }
    }
}
