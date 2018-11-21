using System.Collections.Generic;

public interface IEventData {
    string GetProperty( string key );
}

public class EventData : IEventData {
    public const string LOG_EVENT_TYPE = "Logging";
    public const string UNKNOWN_PROPERTY = "???";

    public string EventId;
    public string EventType;
    public Dictionary<string, string> Properties;

    public string GetProperty( string key ) {
        string property = UNKNOWN_PROPERTY;

        if ( Properties != null ) {
            Properties.TryGetValue(key, out property);
        }

        return property;
    }
}
