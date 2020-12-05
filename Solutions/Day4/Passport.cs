namespace Solutions.Day4
{
    public abstract class Passport
    {
        public abstract Passport Build(string passport);
        public abstract bool Valid();
    }
}