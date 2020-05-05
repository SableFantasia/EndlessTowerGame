using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {


    private PlayerStates playerStates;

    public Vector3 velocity = Vector3.zero;

    private Rigidbody rb;

    public float lerpState;

    public float accel;

    public float decel;

    public float maxSpeed;


    public AnimationCurve curve;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        playerStates = GetComponent<PlayerStates>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMovementRotation();
    }



    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    private void FixedUpdate()
    {
        PerformMovement();
    }



    private void PerformMovement()
    {
        if (velocity == Vector3.zero)
        {
            lerpState = Mathf.Clamp(lerpState - Mathf.Sqrt(Time.deltaTime) * decel, 0, maxSpeed);
        }
        else if (velocity != Vector3.zero)
        {
            lerpState = Mathf.Clamp(lerpState + Mathf.Sqrt(Time.deltaTime) * accel, 0, maxSpeed);


            //finalSpeed = Mathf.Lerp(0, maxSpeed, lerpState);
            //Quaternion rotationCircle = Quaternion.AngleAxis(0, Vector3.forward);


            //circle.transform.rotation = Quaternion.Lerp(circle.transform.rotation, rotationCircle, 0.5f);


            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime * lerpState);
        }
    }




    public void PlayerMovementRotation()
    {

        bool Left, Right, Up, Down;

        if(playerStates.currentState == PlayerState.Movement && playerStates.currentState != PlayerState.Shooting)
        {

            //Left
            if (velocity.x == 1)
            {
                Left = true;

                Quaternion rotation = Quaternion.AngleAxis(90, Vector3.up);


                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, rotation, 0.5f);
            }
            else Left = false;

            //Down
            if (velocity.z == -1)
            {
                Down = true;
                Quaternion rotation = Quaternion.AngleAxis(180, Vector3.up);


                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, rotation, 0.5f);
            }
            else Down = false;
            //Right
            if (velocity.x == -1)
            {
                Right = true;

                Quaternion rotation = Quaternion.AngleAxis(270, Vector3.up);


                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, rotation, 0.5f);
            }
            else Right = false;
            //Up
            if (velocity.z == 1)
            {
                Up = true;
                Quaternion rotation = Quaternion.AngleAxis(0, Vector3.up);


                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, rotation, 0.5f);

            }
            else Up = false;

        }

    }


}
