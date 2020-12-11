using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Solutions.Day11
{
    [DebuggerDisplay("{Status}")]
    public class DirectionPosition : Position
    {
        public DirectionPosition(char typeChar, int row, int column) : base(typeChar, row, column)
        {
        }

        public DirectionPosition(Type status, int row, int column) : base(status, row, column)
        {
        }

        private Position FindFirstSeatInDirection(int rowStep, int columnStep, int startRow, int startColumn, Position[,] positions)
        {
            var rowCount = positions.GetLength(0);
            var columnCount = positions.GetLength(1);

            var currentRow = startRow;
            var currentColumn = startColumn;

            while (true)
            {
                currentRow += rowStep;
                currentColumn += columnStep;

                if (currentRow >= 0 && currentRow < rowCount)
                {
                    if (currentColumn >= 0 && currentColumn < columnCount)
                    {
                        if (positions[currentRow, currentColumn].IsSeat())
                        {
                            return positions[currentRow, currentColumn];
                        }

                        continue;
                    }
                }

                break;
            }

            return null;
        }

        public override Position NextRound(Position[,] positions)
        {
            var upAndLeft = FindFirstSeatInDirection(-1, -1, Row, Column, positions);
            var up = FindFirstSeatInDirection(-1, 0, Row, Column, positions);
            var upAndRight = FindFirstSeatInDirection(-1, +1, Row, Column, positions);
            var left = FindFirstSeatInDirection(0, -1, Row, Column,positions);
            var right = FindFirstSeatInDirection(0, +1, Row, Column, positions);
            var downAndLeft = FindFirstSeatInDirection(+1, -1, Row, Column, positions);
            var down = FindFirstSeatInDirection(+1, 0, Row, Column, positions);
            var downAndRight = FindFirstSeatInDirection(+1, +1, Row, Column, positions);

            var positionAdjacentToPosition = new List<Position> {
                upAndLeft, up, upAndRight, left, right, downAndLeft, down, downAndRight
            }.Where(x => x != null).ToList();
            
            switch (Status)
            {
                case Type.Floor:
                    return new DirectionPosition(Type.Floor, Row, Column);
                case Type.Seat:
                    var isAnySeatOccupied = positionAdjacentToPosition.Any(x => x.Status == Type.Occupied);
                    return !isAnySeatOccupied ? new DirectionPosition(Type.Occupied, Row, Column) : new DirectionPosition(Type.Seat, Row, Column);
                case Type.Occupied:
                    var occupiedSeats = positionAdjacentToPosition.Count(position => position.Status == Type.Occupied);
                    return occupiedSeats >= 5 ? new DirectionPosition(Type.Seat, Row, Column) : new DirectionPosition(Type.Occupied, Row, Column);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}