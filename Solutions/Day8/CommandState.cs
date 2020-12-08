using System.Collections.Generic;

namespace Solutions.Day8
{
    public class CommandState
    {
        public List<int> Traversed { get; set; } = new List<int>();
        public int Accumulator { get; set; }
        public int CurrentIndex { get; set; }
    }
}