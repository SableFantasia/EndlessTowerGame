using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnArea : MonoBehaviour
{
    public float spawnRadius = 15f;
    public float heightRange = 3f;
    public float onMeshThreshold = 2f;
    public GameObject spawnAgentPrefab;
    public GameObject _ThisAgentReference;

    public float spawnTicker = 5f;
    private float spawnTimer = 0f;
    private bool checkOnUpdateCollision = false;



    public bool IsAgentOnNavMesh(GameObject agentObject)
    {
        Vector3 agentPosition = agentObject.transform.position;
        NavMeshHit hit;

        // Check for nearest point on navmesh to agent, within onMeshThreshold

        if (NavMesh.SamplePosition(agentPosition, out hit, onMeshThreshold, NavMesh.AllAreas))
        {
            // Check if the positions are vertically aligned

            if (Mathf.Approximately(agentPosition.x, hit.position.x)
                && Mathf.Approximately(agentPosition.z, hit.position.z))
            {
                // Lastly, check if object is below navmesh

                return agentPosition.y >= hit.position.y;
            }
        }

        return false;
    }

    public Vector3 GetRandomSpawnVector()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        Vector3 yAxisPosition = gameObject.transform.position + new Vector3(0f, y, 0f).normalized * Random.Range(-heightRange, heightRange);
        Vector3 setRandomPosition = gameObject.transform.position + new Vector3(x, 0f, z).normalized * Random.Range(0f, spawnRadius);

        setRandomPosition.y = yAxisPosition.y;
        return setRandomPosition;
    }

    public bool SpawnNewAgent()
    {
        _ThisAgentReference = Instantiate(spawnAgentPrefab, GetRandomSpawnVector(), Quaternion.identity);

        if(IsAgentOnNavMesh(_ThisAgentReference))
        {
            Debug.Log("Agent is on NavMesh SUCCESS!");
            if (_ThisAgentReference.GetComponent<SpawnAgent>().checkIsCollision)
            {
                Debug.Log("There is a physics collision with another object!");
                GameObject.Destroy(_ThisAgentReference);
            }
            else
            {
                checkOnUpdateCollision = true;
            }

            return true;
        }
        else
        {
            Debug.Log("Do something");
            
            return false;
        }
        
    }

    public Vector3 GetThisAgent()
    {
        return _ThisAgentReference.transform.position;
    }

    public void Update()
    {
        /*
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTicker)
        {
            while (!SpawnNewAgent())
            {
                GameObject.Destroy(_ThisAgentReference);
            }
            
            spawnTimer = 0f;


        }
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
