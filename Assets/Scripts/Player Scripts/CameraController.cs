using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject _pointOfInterest;
    public float _dampTime = 0.3f;

    private Camera _thisCamera;
    private Vector3 _velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        _pointOfInterest = FindObjectOfType<PlayerContoller>().gameObject;
        _thisCamera = GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update () {
        FollowPlayer();
        RotateCamera();

    }
    private void FollowPlayer()
    {
        if (_pointOfInterest)
        {
            var point  = _thisCamera.WorldToViewportPoint(_pointOfInterest.transform.position);
            var delta  = _pointOfInterest.transform.position - _thisCamera.ViewportToWorldPoint( new Vector3(0.5f, 0.5f, point.z));
            var destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, _dampTime);
        }
    }
    private void RotateCamera()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(_pointOfInterest.transform.position, Vector3.up, 40 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(_pointOfInterest.transform.position, Vector3.up, -40 * Time.deltaTime);
        }
    }
}
