using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestAI : MonoBehaviour
{
    public enemyProperties properties;

    // Start is called before the first frame update
    void Start()

    {
        properties.SetGameObjectOfSelf(gameObject);
        properties.InitializeProperties();

    }

    // Update is called once per frame
    void Update()
    {
        if (properties.CheckRoamPosition())
        {
            properties.GetRoamingPosition();
            Debug.Log("setting new position");

        }
        else
        {
            Debug.Log("roaming");
            properties.MoveToRoam();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, properties.lookRadius);
    }
}
