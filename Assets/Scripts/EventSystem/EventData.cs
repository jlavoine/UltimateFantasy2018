using System.Collections.Generic;

public interface IEventData {
    string GetProperty( string key );

    List<ITriggerData> GetTriggers();
}

public class EventData : IEventData {
    public const string LOG_EVENT_TYPE = "Logging";
    public const string MOVE_CAMERA_TYPE = "MoveCamera";
    public const string UNKNOWN_PROPERTY = "???";

    public string EventId;
    public string EventType;
    public Dictionary<string, string> Properties;
    public List<TriggerData> Triggers;

    public string GetProperty( string key ) {
        string property = UNKNOWN_PROPERTY;

        if ( Properties != null ) {
            Properties.TryGetValue(key, out property);
        }

        return property;
    }

    public List<ITriggerData> GetTriggers() {
        List<ITriggerData> triggers = new List<ITriggerData>();

        foreach(TriggerData trigger in Triggers ) {
            triggers.Add( trigger );
        }

        return triggers;
    }
}
