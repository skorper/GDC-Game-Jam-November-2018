/*
	ChangeHealthStatus.cs
	Written By: Greg De La Torre
	Last Modified: November 2018

	Class changes image displayed in UI to indicate health level.
	Input: Sprites, GameObject
	Output: Sprite
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealthStatus : MonoBehaviour {

	/* Declare sprites needed */
	public Sprite fullHealth;
	public Sprite midHealth;
	public Sprite lowHealth;
	public Sprite noHealth;

	/* Declare player object */
	public GameObject player;

	/* Declare integer flag to determine if image change is necessary */
	protected int healthFlag = 0;


	/* Check player health every update */
	void Update(){

		/* If player health hasn't changed, don't change image */
		if(player.GetComponent<PlayerController>().Health == healthFlag)
			return;

		/* If player health has changes, changed image based on health level */
	 	if(player.GetComponent<PlayerController>().Health == 3){
	 		healthFlag = 3;
	 		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = fullHealth;
	 	}
	 	else if(player.GetComponent<PlayerController>().Health == 2){
	 		healthFlag = 2;
	  		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = midHealth;
	  	}
	 	else if(player.GetComponent<PlayerController>().Health == 1){
	 		healthFlag = 1;
	  		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = lowHealth;
	  	}

	  	/* If player health is 0, remove image */
	  	else{
	  		healthFlag = 0;
	  		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = noHealth;
	  	}
	} /* End Update */
} /* End Class */
