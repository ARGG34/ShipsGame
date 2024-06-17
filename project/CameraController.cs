using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _rotationSpeed = 5;

    public Vector3 _cameraOffset;

    public Transform _FollowObject;
    
    public float _zoomDelta = 0.05f;
    
    private bool _follow;

    private Transform _subject;
    private Transform _transform;
    private Vector3 _offset;

    private float _zoom = 1;
   
    void Awake()
    {
        _transform = transform;
        _offset = _cameraOffset;
        
        _zoom = 1;
    }

    
    // Old 
    // void Update()
    // {
    //     TryRotate();
    // }

    private bool _zoomed;
    private bool _rotated;

    private void LateUpdate()
    {
        if (!_follow)
            return;

        _zoomed = TryZoom();
        _rotated = TryRotate();
        
        if (_follow || _zoomed || _rotated)
        {
            SetCameraPosition();
        }
    }
    

    public void AllowFollow() => _follow = true;

    public void Reset()
    {
        _offset = _cameraOffset;
        _zoom = 1;
    }


    // Old 
    // private void TryRotate()
    // {
    //     if (!_follow)
    //         return;
    //     
    //     if (Input.GetMouseButton(0))
    //     {
    //         var rotation = Input.GetAxis("Mouse X") * _rotationSpeed;
    //         _subject.transform.Rotate(0, rotation, 0);
    //     }
    // }

    private bool TryRotate()
    {
        if (Input.GetMouseButton(0))
        {
            _offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up) * _offset;
            return true;
        }
        return false;
    }
    

    private bool TryZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _zoom += _zoomDelta;
            return true;
        }
        
        if (Input.mouseScrollDelta.y < 0)
        {
            _zoom -= _zoomDelta;
            return true;
        }

        return false;
    }

    private void SetCameraPosition()
    {
        _transform.position = _FollowObject.position + _offset * _zoom;
        _transform.LookAt(_FollowObject.position);
    }

}
