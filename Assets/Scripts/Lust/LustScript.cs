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

    private float distance;

    private Vector2 moveDistanceVector;

    private Rigidbody2D rig;

   

    // Use this for initialization
    void Start () {

        health = 6;

        Frn = true;

        time = 5; 

        tempTime = time;

        player = GameObject.FindGameObjectWithTag("Player");

        rig = GetComponent<Rigidbody2D>();

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

        if ( health <= 3 ) {
            Walk();

        }

    }

    public void Kiss() {

        Instantiate(kiss, new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.identity);

    }

    public void Punch() {

    }

    public void Pommel () {


    }

    public void Walk () {

        player = GameObject.FindGameObjectWithTag("Player");

        moveDistanceVector = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);

        distance = moveDistanceVector.magnitude;


            if (moveDistanceVector.x > 0) {

                rig.velocity = new Vector2(-moveSpeed, rig.velocity.y);
            }

            if (moveDistanceVector.x < 0) {

                rig.velocity = new Vector2(moveSpeed, rig.velocity.y);

            }


    }

    public void SideStep() {


    }

    public void Wait( float time) {

        



    }
}

