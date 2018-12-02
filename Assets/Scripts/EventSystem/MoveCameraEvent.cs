using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraEvent : GameEvent {
    public const string TARGET_CAMERA_PROPERTY = "targetCamera";

    private ICameraManager _cameraManager;

    public MoveCameraEvent( ICameraManager cameraManager, IEventData data, ITriggerManager triggerManager ) : base( data, triggerManager ) {
        _cameraManager = cameraManager;
    }

    public override void Execute() {
        _cameraManager.MoveActiveCameraToTarget( _data.GetProperty( TARGET_CAMERA_PROPERTY ) );
    }
}
