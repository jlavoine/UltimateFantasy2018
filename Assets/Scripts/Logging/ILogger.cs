using UnityEngine;

public interface ILogger {
    void Log( LogSeverity severity, string type, string message );
}

public class EditorLogger : ILogger {
    public void Log( LogSeverity severity, string type, string message ) {
        Debug.Log( "[" + type + "]: " + message );
    }
}