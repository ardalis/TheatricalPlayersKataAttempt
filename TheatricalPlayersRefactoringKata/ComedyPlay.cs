namespace TheatricalPlayersRefactoringKata
{
    public class ComedyPlay : Play
    {
        public ComedyPlay(string name) : base(name, "comedy")
        {
        }

        internal override int CalculateAmount(int audience)
        {
            int thisAmount = 30000;
            if (audience > 20)
            {
                thisAmount += 10000 + 500 * (audience - 20);
            }
            thisAmount += 300 * audience;
            return thisAmount;
        }
    }
}
