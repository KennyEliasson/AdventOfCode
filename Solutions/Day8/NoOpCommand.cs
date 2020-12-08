namespace Solutions.Day8
{
    public class NoOpCommand : Command
    {
        public NoOpCommand(int index,int positionChange) : base(index, positionChange)
        { }
    }
}