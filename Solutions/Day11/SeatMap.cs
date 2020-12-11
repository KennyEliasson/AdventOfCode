using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day11
{
    public enum Type
    {
        Floor,
        Seat,
        Occupied 
    }

    public class SeatMap<T> where T:Position
    {
        public SeatMap(IList<string> lines)
        {
            Map = new Position[lines.Count, lines[0].Length];
            for (var row = 0; row < lines.Count; row++)
            {
                var line = lines[row];
                for (var column = 0; column < line.Length; column++)
                {
                    var position = typeof(T) == typeof(DirectionPosition)
                        ? (Position) new DirectionPosition(line[column], row, column)
                        : new AdjacentPosition(line[column], row, column);

                    Positions.Add(position);
                    Map[row, column] = position;
                }
            }
        }
       
        public List<Position> Positions { get; set; } = new List<Position>();
        public List<Position[,]> MapHistory { get; } = new List<Position[,]>();
        public Position[,] Map { get; private set; }
        
        public int Rounds { get; set; }

        public int FindOccupiedSeatsWhenNoMoreDifferencesCanBeMade()
        {
            var nextRound = true;
            while (nextRound)
            {
                nextRound = !NextRound();
            }

            return Positions.Count(position => position.Status == Type.Occupied);
        }

        private bool NextRound()
        {
            Rounds++;
            MapHistory.Add(Map);
            var newMap = new Position[Map.GetLength(0), Map.GetLength(1)];

            var newPositions = new List<Position>();

            foreach (var position in Positions) {
                var nextRoundPosition = position.NextRound(Map);
                newMap[position.Row, position.Column] = nextRoundPosition;
                newPositions.Add(nextRoundPosition);
            }

            if (Positions.SequenceEqual(newPositions)) {
                return true;
            }

            Map = newMap;
            Positions = newPositions;

            return false;
        }
    }
}
