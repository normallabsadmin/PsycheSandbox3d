using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TerrainBlock : MonoBehaviour {
    public bool _hasTree;

    public GameObject _defaultTree;
    public GameObject _defualtGroundCover;

    [Range(0f, 100f)]
    public float _chanceToSpawnCover;
    public bool _canHaveCover = true;

    void Start()
    {
        UnityEditor.EditorUtility.SetDirty(this);

        if (_defaultTree != null && _hasTree)
        {
            SpawnTree();
        }
        else
        {
            SpawnGroundCover();
        }
    }

    private void SpawnTree()
    {
        var treePos = transform.position;
        treePos.y++;
        var newTree = (GameObject)Instantiate(_defaultTree, treePos, Quaternion.identity);
        newTree.transform.parent = transform;
    }

    private void SpawnGroundCover()
    {
        var d100 = Random.Range(1f, 100f);

        if (_canHaveCover && d100 <= _chanceToSpawnCover)
        {
            var coverPos = transform.position;
            coverPos.y++;
            var newCover = (GameObject)Instantiate(_defualtGroundCover, coverPos, Quaternion.identity);
            newCover.transform.parent = transform;
        }
    }
}
