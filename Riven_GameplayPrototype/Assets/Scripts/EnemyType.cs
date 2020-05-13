using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    GameObject thisEnemyObject;

    public EnemyProperties properties;

    
    public enum EnemyTypes { _NoEnemy, _TestEnemy, _AnotherEnemy };
    public EnemyTypes enemyType;

    

    private void Start()
    {
        thisEnemyObject = gameObject;
    }

    public EnemyProperties GetEnemyProperties ()
    {
            return properties;
    }

    public void SetEnemyType (string _setEnemyType)
    {
        switch (_setEnemyType)
            
        {
            case "EnemyTest":
                enemyType = EnemyTypes._TestEnemy;
                break;
        }
    }
}
