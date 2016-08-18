using UnityEngine;
using System.Collections;

public enum TerrainType
{
    _grassLandLayouts
   , _forestLayouts
   , _riverLayouts
}

[ExecuteInEditMode]
public class TerrainPreview : MonoBehaviour {

    private TerrainMaster _myMaster;
    private TerrainChunk _myTerrain;
    private MeshRenderer _myRenderer;
    public Material _myMaterial;

    public TerrainType _currentTerrain;
    public TerrainType _terrainCheck; 

    public Material[] _grassLandLayouts;
    public Material[] _forestLayouts;
    public Material[] _riverLayouts;
    private int _terrainIndex = 0;
    public bool _randomizeLayout;
    public bool _nextLayout;
    public bool _lastLayout;


    void Start () {
        Setup();       
	}

    void Setup()
    {
        _myMaster = transform.parent.GetComponentInParent<TerrainMaster>();
        _myTerrain = GetComponentInParent<TerrainChunk>();
        _myRenderer = GetComponent<MeshRenderer>();
        SwapMaterial(_myMaterial);
    }

    void Update () {
        EditorControls();
    }

    private void EditorControls()
    {
        if (_terrainCheck != _currentTerrain)
        {
            ChangeLayout(GetRandomLayout(GetTerrainLayouts()));
            _terrainCheck = _currentTerrain;
        }

        if (_randomizeLayout)
        {
            ChangeLayout(GetRandomLayout(GetTerrainLayouts()));
            _randomizeLayout = false;
        }

        if (_nextLayout)
        {
            ChangeLayout(GetNextLayout(GetTerrainLayouts()));
            _nextLayout = false;
        }

        if (_lastLayout)
        {
            ChangeLayout(GetLastLayout(GetTerrainLayouts()));
            _lastLayout = false;
        }
    }

    private void ChangeLayout(Material newLayout)
    {

        _myMaterial = newLayout;
        SwapMaterial(_myMaterial);
        _myTerrain._layoutTexture = (Texture2D)newLayout.mainTexture;
    }

    private Material[] GetTerrainLayouts()
    {

        if(_currentTerrain == TerrainType._grassLandLayouts)
        {
            return _grassLandLayouts;
        }
        else if (_currentTerrain == TerrainType._forestLayouts)
        {
            return _forestLayouts;
        }
        else if (_currentTerrain == TerrainType._riverLayouts)
        {
            return _riverLayouts;
        }

        return _grassLandLayouts; //defualt

        
    }

    private Material GetRandomLayout(Material[] thisLayoutGroup)
    {
        int randomIndex = (int)Random.Range(0f, thisLayoutGroup.Length);
        _terrainIndex = randomIndex;
        return thisLayoutGroup[randomIndex];

    }

    private Material GetNextLayout(Material[] thisLayoutGroup)
    {
        var newIndex = _terrainIndex + 1;

        if (newIndex > thisLayoutGroup.Length)
        {
            newIndex = 0;
        }
        else if (newIndex < 0)
        {
            newIndex = thisLayoutGroup.Length;
        }

        _terrainIndex = newIndex;
        return thisLayoutGroup[newIndex];

    }

    private Material GetLastLayout(Material[] thisLayoutGroup)
    {
        var newIndex = _terrainIndex - 1;

        if (newIndex > thisLayoutGroup.Length)
        {
            newIndex = 0;
        } else if (newIndex < 0)
        {
            newIndex = thisLayoutGroup.Length;
        }

        _terrainIndex = newIndex;
        return thisLayoutGroup[newIndex];

    }


    private void SwapMaterial(Material thisMaterial)
    {
        if (thisMaterial != _myRenderer.sharedMaterial)
        {
            _myRenderer.sharedMaterial = thisMaterial; 
        }
    }

}
