namespace TheatricalPlayersRefactoringKata
{
    public class TragedyPlay : Play
    {
        public TragedyPlay(string name) : base(name, "tragedy")
        {
        }

        internal override int CalculateAmount(int audience)
        {
            int thisAmount = 40000;
            if (audience > 30)
            {
                thisAmount += 1000 * (audience - 30);
            }
            return thisAmount;
        }
    }
}
