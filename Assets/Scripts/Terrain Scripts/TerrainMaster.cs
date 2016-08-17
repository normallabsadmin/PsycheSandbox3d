using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TerrainMaster : MonoBehaviour
{

    public bool _editingLevel;
    public bool _previewLevel = false;

    public GameObject _terrainChunk;
    [Range(1f, 100f)]
    public int _mapSize = 1;
    private int _lastMapSize;

    private void Start()
    {
        
    }

    private void Update()
    {
        PreviewLevel();
        RegenerateLevel();

    }

    private void RegenerateLevel()
    {
        if (_lastMapSize != _mapSize) { 
            DeleteChunks();
            GenerateChunks();
        }
        _lastMapSize = _mapSize;
    }

    private void PreviewLevel()
    {
        if (_previewLevel == true)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<TerrainChunk>())
                {
                    child.GetComponent<TerrainChunk>()._runRender = true;
                }
            }
        }
        else if (_previewLevel == false)
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
        float x, z;
        if ( _mapSize == 1)
        {
            x = 0;
            z = 0;
        }
        else
        {
            x = (_mapSize -1) * 5;
            z = (_mapSize - 1) * 5;
        }
       

        for (i = 0; i < _mapSize; i++)// on row 
        {
            for (j = 0; j < _mapSize; j++) //on column
            {
                SpawnChunk(x, z);
                z -= 10;
            }
            z = (_mapSize - 1) * 5;
            j = 0;
            x -= 10;
        }
    }

    private void SpawnChunk(float x, float z)
    {
        var newPosition = transform.position;
        newPosition.x += x;
        newPosition.z += z;
        var newChunk = (GameObject)Instantiate(_terrainChunk, newPosition, Quaternion.identity);
        newChunk.transform.parent = transform;
    }

    private void DeleteChunks()
    {

        while (transform.childCount != 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}

