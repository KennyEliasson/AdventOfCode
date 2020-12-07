using System.Collections.Generic;

namespace Solutions.Day7
{
    public class Luggage
    {
        public string Color { get; }

        public Luggage(string color)
        {
            Color = color;
        }

        private readonly Dictionary<string, int> _luggageCount = new Dictionary<string, int>();
        private readonly List<Luggage> _children = new List<Luggage>();

        public void AddChildren(int amount, Luggage luggage)
        {
            _children.Add(luggage);
            _luggageCount.Add(luggage.Color, amount);
        }

        public int CountLuggagesNeeded()
        {
            var total = 0;
            foreach (var child in _children)
            {
                var howMany = _luggageCount[child.Color];
                total += howMany;
                total += child.CountLuggagesNeeded() * howMany;
            }
            return total;
        }

        public bool ContainsKey(string key)
        {
            if (key == Color)
                return true;
            
            foreach (var luggage in _children)
            {
                var result = luggage.ContainsKey(key);
                if (result)
                    return true;
            }

            return false;
        }
    }
}