using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Solutions
{
    public class SlopeRow
    {
        public List<bool> TreeAtPosition = new List<bool>();

        public SlopeRow(string slopeRowMap)
        {
            foreach (char obj in slopeRowMap)
            {
                if (obj == '#')
                {
                    TreeAtPosition.Add(true);
                }
                else
                {
                    TreeAtPosition.Add(false);
                }
            }
        }
    }
    
    public class SlopeCalculator
    {
        private List<SlopeRow> _rows;


        public SlopeCalculator(List<string> map)
        {
            _rows = new List<SlopeRow>();
            foreach (var line in map)
            {
                _rows.Add(new SlopeRow(line));
            }
        }

        public int Ski(int down, int right)
        {
            var maxWidth = _rows.First().TreeAtPosition.Count;
            // var currentRow = 0;
            var currentPosOnRow = 0;

            var treesHit = 0;
            for (int currentRow = 0; currentRow < _rows.Count; currentRow += down)
            {
                try
                {
                    if (_rows[currentRow].TreeAtPosition[currentPosOnRow])
                    {
                        treesHit++;
                    }
                }
                catch (Exception e)
                {
                    var f = e;
                }
                
                
                currentPosOnRow += right;
                if (currentPosOnRow >= maxWidth)
                {
                    currentPosOnRow -= maxWidth;
                }
            }

            return treesHit;
        }
    }
}