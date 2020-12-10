using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;

namespace Solutions.Day10
{
    public class ChargingAdapters
    {
        public List<int> CalculateAdapterDifferences(List<int> adapters)
        {
            adapters = adapters.OrderBy(x => x).ToList();

            var differences = new List<int>();
            var currentAdapter = 0;
            for (int i = 0; i < adapters.Count;i++)
            {
                var diff = adapters[i] - currentAdapter;
                if(diff <= 3)
                {
                    differences.Add(diff);
                    currentAdapter = adapters[i];
                }
            }
            
            // Last for the device
            differences.Add(3);

            return differences;
        } 
        
        private readonly Dictionary<int, long> _alreadyCalculated = new Dictionary<int, long>();
        
        public long CalculatePossibilities(List<int> adapters)
        {
            adapters.Add(0);
            adapters.Add(adapters.Max() + 3);
            adapters = adapters.OrderBy(x => x).ToList();
            _alreadyCalculated[adapters.Count - 1] = 0;
            _alreadyCalculated[adapters.Count - 2] = 1;


            var val = CalculatePossibilitiesFrom(0, adapters);
            return val;
        }

        private long CalculatePossibilitiesFrom(int startIndex, List<int> adapters)
        {

            if (_alreadyCalculated.ContainsKey(startIndex))
                return _alreadyCalculated[startIndex];
            
            long currentVal = 0;

            for (int i = 1; i <= 3; i++)
            {
                var currentIndex = startIndex + i;
                if (currentIndex >= adapters.Count)
                {
                    break;
                }

                var diff = adapters[currentIndex] - adapters[startIndex];
                if (diff <= 3)
                {
                    currentVal += CalculatePossibilitiesFrom(currentIndex, adapters);
                }
            }

            _alreadyCalculated[startIndex] = currentVal;

            return currentVal;
        }
    }
}