using System.Text;

namespace TheatricalPlayersRefactoringKata
{
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
}
