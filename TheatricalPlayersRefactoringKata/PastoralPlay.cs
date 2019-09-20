namespace TheatricalPlayersRefactoringKata
{
    public class PastoralPlay : Play
    {
        public PastoralPlay(string name) : base(name, "pastoral")
        {
        }

        internal override int CalculateAmount(int audience)
        {
            int thisAmount = 45000;
            if (audience > 30)
            {
                thisAmount += 1000 * (audience - 30);
            }
            return thisAmount;
        }
    }
}
