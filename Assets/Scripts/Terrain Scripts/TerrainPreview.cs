using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TerrainPreview : MonoBehaviour {

    public TerrainMaster _myMaster;
    public TerrainChunk _myTerrain;
    public MeshRenderer _myRenderer;

    public Texture2D _myTexture;

	// Use this for initialization
	void Start () {
        _myMaster = transform.parent.GetComponentInParent<TerrainMaster>();
        _myTerrain = GetComponentInParent<TerrainChunk>();
        _myRenderer = GetComponent<MeshRenderer>();
       
	}

    // Update is called once per frame


    void Update () {
        if (_myMaster._editingLevel) { 
            _myTexture = _myTerrain._layoutTexture;
            if(_myTexture != _myRenderer.material.mainTexture)
            {
                 _myRenderer.material.mainTexture = _myTexture;
            }
        }
    }

}
