using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Jeffrey Lansford
 */
public class LustScript : MonoBehaviour {

    public float moveSpeed;

    private float time;

    private int health;

    private bool Frn;

    public GameObject kiss;

    private float tempTime;

    public GameObject trapFloor;

    public GameObject trapDoor;

    public GameObject platform;

    public GameObject player;

	// Use this for initialization
	void Start () {

        health = 6;

        Frn = true;

        time = 5; 

        tempTime = time;

        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

        if (tempTime > 0) {

            tempTime -= Time.deltaTime;

        }

        else {

            Kiss();
            tempTime = time;

        }

    }

    public void Kiss() {

        Instantiate(kiss, new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.identity );

    }

    public void SpikeFloor () {


    }
    
    public void Kick () {

        


    }

    public void Punch() {

    }

    public void Pommel () {


    }

    public void Walk () {


    }

    public void SideStep() {


    }

    public void Wait( float time) {

        



    }
}

