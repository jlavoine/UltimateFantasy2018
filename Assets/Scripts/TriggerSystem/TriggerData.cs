
public interface ITriggerData {
    string GetKey();
    bool DoesValuePass( int playerValue );
}

public class TriggerData : ITriggerData {
    public string Key;
    public TriggerEquality Equality;
    public int TargetValue;

    public string GetKey() { return Key; }

    public bool DoesValuePass( int playerValue ) {
        bool doesPass = false;

        switch(Equality) {
            case TriggerEquality.EQUALS:
                doesPass = playerValue == TargetValue;
                break;
            case TriggerEquality.NOT_EQUALS:
                doesPass = playerValue != TargetValue;
                break;
            case TriggerEquality.LESS_THAN:
                doesPass = playerValue < TargetValue;
                break;
            case TriggerEquality.GREATER_THAN:
                doesPass = playerValue > TargetValue;
                break;
        }

        return doesPass;
    }
}
