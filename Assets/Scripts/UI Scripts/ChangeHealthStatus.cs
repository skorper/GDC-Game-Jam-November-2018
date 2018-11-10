using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealthStatus : MonoBehaviour {

	 public Sprite fullHealth;
	 public Sprite midHealth;
	 public Sprite lowHealth;
	 public Sprite noHealth;
	 public GameObject player;
	 protected int healthFlag = 0;


	void Update(){

		if(player.GetComponent<PlayerController>().Health == healthFlag)
			return;

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
	  	else{
	  		healthFlag = 0;
	  		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = noHealth;
	  	}


	}
}
