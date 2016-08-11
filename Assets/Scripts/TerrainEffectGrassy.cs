using UnityEngine;
using System.Collections;

public class TerrainEffectGrassy : MonoBehaviour {

    public GameObject _bladeOfGrass;

	// Use this for initialization
	void Start () {
	    for ( var i = 0; i < 40; i++)
        {
            var randomPos = transform.position;
            randomPos.x += Random.Range(-0.5f, 0.5f);
            randomPos.z += Random.Range(-0.5f, 0.5f);
            randomPos.y -= .375f;

            var newBlade = (GameObject)Instantiate(_bladeOfGrass, randomPos, Quaternion.identity);
            newBlade.transform.parent = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
