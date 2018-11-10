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

    public PlayerController playerController;

    private float distance;

    private Vector2 moveDistanceVector;

    private Rigidbody2D rig;

    GameObject kissSpawn;

    public AudioClip Laugh;

    public AudioClip Oof;

    AudioSource soundPlayer;

    public GameObject[] groundPlayform;

    private float invulerabilityTimer = 0;

    private float invulerabilitytime = 1.5f;

    private bool bossDead;

    public GameObject Door; 
   

    // Use this for initialization
    void Start () {

        health = 6;

        soundPlayer = gameObject.GetComponent<AudioSource>();

        kissSpawn = GameObject.Find("KissSpawn");

        // health set to 6
        health = 6;

        // in Francesca form 
        Frn = true;


        //time = 5; 
        
        // wait in seconds
        tempTime = 5;

        // finds player
        player = GameObject.FindGameObjectWithTag("Player");

        playerController = player.gameObject.GetComponent<PlayerController>();

        rig = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if (invulerabilityTimer > 0)
        {
            invulerabilityTimer -= Time.deltaTime;
        }

        // does Kiss attack every 5 seconds
        if (tempTime > 0) {

            tempTime -= Time.deltaTime;

        }

        else if (Frn) {

            Kiss();
            tempTime = 5;

        }

        // walk below half health
        if (health <= 3) {

            Frn = false;

            Walk();

            Destroy(groundPlayform[0]);

            Destroy(groundPlayform[1]);

        }

        if ( health <= 0 ) {

            Instantiate(Door,new Vector3( 12, -6, 0 ) , Quaternion.identity );

            Destroy(gameObject);

        }

    }

    // method to launch hearts that follow player and spilt into 3 little hearts in HeartProjectile script
    public void Kiss() {

        Instantiate(kiss,kissSpawn.transform.position, Quaternion.identity);
        //soundPlayer.clip = Oof;

    }

    public void Punch() {

    }

    public void Pommel () {


    }

    // makes Lust goes toward player
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

    public void Wait() {

        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerAttack" && invulerabilityTimer <= 0)
        {
            health -= 1;
        }
    }

}

