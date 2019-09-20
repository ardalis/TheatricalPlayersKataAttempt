using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TheatricalPlayersRefactoringKata
{
    public interface IStatementFormatter
    {
        void AppendLine(string text);

        string GetResult();
    }

    public class TextStatementFormatter : IStatementFormatter
    {
        StringBuilder _sb = new StringBuilder();

        public void AppendLine(string text)
        {
            _sb.AppendLine(text);
        }

        public string GetResult()
        {
            return _sb.ToString();
        }
    }

    public class HtmlStatementFormatter : IStatementFormatter
    {
        StringBuilder _sb = new StringBuilder();

        public void AppendLine(string text)
        {
            _sb.AppendLine(text + "<br />");
        }

        public string GetResult()
        {
            return _sb.ToString();
        }
    }

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

            _formatter.AppendLine(string.Format("Statement for {0}", invoice.Customer));

                CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayID];
                var thisAmount = 0;
                thisAmount += play.CalculateAmount(perf.Audience);
                volumeCredits += play.GetVolumeCredits(perf.Audience);

                // print line for this order
                _formatter.AppendLine(String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience));
                totalAmount += thisAmount;
            }

            _formatter.AppendLine(String.Format(cultureInfo, "Amount owed is {0:C}", Convert.ToDecimal(totalAmount / 100)));
            _formatter.AppendLine(String.Format("You earned {0} credits", volumeCredits));
            return _formatter.GetResult();
        }


    }
}
