/*
	PauseMenuRestart.cs
	Written By: Greg De La Torre
	Last Modified: November 2018

	Class allows user to assign a scene to be switched to when method OnClick is called.
	Input: Scene Name
	Output: Scene Transition
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuRestart : MonoBehaviour {

	/* 
		OnClick Method
		Method transitions from current scene to specified scene
		Parameters: N/A
		Output: Scene
	*/
	public void OnClick()
	{
		Application.LoadLevel(Application.loadedLevel); 
	} /* End OnMouseUp */
}/* End Class */