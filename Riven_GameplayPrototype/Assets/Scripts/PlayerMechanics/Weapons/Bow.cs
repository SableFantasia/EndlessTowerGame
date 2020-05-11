using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{


    [Header("State Variables")]

    private PlayerStates playerStates;

    private RangedWeaponHandler rangedWeaponHandler;
    public float shootingStateTimer = 1.5f;

    private float shootingTimer;

    [Header("Bow Variables")]
    public float bowFireRate;

    public float bulletForce;

    public float chargeShotTimer;

    public GameObject projectile;

    public GameObject currentProjectile;

    private Rigidbody currentProjectileRB;

    public float shootingHeight = 0.25f;

    public AnimationCurve bowCurve;

    // Start is called before the first frame update
    void Start()
    {
        playerStates = GetComponentInParent<PlayerStates>();
        rangedWeaponHandler = GetComponentInParent<RangedWeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void BowBehaviour()
    {
        startBow();
        whileBow();
        stopBow();
    }




    private void startBow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerStates.currentBasicPlayerState = PlayerState.Shooting;
            shootingTimer = shootingStateTimer;
            currentProjectile = Instantiate(projectile, rangedWeaponHandler.firePoint.position, rangedWeaponHandler.firePoint.rotation);

            currentProjectileRB = currentProjectile.GetComponent<Rigidbody>();

        }
    }


    private void whileBow()
    {
        if (playerStates.currentBasicPlayerState.HasFlag(PlayerState.Shooting))
        {
            shootingTimer -= Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                chargeShotTimer += Time.deltaTime;

                shootingTimer = shootingStateTimer;

                currentProjectile.transform.position = rangedWeaponHandler.firePoint.position;
                currentProjectile.transform.rotation = rangedWeaponHandler.firePoint.rotation;
                currentProjectile.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(1,1,1), chargeShotTimer);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Destroy(currentProjectile);
                chargeShotTimer = 0;
                GameObject Projectile = Instantiate(projectile, rangedWeaponHandler.firePoint.position, rangedWeaponHandler.firePoint.rotation);
                Rigidbody ProjectileRB = Projectile.GetComponent<Rigidbody>();

                ProjectileRB.AddForce((rangedWeaponHandler.mouseCursor.transform.position - rangedWeaponHandler.firePoint.transform.position).normalized * bulletForce, ForceMode.Impulse);
            }
        }
    }

    private void stopBow()
    {
        if (playerStates.currentBasicPlayerState.HasFlag(PlayerState.Shooting))
        {
            PistolShootingRotation(rangedWeaponHandler.mouseCursor);
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
