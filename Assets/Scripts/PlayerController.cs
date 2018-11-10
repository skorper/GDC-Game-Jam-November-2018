using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by Alexander (Sep)
 * 575-386-7531
 * 
 */
public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float speedLimit;
    public int currentWeapon; //the index of weapon assests, go to WeaponsAndAbilites method for more info

    private bool onGround = false;
    private Rigidbody2D rigi;
    private PlayerWeapons Weps;

    
	void Start ()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        Weps = gameObject.GetComponent<PlayerWeapons>();
        Weps.SwapWeapons("sword", "");

    }
	

	void Update ()
    {
        Movement();

    }

    void Movement()
    {
        //movement inputs
        if (Input.GetKey("a") && !Input.GetKey("d"))//move left
        {
            rigi.AddForce(new Vector2(-moveSpeed, 0));
        }

        if (Input.GetKey("d") && !Input.GetKey("a"))//move right
        {
            rigi.AddForce(new Vector2(moveSpeed, 0));
        }

        if (Input.GetKeyDown("space") && onGround) //jump, can only go if on the ground
        {
            rigi.AddForce(new Vector2(0, jumpForce));
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
         onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         onGround = false;
    }

}