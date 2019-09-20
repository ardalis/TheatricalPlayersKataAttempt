namespace TheatricalPlayersRefactoringKata
{
    public interface IStatementFormatter
    {
        void AppendLine(string text);

        string GetResult();
    }
}
