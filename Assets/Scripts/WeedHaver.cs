using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class WeedHaver : MonoBehaviour {

    public Sprite[] _groundCoverSprites;
    

	// Use this for initialization
	void Start () {
        UnityEditor.EditorUtility.SetDirty(this);

        var mySprite = GetComponentInChildren<SpriteRenderer>();

        var randomSprite = Random.Range(0, _groundCoverSprites.Length);

        mySprite.sprite = _groundCoverSprites[randomSprite];
        
	}
	
	
}
