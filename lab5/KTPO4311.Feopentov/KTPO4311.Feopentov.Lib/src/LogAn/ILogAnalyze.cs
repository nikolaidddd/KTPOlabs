namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public interface ILogAnalyze
    {
        event LogAnalyzerAction Analyzed;

        void Analyze(string fileName);
        bool IsValidLogFileName(string fileName);
    }
}