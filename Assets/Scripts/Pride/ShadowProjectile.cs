using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowProjectile : MonoBehaviour
{
    private GameObject player;

    private float timer;

    public bool Detonate;

    public float speed;

    private float angle;

    public GameObject shadow;

    private GameObject shadow1;

    private GameObject shadow2;

    private GameObject shadow3;

    private float rando;

    Rigidbody2D rb;

    private void Start()
    {
        // sets timer for heart detonate and finds player
        timer = 5;

        player = GameObject.FindGameObjectWithTag("Player");

        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        rb.velocity = new Vector2(0, 0);


        if (Detonate)
        {

            // sets angle for each little heart to speard and destroys big heart
            angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x);

            timer -= Time.deltaTime;

            if (timer < 0)
            {

                rando = Random.Range((Mathf.PI / 6), (Mathf.PI / 3));

                shadow1 = Instantiate(shadow, transform.position, Quaternion.identity);

                shadow1.gameObject.GetComponent<ShadowProjectile>().angle = angle + rando;

                shadow2 = Instantiate(shadow, transform.position, Quaternion.identity);

                shadow2.gameObject.GetComponent<ShadowProjectile>().angle = angle;

                shadow3 = Instantiate(shadow, transform.position, Quaternion.identity);

                shadow3.gameObject.GetComponent<ShadowProjectile>().angle = angle - rando;

                Destroy(gameObject);

            }

        }

        // sets position of the hearts
        transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime * Mathf.Cos(angle)), transform.position.y - (speed * Time.deltaTime * Mathf.Sin(angle)));

    }

    // destorys hearts on collision 
    private void OnCollisionEnter2D(Collision2D other)
    {

        Destroy(gameObject);

    }
}