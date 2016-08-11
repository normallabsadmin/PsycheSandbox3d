using UnityEngine;
using System.Collections;

public class ActionHaver : MonoBehaviour {

    private MovementHaver _myMovementHaver;
    public GameObject _inspectorPrefab;

    private void Start()
    {
        _myMovementHaver = GetComponent<MovementHaver>();
    }

    public void Inspect()
    {
        var facingSpace = transform.position + _myMovementHaver.ReturnFacingDirection();
        var newInspector = Instantiate(_inspectorPrefab, facingSpace, Quaternion.identity);
        
        /*
        Debug.DrawLine(transform.position,facingSpace,Color.red,5f);
        RaycastHit inspectedHit;
        bool inspectionBool =  Physics.Raycast(transform.position, facingSpace, out inspectedHit, 1.4f);

        if (inspectionBool)
        {
            var inspectionObject = inspectedHit.transform.gameObject;
            Debug.Log("it's a " + inspectionObject.name);
        }
        else
        {
            Debug.Log("nothings there");
        }
        */
    }
}
