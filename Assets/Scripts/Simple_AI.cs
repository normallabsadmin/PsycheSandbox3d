using UnityEngine;
using System.Collections;

public class Simple_AI : MonoBehaviour {

    public float _speed = 5.0f;
    public float _timeToMove = 2f;
    private Vector3 _position;
    private Vector3 _direction;
    private Transform _transform;

    private SpriteHaver _mySpriteHaver;
    private Animator _myAnimator;

    private bool _isWalking;
    private bool _isIdle;

    private Vector3 _curPos;
    private Vector3 _lastPos;

    void Start()
    {
        _mySpriteHaver = GetComponentInChildren<SpriteHaver>();
        _myAnimator = GetComponent<Animator>();
        _position = transform.position;
        _transform = transform;

        Invoke("Move", _timeToMove);
    }

    void SetWalking(bool state)
    {
        if (!_isWalking && state)
        {
            _isWalking = true;
            _myAnimator.SetBool("isWalking", true);
        }
        else if (_isWalking && !state)
        {
            _isWalking = false;
            _myAnimator.SetBool("isWalking", false);
        }
        else
        {

        }
    }

    private void Move()
    {
        var dieRoll = Random.Range(1f, 100f);
        var move = "idle";
        #region dieRoll
        if(dieRoll < 60)
        {
            move =  "idle";
        }
        else if (dieRoll < 70)
        {
            move = "up";
        }
        else if (dieRoll < 80)
        {
            move = "down";
        }
        else if (dieRoll < 90)
        {
            move = "left";
        }
        else if (dieRoll < 100)
        {
            move = "right";
        }
        else
        {
            move = "idle";
        }
        #endregion

        //get orientation from camera and sprite
        var orientation = _mySpriteHaver.GetDirection();


        #region walking controls 
        if (move == "right" && _transform.position == _position)
        {
            _position += GetRelativeDirection("right", orientation);
            _direction = GetRelativeDirection("right", orientation);

            _myAnimator.SetFloat("input_x", -1f);
            _myAnimator.SetFloat("input_y", 0f);
        }
        else if (move == "left" && _transform.position == _position)
        {
            _position += GetRelativeDirection("left", orientation);
            _direction = GetRelativeDirection("left", orientation);

            _myAnimator.SetFloat("input_x", 1f);
            _myAnimator.SetFloat("input_y", 0f);
        }
        else if (move == "up" && _transform.position == _position)
        {
            _position += GetRelativeDirection("up", orientation);
            _direction = GetRelativeDirection("up", orientation);

            _myAnimator.SetFloat("input_x", 0f);
            _myAnimator.SetFloat("input_y", 1f);
        }
        else if (move == "down" && _transform.position == _position)
        {
            _position += GetRelativeDirection("down", orientation);
            _direction = GetRelativeDirection("down", orientation);

            _myAnimator.SetFloat("input_x", 0f);
            _myAnimator.SetFloat("input_y", 0 - 1);
        }
        #endregion

        

        Debug.DrawLine(transform.position, _position);
        Invoke("Move", _timeToMove);
    }

    void Update()
    {
        _curPos = transform.position;
        if (_curPos == _lastPos)
        {
            SetWalking(false);
        }
        else
        {
            SetWalking(true);
        }
        _lastPos = _curPos;

        //raycast to position
        if (Physics.Raycast(_transform.position, _direction, .5f))
        {
            _position = _transform.position;
            //Debug.Log("Block in the way");

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _position, Time.deltaTime * _speed);
        }

    }

    private Vector3 GetRelativeDirection(string request, string orientation)
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
