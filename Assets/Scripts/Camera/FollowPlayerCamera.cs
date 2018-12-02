using UnityEngine;

public interface IFollowPlayerCamera {
    void Move( Vector3 move );
    Vector3 GetPos();
    Quaternion GetRotation();
    string GetName();
}

public class FollowPlayerCamera : MonoBehaviour, IFollowPlayerCamera {
    public string GetName() {
        return gameObject.name;
    }

    public Vector3 GetPos() {
        return transform.position;
    }

    public Quaternion GetRotation() {
        return transform.rotation;
    }

    public void Move(Vector3 move) {
        transform.position += move;
    }
}
