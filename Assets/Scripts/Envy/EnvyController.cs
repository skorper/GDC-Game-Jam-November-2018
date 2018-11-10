using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Envy Controller
	Author: Stepheny Perez
	-----------------------
	Controls Envy and his fight mechanics
 */
public class EnvyController : MonoBehaviour 
{
	public float attackSpeed;
	public float moveSpeed;
	public GameObject meleeAttack;

	private GameObject player;
	private GameObject meleeObject;
	private Rigidbody2D rig;
	private Vector2 moveDistanceVector;
	private int HP = 3;
	private float meleeDistance = 1;
	private float attackAnimationSpeed = 0.1f;
	private bool direction = true; //False == Left
	private float distance;
	private bool isAttacking = false;
	private float attackTimeStep;
	
	void Start () 
	{
		attackTimeStep = attackSpeed;
		player = GameObject.FindGameObjectWithTag("Player");
		rig = GetComponent<Rigidbody2D>();
	}

	void FlipDirection()
	{
		Debug.Log("Flipping character to " + direction);
		if (direction) //Right
		{
			//TODO flip character 
		}
		else //Left
		{
			//TODO flip character
		}
		direction = !direction;
	}
	
	void Update () 
	{
		if (attackTimeStep > 0) attackTimeStep -= Time.deltaTime;
		//Face player
		if ((player.transform.position.x < this.transform.position.x) && direction
		|| (player.transform.position.x > this.transform.position.x) && !direction)
		{
			FlipDirection();
		}
		float distance = Vector2.Distance(player.transform.position, this.transform.position);
		//Determine distance for possible actions
		if  (distance < meleeDistance && attackTimeStep <= 0)
		{
			Melee();
			attackTimeStep = attackSpeed;
		}
		else if (distance > 1)
		{
			Walk();
		}
	}

	void Melee()
	{
		//TODO animate attack
		if (!isAttacking)
		{
			isAttacking = true;
			meleeObject = Instantiate(meleeAttack, new Vector3(player.transform.position.x, player.transform.position.y, -0.25f), Quaternion.identity);
			StartCoroutine(DestroyMelee());
		}
		isAttacking = false;
	}

	public IEnumerator DestroyMelee()
	{
		yield return new WaitForSeconds(attackAnimationSpeed);
		Destroy(meleeObject);
	}

	void Walk()
	{
		//TODO animate walk
        moveDistanceVector = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
        distance = moveDistanceVector.magnitude;
		if (moveDistanceVector.x > 0) 
		{
			rig.velocity = new Vector2(-moveSpeed, rig.velocity.y);
		}
		if (moveDistanceVector.x < 0) 
		{
			rig.velocity = new Vector2(moveSpeed, rig.velocity.y);
		}
	}
}
