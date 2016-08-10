using UnityEngine;
using System.Collections;

public class Simple_AI : MonoBehaviour {

    private MovementHaver _myMovementHaver;

    public float _timeToMove;

    void Start()
    {
        _myMovementHaver = GetComponent<MovementHaver>();
        Invoke("Move", _timeToMove);
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
        var orientation = _myMovementHaver.GetSpriteOrientation();


        #region walking controls 
        if (move == "right")
        {
            _myMovementHaver.WalkRight(orientation);
        }
        else if (move == "left")
        {
            _myMovementHaver.WalkLeft(orientation);
        }
        else if (move == "up")
        {
            _myMovementHaver.WalkLeft(orientation);
        }
        else if (move == "down")
        {
            _myMovementHaver.WalkDown(orientation);
        }
        #endregion

        Invoke("Move", _timeToMove);
    }

 
}
