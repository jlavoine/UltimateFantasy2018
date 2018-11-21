
public interface IGameEvent {
    void Execute();
}

public abstract class GameEvent : IGameEvent {
    protected IEventData _data;

    public GameEvent( IEventData data ) {
        _data = data;
    }

    public abstract void Execute();
}
