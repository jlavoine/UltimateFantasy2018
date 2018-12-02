using NUnit.Framework;
using NSubstitute;

public class MoveCameraEventTests {

    private ICameraManager MockCameraManager;
    private IEventData MockData;
    private ITriggerManager MockTriggerManager;

    [SetUp]
    public void BeforeTest() {
        MockCameraManager = Substitute.For<ICameraManager>();
        MockData = Substitute.For<IEventData>();
        MockTriggerManager = Substitute.For<ITriggerManager>();
    }

    private MoveCameraEvent CreateSystem() {
        return new MoveCameraEvent( MockCameraManager, MockData, MockTriggerManager );
    }

    [Test]
    public void WhenExecuted_ActiveCameraIsMovedToTarget() {
        MockData.GetProperty( MoveCameraEvent.TARGET_CAMERA_PROPERTY ).Returns( "SomeCamera" );
        MoveCameraEvent systemUnderTest = CreateSystem();

        systemUnderTest.Execute();

        MockCameraManager.Received().MoveActiveCameraToTarget( "SomeCamera" );
    }
}
