using System.Collections.Generic;
using UnityEngine;

public class CameraManagerMonoB : MonoBehaviour {
    public static CameraManagerMonoB Inst;

    public ActiveCamera ActiveCamera;

    public ICameraManager CameraManager;

    void Start() {
        Inst = this;

        CameraManager = new CameraManager(ActiveCamera);
        CameraManager.CamerasFollowingPlayer = FindCamerasFollowingPlayer();
    }

    void Update() {
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            CameraManager.MoveActiveCameraToTarget( "BehindCamera" );
        } else if ( Input.GetKeyDown( KeyCode.G ) ) {
            CameraManager.MoveActiveCameraToTarget( "DefaultCamera" );
        }
    }

    private List<IFollowPlayerCamera> FindCamerasFollowingPlayer() {
        List<IFollowPlayerCamera> cameraList = new List<IFollowPlayerCamera>();
        FollowPlayerCamera[] camerasFollowingPlayers = FindObjectsOfType<FollowPlayerCamera>();

        for (int i = 0; i < camerasFollowingPlayers.Length; ++i ) {
            cameraList.Add( camerasFollowingPlayers[i] );
        }

        return cameraList;
    }
}
