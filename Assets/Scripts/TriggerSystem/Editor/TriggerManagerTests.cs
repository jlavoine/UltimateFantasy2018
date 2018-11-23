using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

public class TriggerManagerTests  {

	private TriggerManager CreateSystem() {
        return new TriggerManager();
    }

    private List<ITriggerData> CreateMockTriggers( int count ) {
        List<ITriggerData> triggers = new List<ITriggerData>();

        for (int i = 0; i < count;  ++i ) {
            ITriggerData trigger = Substitute.For<ITriggerData>();
            trigger.GetKey().Returns( "SomeTrigger_" + i );
            triggers.Add( trigger );
        }

        return triggers;
    }

    [Test]
    public void WhenTriggerAbsentFromPlayerData_ZeroIsCurValue() {
        TriggerManager systemUnderTest = CreateSystem();
        systemUnderTest.PlayerTriggerData = new Dictionary<string, int>();

        List<ITriggerData> triggers = CreateMockTriggers( 1 );
        systemUnderTest.DoesPass( triggers );

        triggers[0].Received().DoesValuePass( 0 );
    }

    [Test]
    public void WhenAllTriggersPass_DoesPass() {
        List<ITriggerData> triggers = CreateMockTriggers( 2 );
        triggers[0].DoesValuePass(Arg.Any<int>()).Returns( true );
        triggers[1].DoesValuePass(Arg.Any<int>()).Returns( true );
        TriggerManager systemUnderTest = CreateSystem();
        systemUnderTest.PlayerTriggerData.Add( "SomeTrigger_0", 1 );
        systemUnderTest.PlayerTriggerData.Add( "SomeTrigger_1", 1 );


        bool doesPass = systemUnderTest.DoesPass( triggers );

        Assert.IsTrue( doesPass );
    }

    [Test]
    public void WhenAnyTriggerFails_DoesNotPass() {
        List<ITriggerData> triggers = CreateMockTriggers( 2 );
        triggers[0].DoesValuePass( Arg.Any<int>() ).Returns( true );
        triggers[1].DoesValuePass( Arg.Any<int>() ).Returns( false );
        TriggerManager systemUnderTest = CreateSystem();
        systemUnderTest.PlayerTriggerData.Add( "SomeTrigger_0", 1 );
        systemUnderTest.PlayerTriggerData.Add( "SomeTrigger_1", 1 );


        bool doesPass = systemUnderTest.DoesPass( triggers );

        Assert.IsFalse( doesPass );
    }
}
