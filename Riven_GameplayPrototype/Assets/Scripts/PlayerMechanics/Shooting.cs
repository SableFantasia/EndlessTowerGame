using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private float shootingTimer;

    public GameObject mouseCursor;

    public GameObject projectile;

    public Transform firePoint;

    public float fireRate;

    public float bulletForce;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        
        if (Input.GetMouseButton(1) && Time.time >= shootingTimer)
        {
            shootingTimer = Time.time + 1f / fireRate;
            PlayerShooting();

        }
    }

    private void FixedUpdate()
    {
        PlayerRotation();
    }



    private void PlayerShooting()
    {


        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);


        
    }

    private void PlayerRotation()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            mouseCursor.transform.position = hit.point;
        }


        //transform.rotation = Quaternion.LookRotation(new Vector3 (mouseCursor.transform.position.x, 0 , mouseCursor.transform.position.z));


        transform.LookAt(new Vector3(mouseCursor.transform.position.x, transform.position.y, mouseCursor.transform.position.z));

    }
}
