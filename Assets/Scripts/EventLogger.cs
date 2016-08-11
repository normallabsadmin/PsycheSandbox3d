using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventLogger : MonoBehaviour {

    public GameObject _canvasUI;

    private Text _logText;

    private void Start()
    {
       _logText = _canvasUI.gameObject.GetComponentInChildren<Text>();
        //Debug.Log(_logText);
        //WriteToLog("post");
    }

    public void WriteToLog(string LogText)
    {
        _logText.text = LogText;
    }
}
