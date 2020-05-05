﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {

    private PlayerStates playerStates;

    private float fireTimer;

    private float shootingTimer;

    public float shootingStateTimer = 1.5f;

    public GameObject mouseCursor;

    public GameObject projectile;

    public Transform firePoint;

    public float fireRate;

    public float bulletForce;

    public LayerMask layerMask;

    public float shootingHeight = 0.25f;

    // Use this for initialization
    void Start ()
    {

        playerStates = GetComponentInParent<PlayerStates>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerShootingRotation();
    }



    public void PlayerShootingState()
    {
        shootingTimer -= Time.deltaTime;


        if (Input.GetMouseButton(0) && Time.time >= fireTimer)
        {
            playerStates.currentState = PlayerState.Shooting;

            shootingTimer = shootingStateTimer;

            PlayerShooting();

        }

        if(shootingTimer <= 0)
        {
            playerStates.currentState = PlayerState.Movement;
        }

    }
    



    public void PlayerShooting()
    {

        fireTimer = Time.time + 1f / fireRate;
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        bulletRB.AddForce((mouseCursor.transform.position - firePoint.transform.position).normalized * bulletForce, ForceMode.Impulse);
    }


    public void PlayerShootingRotation()
    {
        if(playerStates.currentState == PlayerState.Shooting)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                mouseCursor.transform.position = new Vector3 (hit.point.x, hit.point.y + shootingHeight, hit.point.z);

                Debug.Log(hit.collider.gameObject.name);
            }

            


            transform.LookAt(new Vector3(mouseCursor.transform.position.x, transform.position.y, mouseCursor.transform.position.z));
            

            shootingTimer -= Time.deltaTime;


        }

    }
}
