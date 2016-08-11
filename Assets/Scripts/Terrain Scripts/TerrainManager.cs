using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {

    public GameObject _primaryTerrain;
    public GameObject _secondaryTerrain;
    public GameObject _tertiaryTerrain;
    public GameObject _waterTerrain;

    public int _mapSize = 10;

    private Vector3 _spawnPosition;
    private float _originX;
    private float _originZ;


    // Use this for initialization
    void Start () {

        _spawnPosition = transform.position;

        _originX = _spawnPosition.x - _mapSize / 2;
        _originZ = _spawnPosition.z - _mapSize / 2;

        _spawnPosition.x = _originX;
        _spawnPosition.z = _originZ;

        for (var i = 0; i < _mapSize; i++)
        {
            for (var j = 0; j < _mapSize; j++)
            {
                //keep middle clean
                if (_spawnPosition.x < 5f &&
                    _spawnPosition.x > -5f &&
                    _spawnPosition.z < 5f &&
                    _spawnPosition.z > -5f)
                {
                    _spawnPosition.y = 0f;
                }
                else
                {
                    _spawnPosition.y = RandomHeight();
                }
                
                GenerateTerrainBlock();
                _spawnPosition.x++;
            }
            _spawnPosition.x = _originX;
            _spawnPosition.z++;
        }
	}

    private GameObject GenerateTerrainBlock()
    {

        GameObject nextTerrainBlock = (GameObject)Instantiate(RandomTerrain(), _spawnPosition,Quaternion.identity);
        nextTerrainBlock.transform.parent = transform;

        return nextTerrainBlock;
    }

    private GameObject RandomTerrain()
    {
        var dieRoll = Random.Range(0f, 100f);

        if ( dieRoll < 70)
        {
            return _primaryTerrain;
        }
        else if ( dieRoll < 90)
        {
            return _secondaryTerrain;
        }
        else
        {
            return _tertiaryTerrain;
        }
    }

    private float RandomHeight()
    {
        var dieRoll = Random.Range(0f, 100f);

        if (dieRoll < 80)
        {
            return 0f;
        }
        else if (dieRoll < 95)
        {
            return .5f;
        }
        else
        {
            return 1f;
        }
    }
}
