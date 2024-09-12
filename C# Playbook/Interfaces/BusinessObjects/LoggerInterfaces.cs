namespace BusinessObjects
{
    public interface ILogger
    {
        void LogState(ILoggable source);

        void LogMethodCall(ILoggable source, string methodName)
            => throw new NotImplementedException();

        bool CanLogMethodCall => false;

        bool TryLogMethodCall(ILoggable source, string methodName)
        {
            bool canLog = CanLogMethodCall;
            if(canLog)
                LogMethodCall(source, methodName);
            return canLog;
        }
    }

    public interface ILoggable
    {
        string Name { get; }

        string CurrentState { get; }
    }
}
