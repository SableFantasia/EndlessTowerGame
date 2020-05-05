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

    public void InitializeEnemy(EnemyProperties _Properties, Vector3 _setPosition)
    {
        enemyType = gameObject.GetComponent<EnemyType>();


        properties = ScriptableObject.Instantiate<EnemyProperties>(_Properties);
        properties.SetGameObjectOfSelf(gameObject);
        properties.InitializeProperties(gameObject, gameObject.transform.position);

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

        properties.IsDead();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnEnemyHit(5f);
        }

        if (properties.IsDead())
        {
            Debug.Log("EnemyIsDead");
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
