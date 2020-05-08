using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestAI : MonoBehaviour
{
    private EnemyType enemyType;
    private Transform enemyTransform;
    private EnemyProperties properties;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //properties.SetGameObjectOfSelf(gameObject);
        //properties.InitializeProperties();

        enemyTransform = gameObject.transform;
        //properties = enemy.GetComponent<EnemyProperties>();
        enemy = gameObject;


        //properties = new enemyProperties(gameObject, enemyTransform.position);
        //properties.InitializeProperties(gameObject, enemyTransform.position);
    }

    public void InitializeEnemy(EnemyProperties _Properties, Vector3 _setPosition, SpawnState _setSpawnState, int _setIdentity)
    {
        enemyType = gameObject.GetComponent<EnemyType>();


        properties = ScriptableObject.Instantiate<EnemyProperties>(_Properties);

        properties.InitializeProperties(gameObject, gameObject.transform.position, _setSpawnState, _setIdentity);

        enemyType.properties = properties;
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
            properties.MoveToRoam();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (properties)
        {
            Gizmos.DrawWireSphere(transform.position, properties.lookRadius);
        }
    }

    public void OnEnemyHit(float _damage)
    {

        properties.DoDamage(_damage);
    }
}
