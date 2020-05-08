using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    GameObject thisEnemyObject;

    public EnemyProperties properties;

    EnemyTypes enemyType;
    enum EnemyTypes { _TestEnemy, _AnotherEnemy };


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

    

    public void SetIdentity(int _identity)
    {
        properties.SetIndex(_identity);
    }

    public int GetEnemyIdentity()
    {
        return properties.identity;
    }
}
