using NUnit.Framework;
using NSubstitute;

public class TriggerDataTests {

	private TriggerData CreateSystem() {
        return new TriggerData();
    }

    [Test]
    public void DoesValuePass_ForEquals_IsTrue_WhenValueEqualsTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.EQUALS;

        bool doesPass = systemUnderTest.DoesValuePass( 1 );

        Assert.IsTrue( doesPass );
    }

    [Test]
    public void DoesValuePass_ForEquals_IsFalse_WhenValueDoesNotEqualTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.EQUALS;

        bool doesPass = systemUnderTest.DoesValuePass( 0 );

        Assert.IsFalse( doesPass );
    }

    [Test]
    public void DoesValuePass_ForNotEquals_IsFalse_WhenValueEqualsTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.NOT_EQUALS;

        bool doesPass = systemUnderTest.DoesValuePass( 1 );

        Assert.IsFalse( doesPass );
    }

    [Test]
    public void DoesValuePass_ForNotEquals_IsTrue_WhenValueDoesNotEqualTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.NOT_EQUALS;

        bool doesPass = systemUnderTest.DoesValuePass( 0 );

        Assert.IsTrue( doesPass );
    }

    [Test]
    public void DoesValuePass_ForLessThan_IsTrue_WhenValueLessThanTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.LESS_THAN;

        bool doesPass = systemUnderTest.DoesValuePass( 0 );

        Assert.IsTrue( doesPass );
    }

    [Test]
    public void DoesValuePass_ForLessThan_IsFalse_WhenValueEqualsTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.LESS_THAN;

        bool doesPass = systemUnderTest.DoesValuePass( 1 );

        Assert.IsFalse( doesPass );
    }

    [Test]
    public void DoesValuePass_ForLessThan_IsFalse_WhenValueGreaterThanTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.LESS_THAN;

        bool doesPass = systemUnderTest.DoesValuePass( 2 );

        Assert.IsFalse( doesPass );
    }

    [Test]
    public void DoesValuePass_ForGreaterThan_IsTrue_WhenValueGreaterThanTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.GREATER_THAN;

        bool doesPass = systemUnderTest.DoesValuePass( 2 );

        Assert.IsTrue( doesPass );
    }

    [Test]
    public void DoesValuePass_ForGreaterThan_IsFalse_WhenValueEqualsTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.GREATER_THAN;

        bool doesPass = systemUnderTest.DoesValuePass( 1 );

        Assert.IsFalse( doesPass );
    }

    [Test]
    public void DoesValuePass_ForGreaterThan_IsFalse_WhenValueLessThanTarget() {
        TriggerData systemUnderTest = CreateSystem();
        systemUnderTest.TargetValue = 1;
        systemUnderTest.Equality = TriggerEquality.GREATER_THAN;

        bool doesPass = systemUnderTest.DoesValuePass( 0 );

        Assert.IsFalse( doesPass );
    }
}
