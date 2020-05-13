using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTemp : MonoBehaviour
{
    float damage = 10f;

    EnemyProperties enemy;

    private float bulletLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTime += Time.deltaTime;

        if (bulletLifeTime >= 2 && gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyType>())
        {
            Debug.Log("this enemy is dumb and won't die");
            enemy = other.GetComponent<EnemyType>().GetEnemyProperties();
            enemy.DoDamage(damage);

            Destroy(gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
