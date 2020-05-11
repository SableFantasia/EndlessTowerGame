using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Flags]
public enum PlayerState {
    BasicPlayerState = 0,

    Movement = 1,
    Shooting = 2,
    Melee = 4

}

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(MeleeSystem))]
[RequireComponent(typeof(RangedWeaponHandler))]

public class PlayerStates : MonoBehaviour {


    private Rigidbody rb;
    private PlayerMovement movement;
    private RangedWeaponHandler rangedWeaponHandler;
    private MeleeSystem meleeSystem;

    public PlayerState currentBasicPlayerState;

    public PlayerState currentState;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movement = GetComponent<PlayerMovement>();

        rangedWeaponHandler = GetComponentInChildren<RangedWeaponHandler>();

        meleeSystem = GetComponent<MeleeSystem>();

        currentState = PlayerState.BasicPlayerState;

        currentBasicPlayerState = PlayerState.Movement;
    }







    void Update()
    {


        switch (currentState)
        {
            case PlayerState.BasicPlayerState:
                {
                    PlayerMechanics();
                    break;
                }
        }

    }


    private void PlayerMechanics()
{
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");



        Vector3 moveHorizontal = transform.right * xMovement;

        Vector3 moveVertical = transform.forward * zMovement;

        Vector3 _velocity = (moveHorizontal + moveVertical).normalized;
            


        movement.Move(_velocity);




        rangedWeaponHandler.WeaponBehavioursFunction();

        DoMelee();
    }




    public void Shoot()
    {
        if (currentBasicPlayerState.HasFlag(PlayerState.Movement) || currentBasicPlayerState.HasFlag(PlayerState.Shooting) && currentBasicPlayerState != PlayerState.Melee)
        {
            
        }

    }


    public void DoMelee()
    {
        if (currentBasicPlayerState.HasFlag(PlayerState.Movement) || currentBasicPlayerState.HasFlag(PlayerState.Melee) && currentBasicPlayerState != PlayerState.Shooting)
        {
            if (Input.GetMouseButton(1))
            {
                currentBasicPlayerState = PlayerState.Melee;
                //shootingSystem.PlayerShootingState();
            }
        }
    }



}





