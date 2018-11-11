using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour {

	
	public void musicToggle(){

		AudioSource audioSource = GetComponent<AudioSource>();


		audioSource.mute = !audioSource.mute;

		DontDestroyOnLoad(audioSource);
	}
}
