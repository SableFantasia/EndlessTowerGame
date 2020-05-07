using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pistol : MonoBehaviour
{

    [Header("State Variables")]

    private PlayerStates playerStates;

    private RangedWeaponHandler rangedWeaponHandler;
    public float shootingStateTimer = 1.5f;

    private float shootingTimer;

    [Header("Pistol Variables")]
    public float fireRate;

    public float bulletForce;

    private float fireTimer;

    public GameObject projectile;

    public float shootingHeight = 0.25f;

    private void Start()
    {
        playerStates = GetComponentInParent<PlayerStates>();
        rangedWeaponHandler = GetComponentInParent<RangedWeaponHandler>();
    }

    


    public void PistolBehaviour()
    {

        startPistol();
        whilePistol(rangedWeaponHandler.mouseCursor, rangedWeaponHandler.firePoint);
        stopPistol();



    }





    private void startPistol()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerStates.currentBasicPlayerState = PlayerState.Shooting;
            shootingTimer = shootingStateTimer;
        }
    }

    private void whilePistol(GameObject mouseCursor, Transform firePoint)
    {


        if (playerStates.currentBasicPlayerState.HasFlag(PlayerState.Shooting))
        {
            shootingTimer -= Time.deltaTime;
          
            if (Input.GetMouseButton(0) && Time.time >= fireTimer && playerStates.currentBasicPlayerState == PlayerState.Shooting)
            {
                shootingTimer = shootingStateTimer;


                PistolShootingRotation(rangedWeaponHandler.mouseCursor);

                fireTimer = Time.time + 1f / fireRate;
                GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

                bulletRB.AddForce((mouseCursor.transform.position - firePoint.transform.position).normalized * bulletForce, ForceMode.Impulse);
            }
        }

        
    }

    private void stopPistol()
    {


        if (playerStates.currentBasicPlayerState.HasFlag(PlayerState.Shooting))
        {
            if (shootingTimer <= 0)
            {
                playerStates.currentBasicPlayerState = PlayerState.Movement;
            }
        }


    }







    public LayerMask layerMask;

    public void PistolShootingRotation(GameObject mouseCursor)
    {
        if (playerStates.currentBasicPlayerState == PlayerState.Shooting)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                mouseCursor.transform.position = new Vector3(hit.point.x, hit.point.y + shootingHeight, hit.point.z);

                Debug.Log(hit.collider.gameObject.name);
            }




            transform.parent.LookAt(new Vector3(mouseCursor.transform.position.x, transform.position.y, mouseCursor.transform.position.z));


            shootingTimer -= Time.deltaTime;
        }
    }







}










    /*






    private void PistolBehaviour(GameObject mouseCursor, Transform firePoint)
    {
        if (Input.GetMouseButton(0) && Time.time >= fireTimer)
        {
            rangedWeaponHandler.shootingTimer = shootingStateTimer;


            fireTimer = Time.time + 1f / fireRate;
            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            bulletRB.AddForce((mouseCursor.transform.position - firePoint.transform.position).normalized * bulletForce, ForceMode.Impulse);
        }
    }


    

}

    */
