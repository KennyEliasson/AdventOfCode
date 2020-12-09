using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day9
{
    public class Xmas
    {
        public long FindFirstNumberThatNotMatchesPremable(List<long> input, int preambleLength)
        {
            return FindFirstNumberThatNotMatchesPremable(input, 0, preambleLength);
        }

        private long FindFirstNumberThatNotMatchesPremable(List<long> input, int startIndex, int preambleLength)
        {
            while (true)
            {
                var range = startIndex..preambleLength;
                var slice = input.GetRange(range.Start.Value, range.End.Value);
                var possibilities = CalculatePossibilities(slice);
                
                var numberToFind = input[range.Start.Value + range.End.Value];

                if (possibilities.Contains(numberToFind))
                {
                    startIndex++;
                }
                else
                {
                    return numberToFind;
                }
            }
        }

        private IEnumerable<long> CalculatePossibilities(List<long> start)
        {
            foreach (var leftTerm in start)
            {
                foreach (var rightTerm in start)
                {
                    if(leftTerm == rightTerm)
                        continue;

                    yield return leftTerm + rightTerm;
                }
            }
        }

        public long FindRangeThatMatches(List<long> numbers, long numberToMatchAgainst)
        {
            var (startIndex, endIndex) = CalculatePossibilitesToFindMatchingSequence(numbers, numberToMatchAgainst);
            var range = numbers.GetRange(startIndex, endIndex-startIndex);
            var rangeMin = range.Min();
            var rangeMax = range.Max();

            return rangeMin + rangeMax;
        }

        private (int startIndex, int endIndex) CalculatePossibilitesToFindMatchingSequence(IReadOnlyList<long> numbers, long numberToMatchAgainst, int startIndex = 0)
        {
            while (true)
            {
                long match = 0;
                for (var i = startIndex; i < numbers.Count; i++)
                {
                    match += numbers[i];

                    if (numberToMatchAgainst == match)
                    {
                        return (startIndex, i);
                    }

                    if (match > numberToMatchAgainst)
                    {
                        startIndex++;
                        break;
                    }
                }
            }
        }
    }
}