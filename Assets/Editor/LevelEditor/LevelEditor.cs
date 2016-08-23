using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

public class LevelEditor : MonoBehaviour {

	
	void Start () {
        EditorSceneManager.MarkAllScenesDirty();
    }
	
	
}
