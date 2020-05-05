using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTemp : MonoBehaviour
{
    float damage = 10f;

    EnemyProperties enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyType>())
        {
            Debug.Log("this enemy is dumb and won't die");
            enemy = other.GetComponent<EnemyType>().GetEnemyProperties();
            enemy.DoDamage(damage);
        }
    }
}
