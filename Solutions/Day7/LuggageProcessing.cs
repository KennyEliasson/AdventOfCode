using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Solutions.Day7
{
    public class LuggageProcessing
    {
        private readonly Dictionary<string, Luggage> _luggageLookup = new Dictionary<string, Luggage>();
        
        private readonly Regex headLuggageRegex = new Regex("(.*) bags contain");
        private readonly Regex childLuggageRegex = new Regex("(\\d+) (\\w* \\w*) bag");

        public LuggageProcessing(List<string> luggageInput)
        {
            foreach (var luggageRow in luggageInput)
            {
                var headMatch = headLuggageRegex.Match(luggageRow);
                var childMatches = childLuggageRegex.Matches(luggageRow);

                var headLuggageColor = headMatch.Groups[1].Value.Trim();
                
                if (!_luggageLookup.ContainsKey(headLuggageColor)) {
                    _luggageLookup.Add(headLuggageColor, new Luggage(headLuggageColor));
                }

                var head = _luggageLookup[headLuggageColor];

                foreach (Match match in childMatches)
                {
                    var childLuggageAmount = match.Groups[1].Value;
                    var childLuggageColor = match.Groups[2].Value.Trim();

                    if (!_luggageLookup.ContainsKey(childLuggageColor))
                    {
                        _luggageLookup.Add(childLuggageColor, new Luggage(childLuggageColor));
                    }

                    head.AddChildren(int.Parse(childLuggageAmount), _luggageLookup[childLuggageColor]);
                }
            }
        }

        public int FindOutHowManyLuggages(string luggageKey)
        {
            var luggage = _luggageLookup[luggageKey];
            return luggage.CountLuggagesNeeded();
        }

        public int FindLuggagesThatCanHaveKey(string luggageKey)
        {
            var total = 0;
            foreach (var luggage in _luggageLookup.Values)
            {
                // Dont count the key, we want luggages that can hold key!
                if(luggage.Color == luggageKey)
                    continue;

                if (luggage.ContainsKey(luggageKey))
                {
                    total++;
                }
            }

            return total;
        }
    }
}