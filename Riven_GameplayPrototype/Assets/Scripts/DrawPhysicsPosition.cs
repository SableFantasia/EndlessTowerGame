using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPhysicsPosition : MonoBehaviour
{
    public Transform parent;
    private float r;

    private void Awake()
    {
        r = parent.GetComponent<SpawnAgent>().sphereRadius;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, r);
    }
}
