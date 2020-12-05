using System.Collections.Generic;

namespace Solutions.Day5
{
    public class Plane
    {
        private List<Row> Rows { get; } = new List<Row>();

        public Plane()
        {
            for (int i = 0; i < 128; i++)
            {
                Rows.Add(new Row());
            }
        }

        public (int rowIndex, int seatIndex) FindAvailableSeat()
        {
            for (var rowIndex = 0; rowIndex < Rows.Count; rowIndex++)
            {
                var row = Rows[rowIndex];
                if (row.IsAvailable() && row.HasAvailableSeat())
                {
                    return (rowIndex, row.GetIndexOfAvailableSeat());
                }
            }

            return (-1, -1);
        }
            
        public void AddOccupiedSeat((int rowIndex, int seatIndex) seat)
        {
            Rows[seat.rowIndex].Seats[seat.seatIndex] = true;
        }
    }
}