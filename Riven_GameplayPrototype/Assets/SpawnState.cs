using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
    }

    public void EnemyDead(GameObject _enemy)
    {
        enemySpawner.RemoveEnemyByIdentity(_enemy);
    }
}
