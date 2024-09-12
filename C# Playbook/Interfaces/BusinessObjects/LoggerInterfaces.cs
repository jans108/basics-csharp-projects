namespace BusinessObjects
{
    public interface ILogger
    {
        void LogState(ILoggable source);

        void LogMethodCall(ILoggable source, string methodName)
            => throw new NotImplementedException();
    }

    public interface ILoggable
    {
        string Name { get; }

        string CurrentState { get; }
    }
}
