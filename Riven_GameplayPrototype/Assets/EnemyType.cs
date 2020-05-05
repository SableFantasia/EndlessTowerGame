using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public EnemyProperties properties;

    EnemyTypes enemyType;
    enum EnemyTypes { _TestEnemy, _AnotherEnemy };

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
