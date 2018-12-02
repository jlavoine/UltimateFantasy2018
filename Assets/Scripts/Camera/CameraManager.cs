using System.Collections.Generic;
using UnityEngine;

public interface ICameraManager {
    List<IFollowPlayerCamera> CamerasFollowingPlayer { get; set; }

    void PlayerMoved( Vector3 move );
    void MoveActiveCameraToTarget( string targetName );
}

public class CameraManager : ICameraManager {

    private List<IFollowPlayerCamera> _camerasFollowingPlayer = new List<IFollowPlayerCamera>();
    public List<IFollowPlayerCamera> CamerasFollowingPlayer { get { return _camerasFollowingPlayer; } set { _camerasFollowingPlayer = value; } }

    private IActiveCamera _activeCamera;

    public CameraManager(IActiveCamera activeCamera) {
        _activeCamera = activeCamera;
    }

    public void PlayerMoved( Vector3 move ) {
        foreach ( IFollowPlayerCamera camera in CamerasFollowingPlayer ) {
            camera.Move( move );
        }
    }

    public void MoveActiveCameraToTarget(string targetName) {
        foreach(IFollowPlayerCamera camera in CamerasFollowingPlayer) {
            if ( camera.GetName() == targetName ) {
                _activeCamera.MoveToCamera( camera );
            }
        }
    }
}
