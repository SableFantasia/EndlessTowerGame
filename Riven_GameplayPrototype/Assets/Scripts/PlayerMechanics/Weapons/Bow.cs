using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BowComboBehaviour { Dash }


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

    private GameObject currentProjectileInstance;

    private Rigidbody currentProjectileRB;

    public float shootingHeight = 0.25f;

    public AnimationCurve bowCurve;

    private float lastClickTime;

    private float timeBetweenClicks;



    [Header("Bow Behaviours Variables")]

    [Space]

    [Header("Dash Variables")]
    public BowComboBehaviour bowBehaviour;

    private float dashLerpTimer;

    private Vector3 startingLerpPosition;

    private Vector3 movingLerpPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerStates = GetComponentInParent<PlayerStates>();
        rangedWeaponHandler = GetComponentInParent<RangedWeaponHandler>();

        bowBehaviour = BowComboBehaviour.Dash;
    }

    // Update is called once per frame
    void Update()
    {
        switch (bowBehaviour)
        {
            case BowComboBehaviour.Dash:
                {
                    if (playerStates.currentState == PlayerState.comboShooting)
                    {

                        dashLerpTimer += Time.deltaTime;

                        transform.parent.parent.position = Vector3.Lerp( startingLerpPosition, movingLerpPosition, bowCurve.Evaluate(dashLerpTimer));

                        Debug.Log("Yoo");

                        Debug.Log(startingLerpPosition);

                        Debug.Log(movingLerpPosition);

                        if (bowCurve.Evaluate(dashLerpTimer) >= 1)
                        {
                            dashLerpTimer = 0;

                            playerStates.currentState = PlayerState.BasicPlayerState;
                        }


                    }


                    break;
                }
        }
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
            currentProjectileInstance = Instantiate(currentProjectile, rangedWeaponHandler.firePoint.position, rangedWeaponHandler.firePoint.rotation);

            currentProjectileRB = currentProjectile.GetComponent<Rigidbody>();

            timeBetweenClicks = Time.time;


            if ( 0 < timeBetweenClicks - lastClickTime && timeBetweenClicks - lastClickTime <= 0.13f)
            {
                playerStates.currentState = PlayerState.comboShooting;

                startingLerpPosition = transform.position;


                //movingLerpPosition = (new Vector3(rangedWeaponHandler.mouseCursor.transform.position.x, transform.parent.parent.position.y, rangedWeaponHandler.mouseCursor.transform.position.z) - new Vector3(rangedWeaponHandler.firePoint.transform.position.x, transform.parent.parent.position.y, rangedWeaponHandler.firePoint.transform.position.z).normalized);

                movingLerpPosition = transform.GetChild(0).position;
            }

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

                currentProjectileInstance.transform.position = rangedWeaponHandler.firePoint.position;
                currentProjectileInstance.transform.rotation = rangedWeaponHandler.firePoint.rotation;
                currentProjectileInstance.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(1,1,1), chargeShotTimer);
            }

            if (Input.GetMouseButtonUp(0))
            {

                Debug.Log("wtf");
                Destroy(currentProjectileInstance);
                chargeShotTimer = 0;
                GameObject Projectile = Instantiate(projectile, rangedWeaponHandler.firePoint.position, rangedWeaponHandler.firePoint.rotation);
                Rigidbody ProjectileRB = Projectile.GetComponent<Rigidbody>();


                lastClickTime = Time.time;


                ProjectileRB.AddForce((rangedWeaponHandler.mouseCursor.transform.position - rangedWeaponHandler.firePoint.transform.position).normalized * bulletForce, ForceMode.Impulse);
            }

            
        }
    }

    private void stopBow()
    {
        if (playerStates.currentBasicPlayerState.HasFlag(PlayerState.Shooting))
        {
            BowShootingRotation(rangedWeaponHandler.mouseCursor);
            if (shootingTimer <= 0)
            {
                playerStates.currentBasicPlayerState = PlayerState.Movement;
            }
        }
    }



    public LayerMask layerMask;

    public void BowShootingRotation(GameObject mouseCursor)
    {
        if (playerStates.currentBasicPlayerState == PlayerState.Shooting)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                mouseCursor.transform.position = new Vector3(hit.point.x, hit.point.y + shootingHeight, hit.point.z);
            }




            transform.parent.LookAt(new Vector3(mouseCursor.transform.position.x, transform.position.y, mouseCursor.transform.position.z));


            shootingTimer -= Time.deltaTime;
        }
    }

}














