using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

    private MovementHaver _myMovementHaver;
    private ActionHaver _myActionHaver;


    void Start()
    {
        _myMovementHaver = GetComponent<MovementHaver>();
        _myActionHaver = GetComponent<ActionHaver>();
    }

    void Update()
    {

        //get orientation from camera and sprite
        var orientation = _myMovementHaver.GetSpriteOrientation();

        #region walking controls 
        //right
        if (Input.GetKey(KeyCode.D))
        {
            _myMovementHaver.WalkRight(orientation);
        }
        //left
        else if (Input.GetKey(KeyCode.A))
        {
            _myMovementHaver.WalkLeft(orientation);
        }
        //up
        else if (Input.GetKey(KeyCode.W))
        {
            _myMovementHaver.WalkUp(orientation);
        }
        //down
        else if (Input.GetKey(KeyCode.S))
        {
            _myMovementHaver.WalkDown(orientation);
        }
        #endregion

        if (Input.GetKeyUp(KeyCode.T))
        {
            _myActionHaver.Inspect();
        }
    }

    

}
