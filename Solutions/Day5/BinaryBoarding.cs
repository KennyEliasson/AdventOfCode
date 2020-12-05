using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day5
{
    public class BinaryBoarding
    {
        public int FindSeatIndex(string seat)
        {
            var (rowIndex, seatIndex) = FindSeat(seat);
            return SeatIndex(rowIndex, seatIndex);
        }

        public (int rowIndex, int seatIndex) FindSeat(string seat)
        {
            var rowPartition = seat[..7].ToCharArray().Select(letter => {
                return letter switch {
                    'B' => Bound.Upper,
                    'F' => Bound.Lower,
                    _ => throw new Exception("Should not happen")
                };
            }).ToList();
            
            var seatPartition = seat[^3..].ToCharArray().Select(letter => {
                return letter switch {
                    'R' => Bound.Upper,
                    'L' => Bound.Lower,
                    _ => throw new Exception("Should not happen")
                };
            }).ToList();

            var rowIndex = CalculateIndex(rowPartition, ..127);
            var seatIndex = CalculateIndex(seatPartition, ..7);
            
            return (rowIndex, seatIndex);
        }

        public int SeatIndex(int rowIndex, int seatIndex)
        {
            return rowIndex * 8 + seatIndex;
        }

        private int CalculateIndex(IList<Bound> partition, Range startRange)
        {
            var subRange = startRange;
            foreach (var bound in partition)
            {
                subRange = CalculateIndex(bound, subRange);
            }

            return partition[^1] == Bound.Lower ? subRange.Start.Value : subRange.End.Value;
        }

        private Range CalculateIndex(Bound bound, Range range)
        {
            var half = (range.End.Value - range.Start.Value) / 2;

            return bound switch
            {
                Bound.Lower => range.Start..(range.Start.Value + half),
                Bound.Upper => (range.Start.Value + half + 1)..range.End,
                _ => throw new Exception("Should not happen")
            };
        }

        private enum Bound
        {
            Lower,
            Upper
        }
    }
}