using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProjectile : MonoBehaviour {


    private GameObject player;

    private float timer;

    public bool Detonate;

    public float speed;

    private float angle;

    public GameObject heart; 

    private GameObject heart1;

    private GameObject heart2;

    private GameObject heart3;

    private float rando;

    Rigidbody2D rb; 

    private void Start() {

        timer = 2;

        player = GameObject.FindGameObjectWithTag("Player");

        rb = gameObject.GetComponent<Rigidbody2D>(); 

    }

    private void Update() {

        rb.velocity = new Vector2(0, 0);

        
        if (Detonate) {

            angle = Mathf.Atan2( transform.position.y - player.transform.position.y , transform.position.x - player.transform.position.x);

            timer -= Time.deltaTime;

            if (timer < 0) {

                rando = Random.Range((Mathf.PI / 6), (Mathf.PI / 3)); 

                heart1 = Instantiate(heart, transform.position, Quaternion.identity);

                heart1.gameObject.GetComponent<HeartProjectile>().angle = angle + rando;

                heart2 = Instantiate(heart, transform.position, Quaternion.identity);

                heart3 = Instantiate(heart, transform.position, Quaternion.identity);

                heart3.gameObject.GetComponent<HeartProjectile>().angle = angle - rando;

                Destroy(gameObject);

            }

        }

        transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime * Mathf.Cos(angle)), transform.position.y - (speed * Time.deltaTime * Mathf.Sin(angle)));

    }

    private void OnCollisionEnter2D(Collision2D other) {

        Destroy(gameObject);

    }


}