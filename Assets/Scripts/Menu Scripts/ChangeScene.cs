using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public string levelToLoad = "";

	public void OnMouseUp()
	 {
	     Application.LoadLevel(levelToLoad); 
	 }
}
