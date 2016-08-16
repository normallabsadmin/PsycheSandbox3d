using UnityEngine;
using System.Collections;

public class TerrainChunk : MonoBehaviour {

    public Texture2D _layoutTexture;
    public GameObject _demoCube;

	// Use this for initialization
	void Start () {
       
        int i, j;

	    if (_layoutTexture != null)
        {
            for ( i = 0; i < 10; i++)// on row 
            {
                for ( j = 0; j < 10; j++) //on column
                {
                    
                    //var thisPixel = _layoutTexture.GetPixel(j,i);
                    var x = (i * 10);
                    var y = (j * 10);
                    Debug.Log("X:" + x + " | Y:" + y);
                    
                    var thisPixelGroup = _layoutTexture.GetPixels(x, y, 10, 10);
                    var thisPixel = thisPixelGroup[10];
                    //Debug.Log(thisPixel);
                   
                    var newCube = (GameObject)Instantiate(_demoCube, transform.position, Quaternion.identity);
                    newCube.GetComponent<Renderer>().material.color = thisPixel;
                    newCube.transform.parent = transform;
                    newCube.transform.position = new Vector3(i, 1, j);
                    

                }
                j = 0;
            }
           
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
