
public interface IGameEvent {
    void TryToExecute();
}

public abstract class GameEvent : IGameEvent {
    protected IEventData _data;

    private ITriggerManager _triggerManager;

    public GameEvent( IEventData data, ITriggerManager triggerManager ) {
        _data = data;
        _triggerManager = triggerManager;
    }

    public void TryToExecute() {
        if ( _triggerManager.DoesPass( _data.GetTriggers() ) ) {
            Execute();
        }
    }

    public abstract void Execute();
}
