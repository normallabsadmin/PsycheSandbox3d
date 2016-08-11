using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public bool _nudgeTrees = false;
    [Range(0.1f,0.4f)]
    public float _nudge = 0.2f;
    private GameObject _mySprite;
    private GameObject _myShadow;

    private void Start()
    {
       
        _mySprite = transform.FindChild("Sprite").gameObject;
        _myShadow = transform.FindChild("Shadows").gameObject;

        if (_nudgeTrees) { 
            RandomNudge();
        }
    }

    private void RandomNudge()
    {
        var nudgePosition = transform.position;
        nudgePosition.x += Random.Range(-0.2f, 0.2f);
        nudgePosition.z += Random.Range(-0.2f, 0.2f);

       
        _mySprite.transform.position = new Vector3(nudgePosition.x,
            _mySprite.transform.position.y, nudgePosition.z);


        _myShadow.transform.position = new Vector3(nudgePosition.x,
            _myShadow.transform.position.y, nudgePosition.z);
    }
}
