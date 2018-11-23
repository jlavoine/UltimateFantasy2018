using UnityEngine;

public class EventColliderObject : MonoBehaviour {
    public string EventId;

    public void OnTriggerEnter( Collider obj ) {
        IGameEvent gameEvent = EventsManager.Inst.GetEvent( EventId );
        if (gameEvent != null ) {
            gameEvent.TryToExecute();
        }
    }
}
