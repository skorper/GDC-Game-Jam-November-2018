using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPlatform : MonoBehaviour {

    public GameObject player;

    public float pushBackSpeed;

    private float resetTimer = 0;

    private float resetTime = 3;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
		
        if(resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
        }

	}

    // kicks player away from 
    private void OnTriggerStay2D(Collider2D collision) {
        
        if ( collision.gameObject.CompareTag("Player") && resetTimer <= 0) {

            player.transform.GetComponent<PlayerController>().rigi.AddForce(new Vector2(-pushBackSpeed, 1000));
            resetTimer = resetTime;
        }
    }
}
