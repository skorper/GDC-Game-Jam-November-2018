using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour {
    public OptionsPanel optionsPanel;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsPanel.gameObject.SetActive(!optionsPanel.gameObject.activeSelf);
        }
        if (optionsPanel.gameObject.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
		
	}
}
