namespace FischeVerschenkenRevived
{
    internal class Position
    {
        public int XValue;
        public int YValue;
        public bool isHit;

        public Position()
        { }

        public Position(int xPosition, int yPosition, bool v)
        {
            this.XValue = xPosition;
            this.YValue = yPosition;
            this.isHit = v;
        }
    }
}