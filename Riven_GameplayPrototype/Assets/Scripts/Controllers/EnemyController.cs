using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 15f;

    Transform target;
    NavMeshAgent agent;

    private Vector3 startingPosition;
    private Vector3 roamPosition;
    // Start is called before the first frame update

    
    void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        
    }
    
    // Get a target position from a random range between 2 values based on starting position.
    private Vector3 GetRoamingPosition ()
    {
        return startingPosition + GetRandomDir() * Random.Range(10f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        //move to roam position
        float reachedPositionDistance = 1f;
        if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
        {
            roamPosition = GetRoamingPosition();
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        if (distance <= agent.stoppingDistance)
        {
            ///
            FaceTarget();

        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    //Generate random normalized direction
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
