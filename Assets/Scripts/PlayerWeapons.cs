using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by Alexander (sep)
 * 575-386-7531
 */


public class PlayerWeapons : MonoBehaviour {

    //private PlayerController controller;

    public GameObject[] weapons;
    public bool usingSword = false;
    public int currentWeaponIndex;
    public string powerup = "";
    private float attackTimer;
    public float swordTimer;

    // Use this for initialization
    void Start () {

        //controller = gameObject.GetComponent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {

        switch (currentWeaponIndex)
        {
            case 0: swordWeapon(); break;
        }



	}

    public void SwapWeapons(string weaponName, string newpowerup) //called from PlayerController
    {

        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        switch (weaponName)
        {
            case "sword":
                currentWeaponIndex = 0;
                powerup = newpowerup;
                break;
        }
        
    }

    void swordWeapon()
    {
        //attackTimer     how long has passed since last attack
        float attackDelay = .15f; // time between attacks
        float swordTime = .1f; // how long the sword stays in front of player
        // swordTimer      keep track how long sword has been in front of player
        GameObject sword = weapons[0];
        BoxCollider2D swordHitbox = sword.GetComponent<BoxCollider2D>();
        Vector2 attackPosition = new Vector2(0.411f, 0);
        Vector2 defaultPosition = new Vector2(0.327f, 0.139f);
        Vector3 attackRotation = new Vector3(0, 0, 270);

        sword.SetActive(true);

        if (swordTimer > 0)
        {
            swordTimer -= Time.deltaTime;
            sword.gameObject.transform.position = new Vector2(gameObject.transform.position.x + attackPosition.x, gameObject.transform.position.y + attackPosition.y);
            sword.gameObject.transform.rotation = Quaternion.Euler(0, 0, attackRotation.z);
            swordHitbox.enabled = true;
        }
        else
        {
            sword.gameObject.transform.position = new Vector2(gameObject.transform.position.x + defaultPosition.x, gameObject.transform.position.y + defaultPosition.y);
            sword.gameObject.transform.rotation = Quaternion.identity;
            swordHitbox.enabled = false;
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && attackTimer <= 0)
        {
            attackTimer = attackDelay;
            swordTimer = swordTime;
        }
    }

}
