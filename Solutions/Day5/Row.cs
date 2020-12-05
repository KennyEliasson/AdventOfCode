using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day5
{
    public class Row
    {
        public Row()
        {
            for (var i = 0; i < 8; i++)
            {
                Seats.Add(false);
            }
        }

        public bool IsAvailable()
        {
            return Seats.Any(occupied => occupied);
        }

        public bool HasAvailableSeat()
        {
            return Seats.Any(occupied => !occupied);
        }

        public readonly List<bool> Seats = new List<bool>();

        public int GetIndexOfAvailableSeat()
        {
            return Seats.FindIndex(occupied => !occupied);
        }
    }
}