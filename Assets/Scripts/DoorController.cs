using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/*
	Door Controller
	Author: Stepheny Perez
	-----------------------
	Attach to each door in the Door Room to control 
	animation and scene loading.
 */
public class DoorController : MonoBehaviour 
{
	// private Animator animator;
	public String sceneToLoad;

	void Start()
	{
		// animator = GetComponent<Animator>();
	}

	void LoadScene()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	// No door animation provided 
	// void AnimateDoor()
	// {
	// 	//TODO need to create an animation called OpenDoor for each door
	// 	animator.SetTrigger("OpenDoor");
	// }

	public void DoorActivated()
	{
		// AnimateDoor();
		LoadScene();
	}
}
