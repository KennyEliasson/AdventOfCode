using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class SlopeRow
    {
        public readonly List<bool> TreeAtPosition = new List<bool>();

        public SlopeRow(string slopeRowMap)
        {
            foreach (var obj in slopeRowMap)
            {
                TreeAtPosition.Add(obj == '#');
            }
        }
    }
    
    public class SlopeCalculator
    {
        private List<SlopeRow> _rows;


        public SlopeCalculator(List<string> map)
        {
            _rows = new List<SlopeRow>();
            foreach (var line in map) {
                _rows.Add(new SlopeRow(line));
            }
        }

        public int Ski(int down, int right)
        {
            var maxWidth = _rows.First().TreeAtPosition.Count;
            var currentPosOnRow = 0;

            var treesHit = 0;
            for (int currentRow = 0; currentRow < _rows.Count; currentRow += down) {

                if (_rows[currentRow].TreeAtPosition[currentPosOnRow]) {
                    treesHit++;
                }

                currentPosOnRow += right;
                if (currentPosOnRow >= maxWidth) {
                    currentPosOnRow -= maxWidth;
                }
            }

            return treesHit;
        }
    }
}