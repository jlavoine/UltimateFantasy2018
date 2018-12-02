using UnityEngine;

public interface IFollowPlayerCamera {
    void Move( Vector3 move );
    Vector3 GetPos();
    Quaternion GetRotation();
    string GetName();
}

public class FollowPlayerCamera : MonoBehaviour, IFollowPlayerCamera {
    public GameObject PlayerCharacter;
    public bool ShouldUpdate = true;
    public GameObject TargetTest;
    public GameObject Original;
    public float Speed = 5f;
    public bool IsMain;
    public float TurningRate = 30f;
    public float TotalTime = 3f;

    private Vector3 _startPos;
    private float _startTime;
    private float _distance;
    private Quaternion _startRotation = Quaternion.identity;
    private Quaternion _targetRotation = Quaternion.identity;
    private bool _isMoving = false;
    private Vector3 _offset;
    private Vector3 _myMath;
    private GameObject MovingTo;

	void Start () {
        _startPos = transform.position;

        _startRotation = transform.rotation;        
        UpdateOffset( transform.position );        
        Debug.LogError( _offset );
        _myMath = transform.position + _offset;
	}

    public string GetName() {
        return gameObject.name;
    }

    public Vector3 GetPos() {
        return transform.position;
    }

    public Quaternion GetRotation() {
        return transform.rotation;
    }

    private void UpdateOffset(Vector3 pos) {
        _offset = pos + PlayerCharacter.transform.position;
        _offset = new Vector3( _offset.x, _offset.y - ( PlayerCharacter.transform.position.y * 2 ), _offset.z );
    }

  /*  void Update() {
        if ( IsMain && Input.GetKeyDown( KeyCode.Space ) ) {
            _startTime = 0f;// Time.time;
            _distance = Vector3.Distance( transform.position, TargetTest.transform.position );
            _targetRotation = TargetTest.transform.rotation;
            _isMoving = true;
            _startPos = transform.position;
            MovingTo = TargetTest;
        } else if ( IsMain && Input.GetKeyDown( KeyCode.G ) ) {
            _startTime = 0f;// Time.time;
            _startPos = transform.position;
            _distance = Vector3.Distance( transform.position, Original.transform.position );
            _targetRotation = Original.transform.rotation;
            MovingTo = Original;
            _isMoving = true;
        }
    }*/

    public void Move(Vector3 move) {
        transform.position += move;
    }

    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;
	
	void LateUpdate () {
        if ( _isMoving ) {
            _startTime += Time.deltaTime;
            float fracJourney = _startTime /TotalTime;
            if (fracJourney >= 1f ) {
                fracJourney = 1f;
                _isMoving = false;
                Debug.LogError( MovingTo.transform.position + " vs " + transform.position );       
            }

            Vector3 newPos = Vector3.Lerp( _startPos, MovingTo.transform.position, fracJourney );
            transform.position = newPos;

            Debug.LogError( "Trying to get to " + MovingTo.transform.position );
            //transform.position = Vector3.SmoothDamp( transform.position, TargetTest.transform.position, ref velocity, smoothTime );
            transform.rotation = Quaternion.Lerp( _startRotation, _targetRotation, fracJourney );
            UpdateOffset(newPos);
        }

        if ( ShouldUpdate ) {
           // transform.position = PlayerCharacter.transform.position + _offset;
            //_startPos = transform.position;
        }
	}
}
