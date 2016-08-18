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
    public Texture2D _myTexture;

    public TerrainType _currentTerrain;
    private TerrainType _terrainCheck;

    public Texture2D[] _grassLandLayouts;
    public Texture2D[] _forestLayouts;
    public Texture2D[] _riverLayouts;
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
    }

    void Update () {
        RenderPreview();

        if(_terrainCheck != _currentTerrain)
        {
            SwapTerrain();
        }
    }

    private void SwapTerrain()
    {

    }

    private void RenderPreview()
    {
        if (_myMaster._editingLevel)
        {
            _myTexture = _myTerrain._layoutTexture;
            if (_myTexture != _myRenderer.material.mainTexture)
            {
                _myRenderer.material.mainTexture = _myTexture;
            }
        }
    }

}
