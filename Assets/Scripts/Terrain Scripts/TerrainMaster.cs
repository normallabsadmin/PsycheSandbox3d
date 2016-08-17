using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TerrainMaster : MonoBehaviour {

    public bool _editingLevel;
    public bool _previewLevel;

    public GameObject _terrainChunk;
    [Range(1f,100f)]
    public int _mapSize = 1;

    private void Start()
    {
        GenerateChunks();
    }

    private void Update()
    {
        if (_previewLevel)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<TerrainChunk>())
                {
                    child.GetComponent<TerrainChunk>()._runRender = true;
                }
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<TerrainChunk>())
                {
                    child.GetComponent<TerrainChunk>()._runRender = false;
                }
            }
        }
    }

    public void GenerateChunks()
    {
        var chunkSpace = _mapSize * 10;
        int i, j;
        float x = 4.5f;
        float z = 4.5f;

        for (i = 0; i < 10; i++)// on row 
        {
            for (j = 0; j < 10; j++) //on column
            {
                SpawnChunk(x,z);
            }
            z = 4.5f;
            j = 0;
            x--;
        }
    }

    private void SpawnChunk(float x, float z)
    {
        var newPosition = transform.position;
        newPosition.x += x;
        newPosition.z += z;
        var newChunk = (GameObject)Instantiate(_terrainChunk, newPosition, Quaternion.identity);
    }
}

