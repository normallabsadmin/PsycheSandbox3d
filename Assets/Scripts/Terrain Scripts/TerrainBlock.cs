using UnityEngine;
using System.Collections;

public class TerrainBlock : MonoBehaviour {
    public bool _hasTree;

    public GameObject _defaultTree;

    void Start()
    {
        if (_defaultTree != null && _hasTree)
        {
            var treePos = transform.position;
            treePos.y++;
            var newTree = (GameObject)Instantiate(_defaultTree, treePos, Quaternion.identity);
        }
    }
}
