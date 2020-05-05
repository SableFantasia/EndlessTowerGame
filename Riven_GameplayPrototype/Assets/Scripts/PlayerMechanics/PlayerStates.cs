using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Flags]
public enum PlayerState {
    Movement = 1,
    Shooting = 2,
    Attacking = 4

}

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(MeleeSystem))]

public class PlayerStates : MonoBehaviour {


    private Rigidbody rb;
    private PlayerMovement movement;
    private ShootingSystem shooting;
    private MeleeSystem melee;

    public PlayerState basicPlayerState;

    public PlayerState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movement = GetComponent<PlayerMovement>();

        shooting = GetComponentInChildren<ShootingSystem>();

        melee = GetComponent<MeleeSystem>();

        basicPlayerState = PlayerState.Movement | PlayerState.Shooting;

        currentState = PlayerState.Movement;
    }







    void Update()
    {
        PlayerMechanics();

    }



    private void PlayerMechanics()
    {
        if (currentState.HasFlag(PlayerState.Movement) || currentState.HasFlag(PlayerState.Shooting))
        {

            float xMovement = Input.GetAxisRaw("Horizontal");
            float zMovement = Input.GetAxisRaw("Vertical");



            Vector3 moveHorizontal = transform.right * xMovement;

            Vector3 moveVertical = transform.forward * zMovement;

            Vector3 _velocity = (moveHorizontal + moveVertical).normalized;
            


            movement.Move(_velocity);

        }




        if (currentState.HasFlag(PlayerState.Movement) || currentState.HasFlag(PlayerState.Shooting))
        {
            shooting.PlayerShootingState();
        }



        if(currentState == PlayerState.Attacking)
        {
            //Melee system


        }


    }










}





