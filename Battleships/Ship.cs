using System;

namespace Battleships
{
    internal class Ship
    {
        public Coordinate coordinate0;
        public Coordinate coordinate1;

        internal Ship(string shipString)
        {
            var coords = shipString.Split(',');
            if (coords.Length != 2)
                throw new ArgumentException($"Ship {shipString} badly formatted");

            coordinate0 = new Coordinate(coords[0]);
            coordinate1 = new Coordinate(coords[1]);

            if (coordinate0.row != coordinate1.row && coordinate0.col != coordinate1.col)
                throw new ArgumentException($"Ship {shipString} is the wrong shape");

        }

        internal bool IsHit(Coordinate testCoordinate)
        {
            return IsBetween(coordinate0.row, coordinate1.row, testCoordinate.row)
                && IsBetween(coordinate0.col, coordinate1.col, testCoordinate.col);
        }
        private bool IsBetween(int value1, int value2, int testValue)
        {
            return ((testValue >= value1 && testValue <= value2) 
                 || (testValue >= value2 && testValue <= value1));
        }
    }
}
