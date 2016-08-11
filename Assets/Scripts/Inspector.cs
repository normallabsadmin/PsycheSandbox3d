using UnityEngine;
using System.Collections;

public class Inspector : MonoBehaviour {

    public EventLogger _myEventLogger;

	// Use this for initialization
	void Start () {
       
        //Debug.Log(_myEventLogger);

        var contents = Physics.OverlapBox(transform.position, new Vector3(.25f, .25f, .25f));

        string csv = "";

        foreach ( var col in contents)
        {
            if (col.gameObject.GetComponent<EntityHaver>())
            {
                var entity = col.gameObject.GetComponent<EntityHaver>();
                csv = csv + entity._InspectionName + ",";
               
            }
            
        }

        var inspectionString = "Here there is " + csv;
        _myEventLogger.WriteToLog(inspectionString);

        Destroy(gameObject);
	}
	
	
}
