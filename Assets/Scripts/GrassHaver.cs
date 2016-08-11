using UnityEngine;
using System.Collections;

public class GrassHaver : MonoBehaviour {

    public GameObject _grassyEffect;

	// Use this for initialization
	void Start () {
        var newPostion = transform.position;
        newPostion.y += 1;

        Instantiate(_grassyEffect, newPostion, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
