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
    public float fireRate;

    public float bulletForce;

    private float fireTimer;

    public GameObject projectile;

    public float shootingHeight = 0.25f;



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



    public void ShootBow()
    {

    }

}
