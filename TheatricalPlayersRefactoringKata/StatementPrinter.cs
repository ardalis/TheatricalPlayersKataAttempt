using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        private readonly IStatementFormatter _formatter;

        public StatementPrinter(IStatementFormatter formatter)
        {
            _formatter = formatter;
        }

        public StatementPrinter() : this(new TextStatementFormatter())
        {
        }

        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalAmount = 0;
            var volumeCredits = 0;

            _formatter.AppendLine($"Statement for {invoice.Customer}");

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayID];
                var thisAmount = 0;
                thisAmount += play.CalculateAmount(perf.Audience);
                volumeCredits += play.GetVolumeCredits(perf.Audience);

                // print line for this order
                _formatter.AppendLine($"  {play.Name}: {Convert.ToDecimal(thisAmount / 100):C} ({perf.Audience} seats)");
                totalAmount += thisAmount;
            }

            _formatter.AppendLine($"Amount owed is {Convert.ToDecimal(totalAmount / 100):C}");
            _formatter.AppendLine($"You earned {volumeCredits} credits");
            return _formatter.GetResult();
        }
    }
}
