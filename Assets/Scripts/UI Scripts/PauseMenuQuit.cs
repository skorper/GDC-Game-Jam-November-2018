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

public class PauseMenuQuit : MonoBehaviour {

	/* 
		OnClick Method
		Method transitions from current scene to specified scene
		Parameters: N/A
		Output: Scene
	*/
	public void OnClick()
	{
		Application.LoadLevel("mainmenu"); 
	} /* End OnMouseUp */
}/* End Class */