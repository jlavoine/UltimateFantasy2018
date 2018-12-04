
public interface IGameEvent {
    bool TryToExecute();
    void CleanUpAfterExecution();
}

public abstract class GameEvent : IGameEvent {
    protected IEventData _data;

    private ITriggerManager _triggerManager;

    public GameEvent( IEventData data, ITriggerManager triggerManager ) {
        _data = data;
        _triggerManager = triggerManager;
    }

    public bool TryToExecute() {
        if ( _triggerManager.DoesPass( _data.GetTriggers() ) ) {
            Execute();
            return true;
        } else {
            return false;
        }
    }

    public abstract void Execute();
    public virtual void CleanUpAfterExecution() { }
}
