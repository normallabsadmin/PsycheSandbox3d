using UnityEngine;
using System.Collections;

public class SpriteHaver : MonoBehaviour {

    public enum Axis { up, down, left, right, forward, back };
    public enum Facing { up, down, left, right, forward, back };
    public bool reverseFace = false;
    public Axis axis = Axis.up;
    public Camera referenceCamera;

    // return a direction based upon chosen axis
    public Vector3 GetAxis(Axis refAxis)
    {
        switch (refAxis)
        {
            case Axis.down:
                return Vector3.down;
            case Axis.forward:
                return Vector3.forward;
            case Axis.back:
                return Vector3.back;
            case Axis.left:
                return Vector3.left;
            case Axis.right:
                return Vector3.right;
        }

        // default is Vector3.up
        return Vector3.up;
    }

    void Awake()
    {
        // if no camera referenced, grab the main camera
       
          referenceCamera = Camera.main;
    }

    void Update()
    {
        // rotates the object relative to the camera
        Vector3 targetPos = transform.position + referenceCamera.transform.rotation * (reverseFace ? Vector3.forward : Vector3.back);
        Vector3 targetOrientation = referenceCamera.transform.rotation * GetAxis(axis);
        transform.LookAt(targetPos, targetOrientation);
    }

    //gets a string orientation for use with sprite drawing
    public Facing GetDirection()
    {
        var orientation = referenceCamera.transform.rotation * GetAxis(axis);

        //Debug.Log(orientation.z.ToString());

        if (orientation.x < orientation.z)
        {
            if (orientation.x > -0.35)
            {
                return Facing.down;
            }
            else
            {
                return Facing.right;
            }
        }
        else if (orientation.x > orientation.z)
        {
            if (orientation.z < -0.35)
            {
                return Facing.up;
            }
            else
            {
                return Facing.left;
            }
        }
        else
        {
            return Facing.down;
        }
    }
}

