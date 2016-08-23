using UnityEngine;
using System.Collections;

public class MovementHaver : MonoBehaviour {


    public float _speed = 5.0f;
    public enum Facing { up, down, left, right, forward, back };

    private Animator _myAnimator;
    private SpriteHaver _mySpriteHaver;

    private Vector3 _position;
    private Vector3 _direction;
    private Facing _lastFace = Facing.down; //last direction you turned to face
    private Transform _transform;
    private bool _isWalking;
    private bool _isIdle;
    private Vector3 _curPos;
    private Vector3 _lastPos;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
        _mySpriteHaver = GetComponentInChildren<SpriteHaver>();

        _position = transform.position;
        _transform = transform;
    }

    private void LateUpdate()
    {
        AnimateWalk();
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, _position);

        //raycast to position get object
        RaycastHit objectToCheck;
        var obstacleBool = Physics.Raycast(_transform.position, _direction, out objectToCheck, 0.5f);


        if (obstacleBool)
        {
            if (objectToCheck.transform.gameObject.GetComponent<Collider>().isTrigger)
            {
                CommitMovment();
            }
            else
            {
                _position = _transform.position;
                Debug.Log("Block in the way");
            }

        }
        else //goto postion
        {
            CommitMovment();
        }
    }

    private void CommitMovment()
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, Time.deltaTime * _speed);
    }

    private void AnimateWalk()
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
    }

    private void SetWalking(bool state)
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

    private Vector3 GetRelativeDirection(Facing request, Facing orientation)
    {

        switch (request)
        {
            case Facing.up:
                _lastFace = Facing.up;
                switch (orientation)
                {
                    case Facing.down:
                        return Vector3.forward;
                    case Facing.right:
                        return Vector3.left;
                    case Facing.up:
                        return Vector3.back;
                    case Facing.left:
                        return Vector3.right;
                    default:
                        return Vector3.forward;
                }
            case Facing.right:
                _lastFace = Facing.right;
                switch (orientation)
                {
                    case Facing.down:
                        return Vector3.right;
                    case Facing.right:
                        return Vector3.forward;
                    case Facing.up:
                        return Vector3.left;
                    case Facing.left:
                        return Vector3.back;
                    default:
                        return Vector3.right;
                }
            case Facing.down:
                _lastFace = Facing.down;
                switch (orientation)
                {
                    case Facing.down:
                        return Vector3.back;
                    case Facing.right:
                        return Vector3.right;
                    case Facing.up:
                        return Vector3.forward;
                    case Facing.left:
                        return Vector3.left;
                    default:
                        return Vector3.back;
                }
            case Facing.left:
                _lastFace = Facing.left;
                switch (orientation)
                {
                    case Facing.down:
                        return Vector3.left;
                    case Facing.right:
                        return Vector3.back;
                    case Facing.up:
                        return Vector3.right;
                    case Facing.left:
                        return Vector3.forward;
                    default:
                        return Vector3.left;
                }
            default:
                _lastFace = Facing.down;
                switch (orientation)
                {
                    case Facing.down:
                        return Vector3.forward;
                    case Facing.right:
                        return Vector3.left;
                    case Facing.up:
                        return Vector3.back;
                    case Facing.left:
                        return Vector3.right;
                    default:
                        return Vector3.down;
                }
        }
    }

    public Facing GetSpriteOrientation()
    {
        return (MovementHaver.Facing)_mySpriteHaver.GetDirection();
    }

    public void WalkRight(Facing orientation)
    {
        if(_transform.position == _position) { 
            _position += GetRelativeDirection(Facing.right, orientation);
            _direction = GetRelativeDirection(Facing.right, orientation);

            _myAnimator.SetFloat("input_x", -1f);
            _myAnimator.SetFloat("input_y", 0f);
        }
    }
    public void WalkLeft(Facing orientation)
    {
        if (_transform.position == _position)
        {
            _position += GetRelativeDirection(Facing.left, orientation);
            _direction = GetRelativeDirection(Facing.left, orientation);

            _myAnimator.SetFloat("input_x", 1f);
            _myAnimator.SetFloat("input_y", 0f);
        }
    }
    public void WalkUp(Facing orientation)
    {
        if (_transform.position == _position)
        {
            _position += GetRelativeDirection(Facing.up, orientation);
            _direction = GetRelativeDirection(Facing.up, orientation);

            _myAnimator.SetFloat("input_x", 0f);
            _myAnimator.SetFloat("input_y", 1f);
        }
    }
    public void WalkDown(Facing orientation)
    {
        if (_transform.position == _position)
        {
            _position += GetRelativeDirection(Facing.down, orientation);
            _direction = GetRelativeDirection(Facing.down, orientation);

            _myAnimator.SetFloat("input_x", 0f);
            _myAnimator.SetFloat("input_y", 0 - 1);
        }
    }

    public Vector3 ReturnFacingDirection()
    {
        return GetRelativeDirection(_lastFace, GetSpriteOrientation());
    }
}
