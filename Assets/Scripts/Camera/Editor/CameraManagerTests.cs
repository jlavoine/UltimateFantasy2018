using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerTests {
    private IActiveCamera MockActiveCamera;

    [SetUp]
    public void BeforeTest() {
        MockActiveCamera = Substitute.For<IActiveCamera>();
    }

    private List<IFollowPlayerCamera> CreateFollowCameras(int count) {
        List<IFollowPlayerCamera> mockCameras = new List<IFollowPlayerCamera>();

        for (int i = 0; i < count;  ++i ) {
            IFollowPlayerCamera mockCamera = Substitute.For<IFollowPlayerCamera>();
            mockCamera.GetName().Returns( "MockCamera_" + i );
            mockCameras.Add( mockCamera );            
        }

        return mockCameras;
    }

    private CameraManager CreateSystem() {
        return new CameraManager(MockActiveCamera);
    }

    [Test]
    public void WhenMovingActiveCameraToTarget_ActiveCameraMovesToTarget() {
        CameraManager systemUnderTest = CreateSystem();
        systemUnderTest.CamerasFollowingPlayer = CreateFollowCameras( 3 );

        systemUnderTest.MoveActiveCameraToTarget( "MockCamera_2" );

        MockActiveCamera.Received().MoveToCamera( systemUnderTest.CamerasFollowingPlayer[2] );
    }

	[Test]
    public void WhenPlayerMoved_AllFollowCamerasMoved_BySameAmount() {
        CameraManager systemUnderTest = CreateSystem();
        systemUnderTest.CamerasFollowingPlayer = CreateFollowCameras( 3 );

        Vector3 moveAmount = new Vector3( 1, 1, 1 );
        systemUnderTest.PlayerMoved( moveAmount );

        foreach ( IFollowPlayerCamera camera in systemUnderTest.CamerasFollowingPlayer ) {
            camera.Received().Move( moveAmount );
        }
    }
}
