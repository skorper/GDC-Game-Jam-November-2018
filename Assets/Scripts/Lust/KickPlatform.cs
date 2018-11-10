using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPlatform : MonoBehaviour {

    public GameObject player;

    public float pushBackSpeed;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // kicks player away from 
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if ( collision.gameObject.CompareTag("Player")) {

            player.transform.GetComponent<PlayerController>().rigi.AddForce(new Vector2(-pushBackSpeed, 1000));

        }
    }
}
