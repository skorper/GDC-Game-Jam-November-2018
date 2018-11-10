using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProjectile : MonoBehaviour {

    public float despawn;

    private void Update() {

        Destroy(gameObject, despawn);

    }

    private void OnTriggerEnter2D(Collider2D other) {

        Destroy(gameObject);


    }


}