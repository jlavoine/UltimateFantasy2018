using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class EventsManager : MonoBehaviour {
    public static EventsManager Inst;

    public TextAsset AllEventData;

    private Dictionary<string, EventData> _allEvents;

    public void Start() {
        Inst = this;

        _allEvents = JsonConvert.DeserializeObject<Dictionary<string, EventData>>( AllEventData.text );
    }

    public IGameEvent GetEvent( string key ) {
        EventData data = _allEvents[key];

        if (data != null ) {
            if (data.EventType == EventData.LOG_EVENT_TYPE) {
                return new LogEvent( new EditorLogger(), data, TriggerManagerObject.Inst );
            }
        }

        return null;
    }
}
