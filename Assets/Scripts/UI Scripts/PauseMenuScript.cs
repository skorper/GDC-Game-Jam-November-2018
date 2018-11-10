/*
	PauseMenuScript.cs
	Written By: Greg De La Torre
	Last Modified: November 2018

	Class triggers and disables pause menu based on user input.
	Input: Sprites, GameObject
	Output: Sprite
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

	/* Declare pause menu object */
	public GameObject pauseObjects;

	void Start () {

		Time.timeScale = 1;
		
		hidePaused();

	}
	
	/* 
		Check for escape key every Update. 
		If escape key is hit, pause or unpause time and reveal pause menu.
	*/
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){

			if(Time.timeScale == 1){

				Time.timeScale = 0;

				showPaused();
			}
			else if(Time.timeScale == 0){

				Time.timeScale = 1;

				hidePaused();
			}

		}
	}


	/* Reveal pause menu */
	public void showPaused(){


			pauseObjects.SetActive(true);
		
	}

	/* Hide pause menu */
	public void hidePaused(){


			pauseObjects.SetActive(false);

		
	}

}
