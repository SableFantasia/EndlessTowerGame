using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgent : MonoBehaviour
{
    public bool checkIsCollision = false;
    public float sphereRadius;
    public Transform physicsPosition;

    // Start is called before the first frame update
    void Awake()
    {
        if (Physics.CheckSphere(physicsPosition.position, sphereRadius))
        {
            checkIsCollision = true;
        }

        GetComponent<BoxCollider>().enabled = true;
    }
}
