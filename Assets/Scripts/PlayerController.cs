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
    public float invulterabilityTimer;

    public int currentWeapon; //the index of weapon assests, go to WeaponsAndAbilites method for more info
    public int Health;

    private bool onGround = false;
    public Rigidbody2D rigi; // was private
    private PlayerWeapons Weps;
    private GameObject door;

    
	void Start ()
    {
        Health = 3;
        rigi = gameObject.GetComponent<Rigidbody2D>();
        Weps = gameObject.GetComponent<PlayerWeapons>();
        Weps.SwapWeapons("sword", "");

    }
	

	void Update ()
    {
        Movement();

        if(invulterabilityTimer > 0)
        {

        }

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

    void TakeDamage()
    {
        float InvTime = 3;

        invulterabilityTimer = InvTime;

        Health -= 1;
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

}
//rigi.AddForce(moveSpeed * (float)Math.Cos((moveRadians)), 0, moveSpeed * (float)Math.Sin((moveRadians)));