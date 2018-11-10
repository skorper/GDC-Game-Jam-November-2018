using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by Alexander (Sep)
 * 575-386-7531
 * 
 */
public class PlayerController : MonoBehaviour {

    public float moveSpeed = 10;
    public float jumpForce = 10;
    public float speedLimit = 100;

    private bool onGround = false;
    private Rigidbody2D rigi;

    
	void Start ()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
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
        Debug.Log(rigi.velocity);
        //speed limit x
        if(rigi.velocity.x > speedLimit)
        {
            rigi.velocity = new Vector2(speedLimit, rigi.velocity.y);
        }

        if (rigi.velocity.x < -speedLimit)
        {
            rigi.velocity = new Vector2(-speedLimit, rigi.velocity.y);
        }
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
