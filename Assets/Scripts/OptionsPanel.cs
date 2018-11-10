using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour {
    public Button exitGameButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitGame()
    {
        Debug.Log("Trying to exit game will not work in editor.");
        Application.Quit();
    }
}
