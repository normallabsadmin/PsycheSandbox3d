using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

    public float _speed = 5.0f;
    private Vector3 _position;
    private Vector3 _direction;
    private Transform _transform;

    private SpriteHaver _mySpriteHaver;
    private Animator _myAnimator;

    private bool _isWalking;
    private bool _isIdle;

    void Start()
    {
        _mySpriteHaver = GetComponentInChildren<SpriteHaver>();
        _myAnimator = GetComponent<Animator>();
        _position = transform.position;
        _transform = transform;
    }

    void SetWalking(bool state)
    {
        if (!_isWalking && state)
        {
            _isWalking = true;
            _myAnimator.SetBool("isWalking", true);
        }
        else if(_isWalking && !state)
        {
            _isWalking = false;
            _myAnimator.SetBool("isWalking", false);
        }
        else
        {

        }
    }

    void Update()
    {
        //get orientation from camera and sprite
        var orientation = _mySpriteHaver.GetDirection();

       
        #region walking controls 
        if (Input.GetKey(KeyCode.D) && _transform.position == _position)
        {
            _position += GetRelativeDirection("right", orientation);
            _direction = GetRelativeDirection("right", orientation);

            _myAnimator.SetFloat("input_x", -1f);
            _myAnimator.SetFloat("input_y", 0f);
        }
        else if (Input.GetKey(KeyCode.A) && _transform.position == _position)
        {
            _position += GetRelativeDirection("left", orientation);
            _direction = GetRelativeDirection("left", orientation);

            _myAnimator.SetFloat("input_x", 1f);
            _myAnimator.SetFloat("input_y", 0f);
        }
        else if (Input.GetKey(KeyCode.W) && _transform.position == _position)
        {
            _position += GetRelativeDirection("up",orientation);
            _direction = GetRelativeDirection("up",orientation);

            _myAnimator.SetFloat("input_x", 0f);
            _myAnimator.SetFloat("input_y", 1f);
        }
        else if (Input.GetKey(KeyCode.S) && _transform.position == _position)
        {
            _position += GetRelativeDirection("down", orientation);
            _direction = GetRelativeDirection("down", orientation);

            _myAnimator.SetFloat("input_x", 0f);
            _myAnimator.SetFloat("input_y", 0 - 1);
        }
        #endregion
        
        Debug.DrawLine(transform.position, _position);
        

        //raycast to position
        if (Physics.Raycast(_transform.position,_direction, .5f))
        {
            _position = _transform.position;
            //Debug.Log("Block in the way");

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _position, Time.deltaTime * _speed);
        }

        #region walking anim checker
        //buttons cause movement 
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            SetWalking(true);
        }
        else
        {
            SetWalking(false);
        }
        #endregion

    }

    private Vector3 GetRelativeDirection(string request,string orientation)
    {
        
        switch (request)
        {
            case "up":
                switch (orientation)
                {
                    case "down":
                        return Vector3.forward;
                    case "right":
                        return Vector3.left;
                    case "up":
                        return Vector3.back;
                    case "left":
                        return Vector3.right;
                    default:
                        return Vector3.forward;
                }
            case "right":
                switch (orientation)
                {
                    case "down":
                        return Vector3.right;
                    case "right":
                        return Vector3.forward;
                    case "up":
                        return Vector3.left;
                    case "left":
                        return Vector3.back;
                    default:
                        return Vector3.right;
                }
            case "down":
                switch (orientation)
                {
                    case "down":
                        return Vector3.back;
                    case "right":
                        return Vector3.right;
                    case "up":
                        return Vector3.forward;
                    case "left":
                        return Vector3.left;
                    default:
                        return Vector3.back;
                }
            case "left":
                switch (orientation)
                {
                    case "down":
                        return Vector3.left;
                    case "right":
                        return Vector3.back;
                    case "up":
                        return Vector3.right;
                    case "left":
                        return Vector3.forward;
                    default:
                        return Vector3.left;
                }
            default:
                switch (orientation)
                {
                    case "down":
                        return Vector3.forward;
                    case "right":
                        return Vector3.left;
                    case "up":
                        return Vector3.back;
                    case "left":
                        return Vector3.right;
                    default:
                        return Vector3.down;
                }
        }
       
    }

}
