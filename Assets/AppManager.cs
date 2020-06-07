using UnityEngine;
using System.Collections;

public class AppManager : MonoBehaviour {

    private GameObject debugUI;
    public bool debugMode;

	// Use this for initialization
	void Start () {
        debugUI = GameObject.FindGameObjectWithTag("Debug");
        debugUI.SetActive(debugMode);
	}

    void ToggleDebug () {
        debugMode = !debugMode;
        debugUI.SetActive(debugMode);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
