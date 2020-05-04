using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;

    private Rigidbody rb;

    public float lerpState;

    public float accel;

    public float decel;

    public float maxSpeed;

    public float finalSpeed;


    public AnimationCurve curve;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
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


            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime * lerpState);
        }
    }
}
