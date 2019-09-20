namespace TheatricalPlayersRefactoringKata
{
    public class HistoryPlay : Play
    {
        public HistoryPlay(string name) : base(name, "history")
        {
        }

        internal override int CalculateAmount(int audience)
        {
            int thisAmount = 20000;
            if (audience > 35)
            {
                thisAmount += 1000 * (audience - 35);
            }
            return thisAmount;
        }
    }
}
