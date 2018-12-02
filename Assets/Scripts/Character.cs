using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Character : MonoBehaviour {
    public float Speed;
    private CharacterController _controller;

    void Start() {
        _controller = GetComponent<CharacterController>();

        EventData e1 = new EventData();
        e1.EventType = "a";
        e1.EventId = "One";
        e1.Properties = new Dictionary<string, string>();
        e1.Properties.Add( "messageToLog", "hi" );
        e1.Triggers = new List<TriggerData>();
        e1.Triggers.Add( new TriggerData() { Equality = TriggerEquality.EQUALS, Key = "key", TargetValue = 0 } );
        EventData e2 = new EventData();
        e2.EventType = "b";
        e2.EventId = "Two";

        Dictionary<string, EventData> events = new Dictionary<string, EventData>();
        events.Add( "One", e1 );
        events.Add( "Two", e2 );
        UnityEngine.Debug.LogError( JsonConvert.SerializeObject( events ) );
    }

    private bool _movedThisFrame = false;
    private Vector3 _prevPos;

    void Update() {
        Vector3 move = new Vector3( Input.GetAxis( "Horizontal" ), 0, Input.GetAxis( "Vertical" ) );
        if ( move != Vector3.zero ) {
            //Debug.LogError( "BEFORE " + transform.position.ToString("F4") );
            _movedThisFrame = true;
            _prevPos = transform.position;
        } else {
            _movedThisFrame = false;
        }

        _controller.Move( move * Time.deltaTime * Speed );

        if ( move != Vector3.zero ) {
            transform.forward = move;
        }
    }

    void LateUpdate() {
        if (_movedThisFrame) {
            Vector3 diff = transform.position - _prevPos;
            CameraManagerMonoB.Inst.CameraManager.PlayerMoved( diff );
        }
    }

}