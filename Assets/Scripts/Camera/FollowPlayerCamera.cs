using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour {
    public GameObject PlayerCharacter;

    private Vector3 _offset;

	void Start () {
        _offset = transform.position + PlayerCharacter.transform.position;
	}
	
	void LateUpdate () {
        transform.position = PlayerCharacter.transform.position + _offset;
	}
}
