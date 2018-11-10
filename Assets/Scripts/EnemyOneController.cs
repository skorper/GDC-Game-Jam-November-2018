using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Jeffrey Lansford
 * 
 */

public class EnemyOneController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rig;

    public GameObject player;

    private Vector2 moveDistanceVector;

    public float moveDistance;

    private float distance;

    public float timeStun;

    bool stun;

    // Use this for initialization
    void Start () {

        rig = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player");

        stun = false;

	}

    // Update is called once per frame
    void Update() {

        // enemy moves in the direction of the player
        moveDistanceVector = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);

        distance = moveDistanceVector.magnitude;

        if (distance < moveDistance && !stun ) {

            if (moveDistanceVector.x > 0) {

                rig.velocity = new Vector2(-moveSpeed, rig.velocity.y);
            }

            if (moveDistanceVector.x < 0) {

                rig.velocity = new Vector2(moveSpeed, rig.velocity.y);

            }


        }

        else if ( stun ) {

            StunEnemy();

        }

    }

    public void StunEnemy ( ) {

        float timer = timeStun;

        while ( timer > 0 ) {

            timer -= Time.deltaTime;

        }

    }

}
