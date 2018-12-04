
public class LogEvent : GameEvent {
    public const string LOG_TYPE = "LogEvent";
    public const string MESSAGE_PROPERTY = "messageToLog";

    private ILogger _logger;

    public LogEvent( ILogger logger, IEventData data, ITriggerManager triggerManager ) : base( data, triggerManager ) {
        _logger = logger;
    }

    public override void Execute() {
        _logger.Log( LogSeverity.Info, LOG_TYPE, _data.GetProperty( MESSAGE_PROPERTY ) );
    }

    public override void CleanUpAfterExecution() {
        _logger.Log( LogSeverity.Info, LOG_TYPE, _data.GetProperty( MESSAGE_PROPERTY ) + "(Cleanup)" );
    }
}
