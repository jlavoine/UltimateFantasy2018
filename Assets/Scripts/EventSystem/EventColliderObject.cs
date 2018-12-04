using UnityEngine;

public class EventColliderObject : MonoBehaviour {
    public string EventId;

    

    private EventColliderController _controller;

    void Start() {
        _controller = new EventColliderController( EventsManager.Inst.GetEvent( EventId ) );
    }

    public void OnTriggerEnter( Collider obj ) {
        _controller.OnTriggerEnter();
    }

    public void OnTriggerExit( Collider obj ) {
        _controller.OnTriggerExit();
    }
}
