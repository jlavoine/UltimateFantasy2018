using UnityEngine;

public class EventColliderObject : MonoBehaviour {
    public string EventId;

    private EventsManager _eventsManager;

	void Start () {
        _eventsManager = EventsManager.Inst;	
	}

    public void OnTriggerEnter( Collider obj ) {
        IGameEvent gameEvent = _eventsManager.GetEvent( EventId );
        if (gameEvent != null ) {
            gameEvent.Execute();
        }
    }
}
