namespace FischeVerschenkenRevived
{
    internal class Position
    {
        public int XValue;
        public int YValue;
        public bool isHit;

        public Position()
        { }

        public Position(int xIterator, int yIterator, bool v)
        {
            this.XValue = xIterator;
            this.YValue = yIterator;
            this.isHit = v;
        }
    }
}