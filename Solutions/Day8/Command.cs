namespace Solutions.Day8
{
    public abstract class Command
    {
        public Command(int index, int positionChange)
        {
            Index = index;
            PositionChange = positionChange;
        }

        public bool Execute(CommandState state)
        {
            if (state.Traversed.Contains(state.CurrentIndex))
            {
                return false;
            }
            
            state.Traversed.Add(Index);
            ExecuteInternal(state);
            SetNextIndex(state);

            return true;
        }

        protected virtual void SetNextIndex(CommandState state)
        {
            state.CurrentIndex++;
        }

        protected virtual void ExecuteInternal(CommandState state)
        { }
        
        public int Index { get; }
        public int PositionChange { get; set; }
    }
}