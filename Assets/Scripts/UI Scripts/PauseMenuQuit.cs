/*
	PauseMenuQuit.cs
	Written By: Greg De La Torre
	Last Modified: November 2018

	Class allows user to leave to main menu when method OnClick is called.
	Input: Scene Name
	Output: Scene Transition
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //updated to current API

public class PauseMenuQuit : MonoBehaviour {

	/* 
		OnClick Method
		Method transitions from current scene to specified scene
		Parameters: N/A
		Output: Scene
	*/
	public void OnClick()
	{
        SceneManager.LoadScene("mainmenu");
	} /* End OnMouseUp */
}/* End Class */