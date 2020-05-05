using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerMotor))]
public class Movement : MonoBehaviour {


    private Rigidbody rb;
    private PlayerMotor motor;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        motor = GetComponent<PlayerMotor>();
    }







    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");



        Vector3 moveHorizontal = transform.right * xMovement;

        Vector3 moveVertical = transform.forward * zMovement;

        Vector3 _velocity = (moveHorizontal + moveVertical).normalized;


        motor.Move(_velocity);
    }
}








/*



    // Use this for initialization
    void Start ()
{
    rb = GetComponent<Rigidbody>();
}

// Update is called once per frame
void Update ()
{


    PlayerRotation();

    // Se ti stai muovendo la velocita' di cambio parte 50

    //Se stai fermo e riparti la velocita' di cambio parte da 0

    Debug.Log(movement.x);

    Debug.Log(movement.z);

    velocity = Mathf.Sqrt


    movement.x = Input.GetAxisRaw("Horizontal");

    movement.z = Input.GetAxisRaw("Vertical");


    velocity 


    if(velocity >= 100)
    {
        velocity = 100;
    }


    rb.MovePosition(rb.position + movement * velocity / 100);





    if (Input.GetKey(KeyCode.W))
    {
        rb.velocity = new Vector3(0, 0, 1) * velocity;
    }

    if (Input.GetKey(KeyCode.A))
    {
        rb.velocity = new Vector3(-1, 0, 0) * velocity;
    }

    if (Input.GetKey(KeyCode.S))
    {
        rb.velocity = new Vector3(0, 0, -1) * velocity;
    }

    if (Input.GetKey(KeyCode.D))
    {
        rb.velocity = new Vector3(1, 0, 0) * velocity;
    }








}




}
*/
