
public class EventColliderController {
    private IGameEvent _event;
    private bool _didExecuteOnEnter = false;

    public EventColliderController( IGameEvent gameEvent ) {
        _event = gameEvent;
    }

    public void OnTriggerEnter() {
        if ( _event != null ) {
            _didExecuteOnEnter = _event.TryToExecute();
        }
    }

    public void OnTriggerExit() {
        if ( _didExecuteOnEnter ) {
            _event.CleanUpAfterExecution();
        }
    }
}
