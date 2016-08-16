using UnityEngine;
using System.Collections;

public class TerrainChunk : MonoBehaviour {

    public Texture2D _layoutTexture;
    public int _elevationBump = 0;

    public GameObject _demoCube;
    public GameObject _grassBlock;
    public GameObject _dirtBlock;
    public GameObject _waterBlock;
    public GameObject _sandBlock;
    public GameObject _stoneBlock;

    // Use this for initialization
    void Start () {
       
        int i, j;
        float x = -5;
        float z = -5;

	    if (_layoutTexture != null)
        {
            for ( i = 0; i < 10; i++)// on row 
            {
                for ( j = 0; j < 10; j++) //on column
                { 
                    var thisPixel = _layoutTexture.GetPixel(i, j);
                    SpawnTerrain(thisPixel,x,z);
                    x++;
                    #region debugCode
                        /*
                         * this code was used to test reading sprites
                          Debug.Log(thisPixel);
                        var newCube = (GameObject)Instantiate(_demoCube, transform.position, Quaternion.identity);
                        newCube.GetComponent<Renderer>().material.color = thisPixel;
                        newCube.transform.parent = transform;
                        newCube.transform.position = new Vector3(i, 1, j);

                        var hex = ColorUtility.ToHtmlStringRGBA(thisPixel);
                        if(hex == "C412FFFF")
                        {
                            Debug.Log("Win!");
                        }
                        */
                        #endregion
                }
                x = -5;
                j = 0;
                z++;
            }
        }
	}
	
    private void SpawnTerrain(Color pixel, float x, float z)
    {
        var hexString = ColorUtility.ToHtmlStringRGBA(pixel);

        GameObject terrainToSpawn;
        float heightAdjust;
        bool hasTree = false;
        Vector3 posTerrain = new Vector3(x, 1, z);

        switch (hexString)
        {
            case "C412FFFF ":
                terrainToSpawn = _grassBlock;
                heightAdjust = -.5;
                hasTree = true;
                break;
            default:
                terrainToSpawn = _grassBlock;
                heightAdjust = 0;
                hasTree = false;
                break;

        }

        var newTerrain = (GameObject)Instantiate(terrainToSpawn, posTerrain, Quaternion.identity);
        var terrainComp = newTerrain.GetComponent<Terrain>();
        terrainComp._hasTree = hasTree;
    }
}
