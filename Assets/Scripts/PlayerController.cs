﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by Alexander (Sep)
 * 575-386-7531
 * 
 */

 //Modified by Jeff L.

 /* 
  * Modified by Greg De La Torre 
  * Modified on Saturday, Nov. 10, 2018
  * Added state integration for animations, including variables and new method "changeState"
  *
  */

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float speedLimit;
    private float invulterabilityTimer;

    public int currentWeapon; //the index of weapon assests, go to WeaponsAndAbilites method for more info
    public int Health;

    private bool onGround = false;
    public Rigidbody2D rigi; // was private
    private PlayerWeapons Weps;
    private GameObject door;
    private GameObject mainCamera;

    public PhysicsMaterial2D PlayerDefault;
    public PhysicsMaterial2D PlayerJump;
    public BoxCollider2D PlayerPhysicalHitbox;


    /* Initialize animator */
    Animator animate;


    /* Added flags to keep track of direction and state for animation*/
    const int STATE_IDLE = 0;
    const int STATE_WALK = 1;
    const int STATE_STAB = 2;

    const int RIGHT = 0;
    const int LEFT = 1;

    int _currentAnimationState = STATE_IDLE;
    int _currentAnimationDirection = RIGHT;


    
	void Start ()
    {

        /* get animator */
        animate = this.GetComponent<Animator>();


        Health = 1;
        rigi = gameObject.GetComponent<Rigidbody2D>();
        Weps = gameObject.GetComponent<PlayerWeapons>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Weps.SwapWeapons("sword", "");

    }
	

	void Update ()
    {
        Movement();

        if(invulterabilityTimer > 0)
        {
            invulterabilityTimer -= Time.deltaTime;
        }

    }

    void Movement()
    {
        //movement inputs
        if (Input.GetKey("a") && !Input.GetKey("d"))//move left
        {
            /* Call on changeState method to change state */
            changeState(STATE_WALK, LEFT);

            rigi.AddForce(new Vector2(-moveSpeed, 0));

        }

        if (Input.GetKey("d") && !Input.GetKey("a"))//move right
        {
            /* Call on changeState method to change state */
            changeState(STATE_WALK, RIGHT);

            rigi.AddForce(new Vector2(moveSpeed, 0));
        }

        if (Input.GetKeyDown("space") && onGround) //jump, can only go if on the ground
        {
            rigi.AddForce(new Vector2(0, jumpForce));
        }

        if (onGround)
        {
            PlayerPhysicalHitbox.sharedMaterial = PlayerDefault;
        } 
        else 
        {
            PlayerPhysicalHitbox.sharedMaterial = PlayerJump;
        }

        //speed limit x
        if(rigi.velocity.x > speedLimit)//check to see if max speed in x direction
        {
            rigi.velocity = new Vector2(speedLimit, rigi.velocity.y);
        }

        if (rigi.velocity.x < -speedLimit)//check to see if max speed in -x direction
        {
            rigi.velocity = new Vector2(-speedLimit, rigi.velocity.y);
        }
        
        //change weapons


    }

    void TakeDamage()
    {
        float InvTime = 3;

        invulterabilityTimer = InvTime;

        Health -= 1;

        Debug.Log("Lose health");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "EnemyAttack" && invulterabilityTimer <= 0)
        {
            TakeDamage();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
         onGround = true;

        if (collision.gameObject.tag == "EnemyAttack" && invulterabilityTimer <= 0)
        {
            TakeDamage();
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door" && Input.GetKeyUp("e"))
        {
            collision.gameObject.GetComponent<DoorController>().DoorActivated();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         onGround = false;
    }


    /*  
        changeState method
        Parameters: int, int
        Returns: N/A
        changeState manages and changes the state of the player animation based on user input. 

    */

    void changeState(int state, int direction){

        if (_currentAnimationState == state && _currentAnimationDirection == direction)
            return;
        switch (state)
        {
            case STATE_WALK:
                animate.SetInteger("State", STATE_WALK);
                break;

            case STATE_IDLE:
                animate.SetInteger("State", STATE_IDLE);
                break;                

            case STATE_STAB:
                animate.SetInteger("State", STATE_STAB);
                break;   
        }

        switch(direction)
        {
            case RIGHT:
                animate.SetInteger("Direction", RIGHT);
                break;
            case LEFT:
                animate.SetInteger("Direction", LEFT);
                break;
        }

        _currentAnimationState = state;
        _currentAnimationDirection = direction;

    }






}
//rigi.AddForce(moveSpeed * (float)Math.Cos((moveRadians)), 0, moveSpeed * (float)Math.Sin((moveRadians)));