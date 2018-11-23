using System.Collections.Generic;

public interface ITriggerManager {
    bool DoesPass( List<ITriggerData> triggers );
}

public class TriggerManager : ITriggerManager {
    public Dictionary<string, int> PlayerTriggerData = new Dictionary<string, int>();

    public bool DoesPass( List<ITriggerData> triggers ) {
        foreach( ITriggerData trigger in triggers ) {
            int triggerValue = 0;
            PlayerTriggerData.TryGetValue( trigger.GetKey(), out triggerValue );
            if ( !trigger.DoesValuePass( triggerValue ) ) {
                return false;
            }
        }

        return true;
    }

    private bool DoesPlayerHaveTrigger( string triggerName ) {
        return PlayerTriggerData.ContainsKey( triggerName );
    }
}
