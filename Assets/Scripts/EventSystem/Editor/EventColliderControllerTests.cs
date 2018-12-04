using NUnit.Framework;
using NSubstitute;

public class EventColliderControllerTests {
    private IGameEvent MockGameEvent;

    [SetUp]
    public void BeforeTest() {
        MockGameEvent = Substitute.For<IGameEvent>();
    }

    private EventColliderController CreateSystem() {
        return new EventColliderController( MockGameEvent );
    }

    [Test]
    public void WhenTriggerEnter_IfGameEventNotNull_TryToExecute() {
        EventColliderController systemUnderTest = CreateSystem();

        systemUnderTest.OnTriggerEnter();

        MockGameEvent.Received().TryToExecute();
    }

    [Test]
    public void WhenTriggerExit_IfExecutedOnEntered_CleanUpCalled() {
        EventColliderController systemUnderTest = CreateSystem();
        MockGameEvent.TryToExecute().Returns( true );

        systemUnderTest.OnTriggerEnter();
        systemUnderTest.OnTriggerExit();

        MockGameEvent.Received().CleanUpAfterExecution();
    }

    [Test]
    public void WhenTriggerExit_IfNotExecutedOnEntered_CleanUpNotCalled() {
        EventColliderController systemUnderTest = CreateSystem();
        MockGameEvent.TryToExecute().Returns( false );

        systemUnderTest.OnTriggerEnter();
        systemUnderTest.OnTriggerExit();

        MockGameEvent.DidNotReceive().CleanUpAfterExecution();
    }
}
