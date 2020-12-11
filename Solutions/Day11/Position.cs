using System;

namespace Solutions.Day11
{
    public abstract class Position
    {
        protected Position(char typeChar, int row, int column)
        {
            Status = typeChar switch {
                '.' => Type.Floor,
                '#' => Type.Occupied,
                'L' => Type.Seat,
                _ => Status
            };

            Row = row;
            Column = column;
        }

        protected Position(Type status, int row, int column)
        {
            Status = status;
            Row = row;
            Column = column;
        }

        public Type Status { get; }
        public int Row { get; }
        public int Column { get; }

        public bool IsSeat()
        {
            return Status == Type.Seat || Status == Type.Occupied;
        }

        public abstract Position NextRound(Position[,] positions);
        
        protected bool Equals(Position other)
        {
            return Status == other.Status && Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Status, Row, Column);
        }
    }
}