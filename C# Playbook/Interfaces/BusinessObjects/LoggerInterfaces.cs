namespace BusinessObjects
{
    public interface ILogger
    {
        void LogState(ILoggable source);
    }

    public interface ILoggable
    {
        string Name { get; }

        string CurrentState { get; }
    }
}
