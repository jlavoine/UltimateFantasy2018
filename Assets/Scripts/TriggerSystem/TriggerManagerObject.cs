using UnityEngine;

public class TriggerManagerObject : MonoBehaviour {
    private static ITriggerManager _inst;

    public static ITriggerManager Inst {
        get {
            if (_inst == null) {
                _inst = new TriggerManager();
            }

            return _inst;
        }
    }
}
