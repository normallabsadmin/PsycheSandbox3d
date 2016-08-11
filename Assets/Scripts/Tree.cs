using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    private GameObject _mySprite;
    private GameObject _myShadow;

    private void Start()
    {
       
        _mySprite = transform.FindChild("Sprite").gameObject;
        _myShadow = transform.FindChild("Shadow").gameObject;
    }

    private void RandomNudge()
    {

    }
}
