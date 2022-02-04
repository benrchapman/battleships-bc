using System;

namespace Battleships
{
    internal class Ship
    {
        private readonly Coordinate coordinate0;
        private readonly Coordinate coordinate1;
        private bool isSunk;

        internal Ship(string shipString)
        {
            isSunk = false;

            var coords = shipString.Split(',');
            if (coords.Length != 2)
                throw new ArgumentException($"Ship {shipString} badly formatted");

            coordinate0 = new Coordinate(coords[0]);
            coordinate1 = new Coordinate(coords[1]);

            if (coordinate0.row != coordinate1.row && coordinate0.col != coordinate1.col)
                throw new ArgumentException($"Ship {shipString} is the wrong shape");

            if (coordinate0.row == coordinate1.row && coordinate0.col == coordinate1.col)
                throw new ArgumentException($"Ship {shipString} must be at least 2 units long");

            if (Math.Abs(coordinate0.row - coordinate1.row) > 4  
                || Math.Abs(coordinate0.col - coordinate1.col) > 4)
                throw new ArgumentException($"Ship {shipString} too long");

        }

        internal bool TestIfSunk(Coordinate missileCoordinate)
        {
            if (isSunk) return false; //We can't sink the ship twice

            var isHit = IsBetween(coordinate0.row, coordinate1.row, missileCoordinate.row)
                && IsBetween(coordinate0.col, coordinate1.col, missileCoordinate.col);
            
            if (isHit) 
            {
                isSunk = true;
                return true;
            }

            return false;

        }
        private bool IsBetween(int value1, int value2, int testValue)
        {
            return ((testValue >= value1 && testValue <= value2) 
                 || (testValue >= value2 && testValue <= value1));
        }
    }
}
