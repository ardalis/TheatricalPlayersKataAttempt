using System.Text;

namespace TheatricalPlayersRefactoringKata
{
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
}
