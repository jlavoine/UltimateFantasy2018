using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActiveCamera {
    void MoveToCamera( IFollowPlayerCamera camera );
}

public class ActiveCamera : MonoBehaviour, IActiveCamera {
    public float Speed = 5f;
    public float TurningRate = 30f;
    public float TotalTime = 3f;

    private Vector3 _startPos;
    private float _startTime;
    private Quaternion _startRotation = Quaternion.identity;
    private Quaternion _targetRotation = Quaternion.identity;
    private bool _isMoving = false;
    private IFollowPlayerCamera _moveToTarget;

    void Start() {
    }

    public void MoveToCamera(IFollowPlayerCamera camera) {
        _startPos = transform.position;
        _startRotation = transform.rotation;
        _moveToTarget = camera;
        _isMoving = true;
        _startTime = 0f;
    }
    
    void LateUpdate() {
        if ( _isMoving ) {
            _startTime += Time.deltaTime;
            float fracJourney = _startTime / TotalTime;
            if ( fracJourney >= 1f ) {
                fracJourney = 1f;
                _isMoving = false;
            }

            Vector3 newPos = Vector3.Lerp( _startPos, _moveToTarget.GetPos(), fracJourney );
            transform.position = newPos;          
            transform.rotation = Quaternion.Lerp( _startRotation, _moveToTarget.GetRotation(), fracJourney );
        }
    }
}
