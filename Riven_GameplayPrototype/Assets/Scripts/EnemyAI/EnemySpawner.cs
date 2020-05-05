using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public EnemyNames enemyNames;
    //public EnemyProperties[] properties;

    public GameObject[] enemyPrefabs;
    public GameObject[] enemiesSpawned;
    public EnemyProperties[] enemyProperties;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int l = 0; l < enemiesSpawned.Length; l++)
        {

            for (int p = 0; p < enemyProperties.Length; p++)
            {
                if (enemyProperties[p].name == "TestEnemy")
                {
                    enemiesSpawned[l].GetComponent<EnemyTestAI>().InitializeEnemy(enemyProperties[p], new Vector3(0,0,0));
                    Debug.Log("This is a test enemy");
                    
                }
            }

        }

            /*switch (enemies[l].GetComponent<EnemyProperties>().name)
            {
                case "TestEnemy":
                    break;
                default:
                    break;
            }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
