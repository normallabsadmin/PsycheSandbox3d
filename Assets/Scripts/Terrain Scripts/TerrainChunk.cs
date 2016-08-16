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
            //grass with tree
            //low gwt
            case "C412FFFF":
                terrainToSpawn = _grassBlock;
                heightAdjust = -0.5f;
                hasTree = true;
                break;
           //flat gwt
            case "B200FFff":
                terrainToSpawn = _grassBlock;
                heightAdjust = 0f;
                hasTree = true;
                break;
            //high gwt
            case "9300E0FF":
                terrainToSpawn = _grassBlock;
                heightAdjust = 0.5f;
                hasTree = true;
                break;
            //next level gwt
            case "480095FF":
                terrainToSpawn = _grassBlock;
                heightAdjust = 1f;
                hasTree = true;
                break;

            //grass
            //low grass
            case "179625FF":
                terrainToSpawn = _grassBlock;
                heightAdjust = -0.5f;
                hasTree = false;
                break;
            //flat grass
            case "007F0EFF":
                terrainToSpawn = _grassBlock;
                heightAdjust = 0f;
                hasTree = false;
                break;
            //high grass
            case "005100FF":
                terrainToSpawn = _grassBlock;
                heightAdjust = 0.5f;
                hasTree = false;
                break;
            //next level grass
            case "002900FF":
                terrainToSpawn = _grassBlock;
                heightAdjust = 1f;
                hasTree = false;
                break;

            //water
            //low water
            case "173DFFFF":
                terrainToSpawn = _waterBlock;
                heightAdjust = -0.5f;
                hasTree = false;
                break;
            //flat water
            case "0026FFFF":
                terrainToSpawn = _waterBlock;
                heightAdjust = 0f;
                hasTree = false;
                break;
            //high water
            case "0000D1FF":
                terrainToSpawn = _waterBlock;
                heightAdjust = 0.5f;
                hasTree = false;
                break;
            //next level water
            case "0000A9FF":
                terrainToSpawn = _waterBlock;
                heightAdjust = 1f;
                hasTree = false;
                break;

            //stone
            //low stone
            case "979797FF":
                terrainToSpawn = _stoneBlock;
                heightAdjust = -0.5f;
                hasTree = false;
                break;
            //flat stone
            case "808080FF":
                terrainToSpawn = _stoneBlock;
                heightAdjust = 0f;
                hasTree = false;
                break;
            //high stone
            case "525252FF":
                terrainToSpawn = _stoneBlock;
                heightAdjust = 0.5f;
                hasTree = false;
                break;
            //next level stone
            case "2A2A2AFF":
                terrainToSpawn = _stoneBlock;
                heightAdjust = 1f;
                hasTree = false;
                break;

            //sand
            //low sand
            case "FFEF17FF":
                terrainToSpawn = _sandBlock;
                heightAdjust = -0.5f;
                hasTree = false;
                break;
            //flat sand
            case "FFD800FF":
                terrainToSpawn = _sandBlock;
                heightAdjust = 0f;
                hasTree = false;
                break;
            //high sand
            case "D1AA00FF":
                terrainToSpawn = _sandBlock;
                heightAdjust = 0.5f;
                hasTree = false;
                break;
            //next level sand
            case "916A00FF":
                terrainToSpawn = _sandBlock;
                heightAdjust = 1f;
                hasTree = false;
                break;

            //dirt
            //low dirt
            case "A65A27FF":
                terrainToSpawn = _dirtBlock;
                heightAdjust = -0.5f;
                hasTree = false;
                break;
            //flat dirt
            case "7F3300FF":
                terrainToSpawn = _dirtBlock;
                heightAdjust = 0f;
                hasTree = false;
                break;
            //high dirt
            case "621600FF":
                terrainToSpawn = _dirtBlock;
                heightAdjust = 0.5f;
                hasTree = false;
                break;
            //next level dirt
            case "220000FF":
                terrainToSpawn = _dirtBlock;
                heightAdjust = 1f;
                hasTree = false;
                break;

            default:
                terrainToSpawn = _dirtBlock;
                heightAdjust = 0;
                hasTree = false;
                break;

        }

        var newTerrain = (GameObject)Instantiate(terrainToSpawn, posTerrain, Quaternion.identity);
        var terrainComp = newTerrain.GetComponent<Terrain>();
        terrainComp._hasTree = hasTree;
    }
}
