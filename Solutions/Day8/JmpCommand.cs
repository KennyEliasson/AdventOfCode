namespace Solutions.Day8
{
    public class JmpCommand : Command
    {
        public JmpCommand(int index, int positionChange) : base(index, positionChange)
        { }

        protected override void SetNextIndex(CommandState state)
        {
            state.CurrentIndex += PositionChange;
        }
    }
}