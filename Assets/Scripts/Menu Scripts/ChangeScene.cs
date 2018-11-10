/*
	ChangeScene.cs
	Written By: Greg De La Torre
	Last Modified: November 2018

	Class allows user to assign a scene to be switched to when method OnMouseUp is called.
	Input: Scene Name
	Output: Scene Transition
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //keep getting spammed warnings so i updated this script - Alex

public class ChangeScene : MonoBehaviour {

	/* Declare empty string for input in development environment */
	public string levelToLoad = "";

	/* 
		OnMouseUp Method
		Method transitions from current scene to specified scene
		Parameters: N/A
		Output: Scene
	*/
	public void OnMouseUp()
	 {
	     SceneManager.LoadScene(levelToLoad); 
	 } /* End OnMouseUp */
}/* End Class */
