using UnityEngine;
using System.Collections;

public class Inspector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var contents = Physics.OverlapBox(transform.position, new Vector3(.25f, .25f, .25f));

        foreach ( var col in contents)
        {
            if (col.gameObject.GetComponent<EntityHaver>())
            {
                var entity = col.gameObject.GetComponent<EntityHaver>();
                Debug.Log("Here there is " + entity._InspectionName);
            }
            
        }

        Destroy(gameObject);
	}
	
	
}
