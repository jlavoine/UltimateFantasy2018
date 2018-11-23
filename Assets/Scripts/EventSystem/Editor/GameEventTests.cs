using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

public class GameEventTests {
    private class DefaultGameEvent : GameEvent {
        public bool didExecute = false;

        public DefaultGameEvent( IEventData data, ITriggerManager triggerManager ) : base( data, triggerManager ) { }

        public override void Execute() {
            didExecute = true;
        }
    }

    private IEventData MockEventData;
    private ITriggerManager MockTriggerManager;

    [SetUp]
    public void BeforeTest() {
        MockEventData = Substitute.For<IEventData>();
        MockTriggerManager = Substitute.For<ITriggerManager>();
    }

    private DefaultGameEvent CreateSystem() {
        return new DefaultGameEvent( MockEventData, MockTriggerManager );
    }

    [Test]
    public void WhenTryingToExecute_IfDoesNotPassTriggers_DoesNotExecute() {
        DefaultGameEvent systemUnderTest = CreateSystem();
        MockTriggerManager.DoesPass( Arg.Any<List<ITriggerData>>() ).Returns( false );

        systemUnderTest.TryToExecute();

        Assert.IsFalse( systemUnderTest.didExecute );
    }

    [Test]
    public void WhenTryingToExecute_IfPassesTriggers_Executes() {
        DefaultGameEvent systemUnderTest = CreateSystem();
        MockTriggerManager.DoesPass( Arg.Any<List<ITriggerData>>() ).Returns( true );

        systemUnderTest.TryToExecute();

        Assert.IsTrue( systemUnderTest.didExecute );
    }
}
