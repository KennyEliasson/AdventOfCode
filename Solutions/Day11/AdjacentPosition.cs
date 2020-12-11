using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Solutions.Day11
{
    [DebuggerDisplay("{Status}")]
    public class AdjacentPosition : Position
    {
        public AdjacentPosition(char typeChar, int row, int column) : base(typeChar, row, column) { }

        public AdjacentPosition(Type status, int row, int column) : base(status, row, column) { }
        
        public override Position NextRound(Position[,] positions)
        {
            var positionAdjacentToPosition = new List<Position>();
            
            var possiblePositions = new List<(int row, int column)>
            {
                (Row-1, Column-1),
                (Row-1, Column),
                (Row-1, Column+1),
                (Row, Column-1),
                (Row, Column+1),
                (Row+1, Column-1),
                (Row+1, Column),    
                (Row+1, Column+1),
            };

            foreach (var (row, column) in possiblePositions)
            {
                if (row >= 0 && row < positions.GetLength(0))
                {
                    if (column >= 0 && column < positions.GetLength(1))
                    {
                        positionAdjacentToPosition.Add(positions[row, column]);                    
                    }
                }
            }
            
            switch (Status)
            {
                case Type.Floor:
                    return new AdjacentPosition(Type.Floor, Row, Column);
                case Type.Seat:
                    var isAnySeatOccupied = positionAdjacentToPosition.Any(x => x.Status == Type.Occupied);
                    return !isAnySeatOccupied ? new AdjacentPosition(Type.Occupied, Row, Column) : new AdjacentPosition(Type.Seat, Row, Column);
                case Type.Occupied:
                    var occupiedSeats = positionAdjacentToPosition.Count(position => position.Status == Type.Occupied);
                    return occupiedSeats >= 4 ? new AdjacentPosition(Type.Seat, Row, Column) : new AdjacentPosition(Type.Occupied, Row, Column);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}