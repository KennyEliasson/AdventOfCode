namespace Solutions.Day8
{
    public class AccCommand : Command
    {
        public AccCommand(int index,int positionChange) : base(index, positionChange)    
        { }

        protected override void ExecuteInternal(CommandState state)
        {
            state.Accumulator += PositionChange;
        }
    }
}