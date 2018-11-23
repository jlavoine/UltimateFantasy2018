using NUnit.Framework;
using NSubstitute;

public class LogEventTests {
    private ILogger MockLogger;
    private IEventData MockData;
    private ITriggerManager MockTriggerManager;

    [SetUp]
    public void BeforeTest() {
        MockLogger = Substitute.For<ILogger>();
        MockData = Substitute.For<IEventData>();
        MockTriggerManager = Substitute.For<ITriggerManager>();
    }

    private LogEvent CreateSystem() {
        return new LogEvent( MockLogger, MockData, MockTriggerManager );
    }

    [Test]
    public void WhenExecuted_InfoLogWithMessage() {
        MockData.GetProperty( LogEvent.MESSAGE_PROPERTY ).Returns( "TestLog" );
        LogEvent systemUnderTest = CreateSystem();

        systemUnderTest.Execute();

        MockLogger.Received().Log( LogSeverity.Info, LogEvent.LOG_TYPE, "TestLog" );
    }
}
